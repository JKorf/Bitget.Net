using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApi : RestApiClient, IBitgetRestClientSpotApi, ISpotClient
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Spot Api");

        /// <inheritdoc />
        public IBitgetRestClientSpotApiAccount Account { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiTrading Trading { get; }

        /// <inheritdoc />
        public ISpotClient CommonSpotClient => this;

        /// <inheritdoc />
        public string ExchangeName => "Bitget";
        
        /// <inheritdoc />
        public event Action<OrderId>? OnOrderPlaced;

        /// <inheritdoc />
        public event Action<OrderId>? OnOrderCanceled;

        internal BitgetRestClientSpotApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.SpotOptions)
        {
            Account = new BitgetRestClientSpotApiAccount(this);
            ExchangeData = new BitgetRestClientSpotApiExchangeData(this);
            Trading = new BitgetRestClientSpotApiTrading(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", !string.IsNullOrEmpty(options.ChannelCode) ? options.ChannelCode! : baseClient._defaultChannelCode }
            };
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);

        internal Uri GetUri(string path)
        {
            return new Uri(BaseAddress.AppendPath(path));
        }

        internal async Task<WebCallResult> ExecuteAsync(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, int weight = 1, bool ignoreRatelimit = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse>(uri, method, ct, parameters, signed, parameterPosition, requestWeight: weight, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
            if (!result)
                return result.AsDatalessError(result.Error!);

            if (result.Data.Code != "00000")
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.AsDataless();
        }

        internal async Task<WebCallResult<T>> ExecuteAsync<T>(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, int weight = 1, bool ignoreRatelimit = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse<T>>(uri, method, ct, parameters, signed, parameterPosition, requestWeight: weight, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
            if (!result)
                return result.AsError<T>(result.Error!);

            if (result.Data.Code != "00000")
                return result.AsError<T>(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.As(result.Data.Data!);
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders, string data)
        {
            var tokenData = data.ToJToken();
            if (tokenData == null)
                return new ServerError(data);

            var msg = tokenData["msg"];
            var code = tokenData["code"];
            if (msg == null || code == null || !int.TryParse(code.ToString(), out var intCode))
                return new ServerError(data);

            return new ServerError(intCode, msg.ToString());
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;


        #region CommonSpotClient implementation

        internal void InvokeOrderPlaced(OrderId id)
        {
            OnOrderPlaced?.Invoke(id);
        }

        internal void InvokeOrderCanceled(OrderId id)
        {
            OnOrderCanceled?.Invoke(id);
        }

        /// <inheritdoc />
        async Task<WebCallResult<OrderId>> ISpotClient.PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price, string? accountId, string? clientOrderId, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.PlaceOrderAsync), nameof(symbol));

            var result = await Trading.PlaceOrderAsync(symbol,
                                                       side == CommonOrderSide.Buy ? Enums.BitgetOrderSide.Buy : Enums.BitgetOrderSide.Sell,
                                                       type == CommonOrderType.Limit ? Enums.BitgetOrderType.Limit : Enums.BitgetOrderType.Market,
                                                       quantity,
                                                       type == CommonOrderType.Limit ? Enums.BitgetTimeInForce.GoodTillCanceled : Enums.BitgetTimeInForce.FillOrKill,
                                                       price,
                                                       clientOrderId,
                                                       ct).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(default);

            return result.As(new OrderId
            {
                Id = result.Data.OrderId!,
                SourceObject = result.Data
            });
        }

        /// <inheritdoc />
        string IBaseRestClient.GetSymbolName(string baseAsset, string quoteAsset) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + "_SPBL";

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Symbol>>> IBaseRestClient.GetSymbolsAsync(CancellationToken ct)
        {
            var symbols = await ExchangeData.GetSymbolsAsync(ct).ConfigureAwait(false);
            if (!symbols)
                return symbols.As<IEnumerable<Symbol>>(default);

            return symbols.As(symbols.Data.Select(x => new Symbol
            {
                Name = x.Name,
                MinTradeQuantity = x.MinOrderQuantity,
                PriceDecimals = x.PriceDecimals,
                QuantityDecimals = x.QuantityDecimals,
                SourceObject = x
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<Ticker>> IBaseRestClient.GetTickerAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));

            var ticker = await ExchangeData.GetTickerAsync(symbol, ct).ConfigureAwait(false);
            if (!ticker)
                return ticker.As<Ticker>(default);

            return ticker.As(new Ticker
            {
                HighPrice = ticker.Data.HighPrice24h,
                LastPrice = ticker.Data.ClosePrice,
                LowPrice = ticker.Data.LowPrice24h,
                Price24H = ticker.Data.OpenPriceUtc0,
                SourceObject = ticker.Data,
                Symbol = symbol,
                Volume = ticker.Data.BaseVolume
            });
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Ticker>>> IBaseRestClient.GetTickersAsync(CancellationToken ct)
        {
            var tickers = await ExchangeData.GetTickersAsync(ct).ConfigureAwait(false);
            if (!tickers)
                return tickers.As<IEnumerable<Ticker>>(default);

            return tickers.As(tickers.Data.Select(x => new Ticker
            {
                HighPrice = x.HighPrice24h,
                LastPrice = x.ClosePrice,
                LowPrice = x.LowPrice24h,
                Price24H = x.OpenPriceUtc0,
                SourceObject = x,
                Symbol = x.Symbol,
                Volume = x.BaseVolume
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Kline>>> IBaseRestClient.GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime, DateTime? endTime, int? limit, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetKlinesAsync), nameof(symbol));

            var interval = (BitgetKlineInterval)(int)timespan.TotalSeconds;
            if (!Enum.IsDefined(typeof(BitgetKlineInterval), interval))
                throw new ArgumentException(nameof(timespan), "");

            var klines = await ExchangeData.GetKlinesAsync(symbol, interval, startTime, endTime, limit, ct).ConfigureAwait(false);
            if (!klines)
                return klines.As<IEnumerable<Kline>>(default);

            return klines.As(klines.Data.Select(x => new Kline
            {
                HighPrice = x.HighPrice,
                LowPrice = x.LowPrice,
                ClosePrice = x.ClosePrice,
                OpenPrice = x.OpenPrice,
                OpenTime = x.Timestamp,
                SourceObject = x,
                Volume = x.BaseVolume
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<OrderBook>> IBaseRestClient.GetOrderBookAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetOrderBookAsync), nameof(symbol));

            var book = await ExchangeData.GetOrderBookAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!book)
                return book.As<OrderBook>(default);

            return book.As(new OrderBook
            {
                SourceObject = book.Data,
                Asks = book.Data.Asks.Select(x => new OrderBookEntry { Price = x.Price, Quantity = x.Quantity }),
                Bids = book.Data.Bids.Select(x => new OrderBookEntry { Price = x.Price, Quantity = x.Quantity })
            });
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Trade>>> IBaseRestClient.GetRecentTradesAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetRecentTradesAsync), nameof(symbol));

            var trades = await ExchangeData.GetRecentTradesAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!trades)
                return trades.As<IEnumerable<Trade>>(default);

            return trades.As(trades.Data.Select(x => new Trade
            {
                Price = x.Price,
                Quantity = x.Quantity,
                Timestamp = x.Timestamp,
                SourceObject = x,
                Symbol = x.Symbol,
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Balance>>> IBaseRestClient.GetBalancesAsync(string? accountId, CancellationToken ct)
        {
            var balances = await Account.GetBalancesAsync(ct: ct).ConfigureAwait(false);
            if (!balances)
                return balances.As<IEnumerable<Balance>>(default);

            return balances.As(balances.Data.Select(x => new Balance
            {
                Asset = x.AssetName,
                Available = x.Available,
                Total = x.Available + x.Frozen + x.Locked,
                SourceObject = x,
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<Order>> IBaseRestClient.GetOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentException(nameof(orderId) + " required for Bitget " + nameof(ISpotClient.GetOrderAsync), nameof(orderId));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetOrderAsync), nameof(symbol));

            var order = await Trading.GetOrderAsync(symbol!, orderId, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.As<Order>(default);

            return order.As(new Order
            {
                Id = orderId,
                Price = order.Data.Price,
                Quantity = order.Data.Quantity,
                QuantityFilled = order.Data.QuantityFilled,
                Side = order.Data.Side == BitgetOrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = order.Data.Status == BitgetOrderStatus.Cancelled ? CommonOrderStatus.Canceled: order.Data.Status == BitgetOrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = symbol!,
                Timestamp = order.Data.CreateTime,
                Type = order.Data.OrderType == BitgetOrderType.Limit ? CommonOrderType.Limit : order.Data.OrderType == BitgetOrderType.Market ? CommonOrderType.Market: CommonOrderType.Other
            });
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<UserTrade>>> IBaseRestClient.GetOrderTradesAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentException(nameof(orderId) + " required for Bitget " + nameof(ISpotClient.GetOrderTradesAsync), nameof(orderId));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetOrderTradesAsync), nameof(symbol));

            var trades = await Trading.GetUserTradesAsync(symbol!, orderId, ct: ct).ConfigureAwait(false);
            if (!trades)
                return trades.As<IEnumerable<UserTrade>>(default);

            return trades.As(trades.Data.Select(x => new UserTrade
            {
                Fee = x.Fee,
                FeeAsset = x.FeeAsset,
                Id = x.TradeId,
                OrderId = orderId,
                Price = x.Price,
                Quantity = x.Quantity,
                Symbol = x.Symbol,
                Timestamp = x.Timestamp,
                SourceObject = x,
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetOpenOrdersAsync(string? symbol, CancellationToken ct)
        {
            var order = await Trading.GetOrdersAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.As<IEnumerable<Order>>(default);

            return order.As(order.Data.Select(x => new Order
            {
                Id = x.OrderId,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                Side = x.Side == BitgetOrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = x.Status == BitgetOrderStatus.Cancelled ? CommonOrderStatus.Canceled : x.Status == BitgetOrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = x.Symbol,
                Timestamp = x.CreateTime,
                Type = x.OrderType == BitgetOrderType.Limit ? CommonOrderType.Limit : x.OrderType == BitgetOrderType.Market ? CommonOrderType.Market : CommonOrderType.Other
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetClosedOrdersAsync(string? symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetClosedOrdersAsync), nameof(symbol));

            var order = await Trading.GetOrderHistoryAsync(symbol!, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.As<IEnumerable<Order>>(default);

            return order.As(order.Data.Select(x => new Order
            {
                Id = x.OrderId,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                Side = x.Side == BitgetOrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = x.Status == BitgetOrderStatus.Cancelled ? CommonOrderStatus.Canceled : x.Status == BitgetOrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = x.Symbol,
                Timestamp = x.CreateTime,
                Type = x.OrderType == BitgetOrderType.Limit ? CommonOrderType.Limit : x.OrderType == BitgetOrderType.Market ? CommonOrderType.Market : CommonOrderType.Other
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<OrderId>> IBaseRestClient.CancelOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentException(nameof(orderId) + " required for Bitget " + nameof(ISpotClient.CancelOrderAsync), nameof(orderId));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.CancelOrderAsync), nameof(symbol));

            var result = await Trading.CancelOrderAsync(symbol!, orderId, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(default);

            return result.As(new OrderId
            {
                Id = orderId,
                SourceObject = result.Data
            });
        }
        #endregion
    }
}

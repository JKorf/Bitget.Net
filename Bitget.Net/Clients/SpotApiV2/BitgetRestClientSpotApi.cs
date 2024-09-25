using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal partial class BitgetRestClientSpotApi : RestApiClient, IBitgetRestClientSpotApi, ISpotClient
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
        public IBitgetRestClientSpotApiShared SharedClient => this;

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
                { "X-CHANNEL-API-CODE", !string.IsNullOrEmpty(options.ChannelCode) ? options.ChannelCode! : baseClient._defaultChannelCode },
                { "locale", "en-US" }
            };
        }

        /// <inheritdoc />
        protected override IStreamMessageAccessor CreateAccessor() => new SystemTextJsonStreamMessageAccessor();
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer();

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BitgetAuthenticationProviderV2((BitgetApiCredentials)credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

        internal async Task<WebCallResult> SendAsync(string path, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var uri = new Uri(BaseAddress.AppendPath(path));
            var result = await SendRequestAsync<BitgetResponse>(uri, method, ct, parameters, signed, parameterPosition: parameterPosition, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.AsDatalessError(result.Error!);

            if (result.Data.Code != 0)
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.AsDataless();
        }

        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight, requestHeaders);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null) where T : class
        {
            var result = await base.SendAsync<BitgetResponse<T>>(baseAddress, definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return result.As<T>(default);

            if (result.Data.Code != 0)
                return result.AsError<T>(new ServerError(result.Data.Code, result.Data.Message!));

            return result.As<T>(result.Data.Data);
        }

        internal Task<WebCallResult> SendAsync(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null)
            => SendToAddressAsync(BaseAddress, definition, parameters, cancellationToken, weight, requestHeaders);

        internal async Task<WebCallResult> SendToAddressAsync(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null)
        {
            var result = await base.SendAsync<BitgetResponse>(baseAddress, definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return result.AsDataless();

            if (result.Data.Code != 0)
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message!));

            return result.AsDataless();
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders, IMessageAccessor accessor)
        {
            if (!accessor.IsJson)
                return new ServerError(accessor.GetOriginalString());

            var code = accessor.GetValue<string>(MessagePath.Get().Property("code"));
            var msg = accessor.GetValue<string>(MessagePath.Get().Property("msg"));
            if (msg == null)
                return new ServerError(accessor.GetOriginalString());

            if (code == null)
                return new ServerError(msg);

            return new ServerError(int.Parse(code), msg);
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
                                                       side == CommonOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                                                       type == CommonOrderType.Limit ? OrderType.Limit : OrderType.Market,
                                                       quantity,
                                                       type == CommonOrderType.Limit ? TimeInForce.GoodTillCanceled : TimeInForce.FillOrKill,
                                                       price,
                                                       clientOrderId,
                                                       ct: ct).ConfigureAwait(false);
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
            var symbols = await ExchangeData.GetSymbolsAsync(null, ct).ConfigureAwait(false);
            if (!symbols)
                return symbols.As<IEnumerable<Symbol>>(default);

            return symbols.As(symbols.Data.Select(x => new Symbol
            {
                Name = x.Symbol,
                MinTradeQuantity = x.MinOrderQuantity,
                PriceDecimals = x.PricePrecision,
                QuantityDecimals = x.QuantityPrecision,
                SourceObject = x
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<Ticker>> IBaseRestClient.GetTickerAsync(string symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));

            var ticker = await ExchangeData.GetTickersAsync(symbol, ct).ConfigureAwait(false);
            if (!ticker)
                return ticker.As<Ticker>(default);

            return ticker.As(new Ticker
            {
                HighPrice = ticker.Data.First().HighPrice,
                LastPrice = ticker.Data.First().LastPrice,
                LowPrice = ticker.Data.First().LowPrice,
                Price24H = ticker.Data.First().OpenPrice,
                SourceObject = ticker.Data.First(),
                Symbol = symbol,
                Volume = ticker.Data.First().Volume
            });
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Ticker>>> IBaseRestClient.GetTickersAsync(CancellationToken ct)
        {
            var tickers = await ExchangeData.GetTickersAsync(null, ct).ConfigureAwait(false);
            if (!tickers)
                return tickers.As<IEnumerable<Ticker>>(default);

            return tickers.As(tickers.Data.Select(x => new Ticker
            {
                HighPrice = x.HighPrice,
                LastPrice = x.LastPrice,
                LowPrice = x.LowPrice,
                Price24H = x.OpenPrice,
                SourceObject = x,
                Symbol = x.Symbol,
                Volume = x.Volume
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Kline>>> IBaseRestClient.GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime, DateTime? endTime, int? limit, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetKlinesAsync), nameof(symbol));

            var interval = (KlineInterval)(int)timespan.TotalSeconds;
            if (!Enum.IsDefined(typeof(KlineInterval), interval))
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
                OpenTime = x.OpenTime,
                SourceObject = x,
                Volume = x.Volume
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
            var balances = await Account.GetSpotBalancesAsync(ct: ct).ConfigureAwait(false);
            if (!balances)
                return balances.As<IEnumerable<Balance>>(default);

            return balances.As(balances.Data.Select(x => new Balance
            {
                Asset = x.Asset,
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
                Price = order.Data.First().Price,
                Quantity = order.Data.First().Quantity,
                QuantityFilled = order.Data.First().QuantityFilled,
                Side = order.Data.First().Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = order.Data.First().Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : order.Data.First().Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = symbol!,
                Timestamp = order.Data.First().CreateTime,
                Type = order.Data.First().OrderType == OrderType.Limit ? CommonOrderType.Limit : order.Data.First().OrderType == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other
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
                Fee = Math.Abs(x.Fees.TotalFee),
                FeeAsset = x.Fees.FeeAsset,
                Id = x.TradeId,
                OrderId = orderId,
                Price = x.Price,
                Quantity = x.Quantity,
                Symbol = x.Symbol,
                Timestamp = x.CreateTime,
                SourceObject = x,
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetOpenOrdersAsync(string? symbol, CancellationToken ct)
        {
            var order = await Trading.GetOpenOrdersAsync(symbol, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.As<IEnumerable<Order>>(default);

            return order.As(order.Data.Select(x => new Order
            {
                Id = x.OrderId,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                Side = x.Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = x.Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : x.Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = x.Symbol,
                Timestamp = x.CreateTime,
                Type = x.OrderType == OrderType.Limit ? CommonOrderType.Limit : x.OrderType == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other
            }));
        }

        /// <inheritdoc />
        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetClosedOrdersAsync(string? symbol, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bitget " + nameof(ISpotClient.GetClosedOrdersAsync), nameof(symbol));

            var order = await Trading.GetClosedOrdersAsync(symbol!, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.As<IEnumerable<Order>>(default);

            return order.As(order.Data.Select(x => new Order
            {
                Id = x.OrderId,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                Side = x.Side == OrderSide.Buy ? CommonOrderSide.Buy : CommonOrderSide.Sell,
                SourceObject = order.Data,
                Status = x.Status == OrderStatus.Canceled ? CommonOrderStatus.Canceled : x.Status == OrderStatus.Filled ? CommonOrderStatus.Filled : CommonOrderStatus.Active,
                Symbol = x.Symbol,
                Timestamp = x.CreateTime,
                Type = x.OrderType == OrderType.Limit ? CommonOrderType.Limit : x.OrderType == OrderType.Market ? CommonOrderType.Market : CommonOrderType.Other
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

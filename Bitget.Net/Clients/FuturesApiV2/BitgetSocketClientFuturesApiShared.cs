using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.FilterOptions;
using Bitget.Net.Enums;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetSocketClientFuturesApi : IBitgetSocketClientFuturesApiShared
    {
        public string Exchange => BitgetExchange.ExchangeName;
        public ApiType[] SupportedApiTypes { get; } = new[] { ApiType.PerpetualLinear, ApiType.PerpetualInverse, ApiType.DeliveryLinear, ApiType.DeliveryInverse };

        #region Ticker client
        SubscriptionOptions<SubscribeTickerRequest> ITickerSocketClient.SubscribeTickerOptions { get; } = new SubscriptionOptions<SubscribeTickerRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeResult<UpdateSubscription>> ITickerSocketClient.SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((ITickerSocketClient)this).SubscribeTickerOptions.ValidateRequest(Exchange, request, exchangeParameters, request.Symbol.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var productType = GetProductType(request.Symbol.ApiType, exchangeParameters);
            var result = await SubscribeToTickerUpdatesAsync(productType, symbol, update => handler(update.AsExchangeEvent(Exchange, new SharedSpotTicker(symbol, update.Data.LastPrice, update.Data.HighPrice, update.Data.LowPrice, update.Data.Volume))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        #endregion

        #region Trade client

        SubscriptionOptions<SubscribeTradeRequest> ITradeSocketClient.SubscribeTradeOptions { get; } = new SubscriptionOptions<SubscribeTradeRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((ITradeSocketClient)this).SubscribeTradeOptions.ValidateRequest(Exchange, request, exchangeParameters, request.Symbol.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var productType = GetProductType(request.Symbol.ApiType, exchangeParameters);
            var result = await SubscribeToTradeUpdatesAsync(productType, symbol, update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Book Ticker client

        SubscriptionOptions<SubscribeBookTickerRequest> IBookTickerSocketClient.SubscribeBookTickerOptions { get; } = new SubscriptionOptions<SubscribeBookTickerRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IBookTickerSocketClient)this).SubscribeBookTickerOptions.ValidateRequest(Exchange, request, exchangeParameters, request.Symbol.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var productType = GetProductType(request.Symbol.ApiType, exchangeParameters);
            var result = await SubscribeToTickerUpdatesAsync(productType, symbol, update => handler(update.AsExchangeEvent(Exchange, new SharedBookTicker(update.Data.BestAskPrice ?? 0, update.Data.BestAskQuantity ?? 0, update.Data.BestBidPrice ?? 0, update.Data.BestBidQuantity ?? 0))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Balance client
        SubscriptionOptions IBalanceSocketClient.SubscribeBalanceOptions { get; } = new SubscriptionOptions("SubscribeBalanceRequest", false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IBalanceSocketClient)this).SubscribeBalanceOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);
            var productType = GetProductType(apiType, exchangeParameters);
            var result = await SubscribeToBalanceUpdatesAsync(
                productType,
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x => new SharedBalance(x.MarginAsset, x.Available, x.Equity)))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Kline client
        SubscribeKlineOptions IKlineSocketClient.SubscribeKlineOptions { get; } = new SubscribeKlineOptions(false);
        async Task<ExchangeResult<UpdateSubscription>> IKlineSocketClient.SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var interval = (Enums.BitgetStreamKlineIntervalV2)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetStreamKlineIntervalV2), interval))
                return new ExchangeResult<UpdateSubscription>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IKlineSocketClient)this).SubscribeKlineOptions.ValidateRequest(Exchange, request, exchangeParameters, request.Symbol.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var productType = GetProductType(request.Symbol.ApiType, exchangeParameters);
            var result = await SubscribeToKlineUpdatesAsync(productType, symbol, interval, update =>
            {
                foreach(var item in update.Data)
                    handler(update.AsExchangeEvent(Exchange, new SharedKline(item.OpenTime, item.ClosePrice, item.HighPrice, item.LowPrice, item.OpenPrice, item.Volume)));
            }, ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Order Book client
        SubscribeOrderBookOptions IOrderBookSocketClient.SubscribeOrderBookOptions { get; } = new SubscribeOrderBookOptions(false, new[] { 1, 5, 15 });
        async Task<ExchangeResult<UpdateSubscription>> IOrderBookSocketClient.SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IOrderBookSocketClient)this).SubscribeOrderBookOptions.ValidateRequest(Exchange, request, exchangeParameters, request.Symbol.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var productType = GetProductType(request.Symbol.ApiType, exchangeParameters);
            var result = await SubscribeToOrderBookUpdatesAsync(productType, symbol, request.Limit ?? 15, update => handler(update.AsExchangeEvent(Exchange, new SharedOrderBook(update.Data.Asks, update.Data.Bids))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region Futures Order client
        SubscriptionOptions IFuturesOrderSocketClient.SubscribeFuturesOrderOptions { get; } = new SubscriptionOptions("SubscribeFuturesOrderRequest", true);
        async Task<ExchangeResult<UpdateSubscription>> IFuturesOrderSocketClient.SubscribeToFuturesOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IOrderBookSocketClient)this).SubscribeOrderBookOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var productType = GetProductType(apiType, exchangeParameters);
            var result = await SubscribeToOrderUpdatesAsync(
                productType,
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x =>
                    new SharedFuturesOrder(
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.OrderType == Enums.V2.OrderType.Limit ? SharedOrderType.Limit : x.OrderType == Enums.V2.OrderType.Market ? SharedOrderType.Market : SharedOrderType.Other,
                        x.Side == Enums.V2.OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                        x.Status == Enums.V2.OrderStatus.Canceled ? SharedOrderStatus.Canceled : (x.Status == Enums.V2.OrderStatus.Live || x.Status == Enums.V2.OrderStatus.New || x.Status == Enums.V2.OrderStatus.PartiallyFilled) ? SharedOrderStatus.Open : SharedOrderStatus.Filled,
                        x.CreateTime)
                    {
                        ClientOrderId = x.ClientOrderId?.ToString(),
                        Quantity = x.Quantity, // For a market buy order the OrderQuantity is the quote quantity
                        QuantityFilled = x.QuantityFilled,
                        TimeInForce = x.TimeInForce == Enums.V2.TimeInForce.ImmediateOrCancel ? SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.V2.TimeInForce.FillOrKill ? SharedTimeInForce.FillOrKill : SharedTimeInForce.GoodTillCanceled,
                        AveragePrice = x.AveragePrice,
                        UpdateTime = x.UpdateTime,
                        Fee = x.Fees.Any() ? x.Fees.Sum(f => f.Fee) : 0,
                        FeeAsset = x.Fees.FirstOrDefault()?.FeeAsset,
                        Price = x.Price,
                        LastTrade = x.LastTradeId == null ? null : new SharedUserTrade(x.Symbol, x.OrderId, x.LastTradeId, x.LastTradeQuantity ?? 0, x.LastTradeFillPrice ?? 0, x.LastTradeFillTime!.Value)
                        {
                            Fee = x.LastTradeFee,
                            FeeAsset = x.LastTradeFeeAsset,
                            Role = x.LastTradeRole == Enums.V2.Role.Taker ? SharedRole.Taker : SharedRole.Maker
                        }
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion

        #region User Trade client

        SubscriptionOptions IUserTradeSocketClient.SubscribeUserTradeOptions { get; } = new SubscriptionOptions("SubscribeUserTradeRequest", false);
        async Task<ExchangeResult<UpdateSubscription>> IUserTradeSocketClient.SubscribeToUserTradeUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IUserTradeSocketClient)this).SubscribeUserTradeOptions.ValidateRequest(Exchange, exchangeParameters, ApiType.Spot, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeResult<UpdateSubscription>(Exchange, validationError);

            var productType = GetProductType(apiType, exchangeParameters);
            var result = await SubscribeToUserTradeUpdatesAsync(
                productType,
                update => handler(update.AsExchangeEvent(Exchange, update.Data.Select(x =>
                    new SharedUserTrade(
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.TradeId.ToString(),
                        x.Quantity,
                        x.Price,
                        x.UpdateTime ?? x.CreateTime)
                    {
                        Fee = x.Fees.First().TotalFee,
                        FeeAsset = x.Fees.First().FeeAsset,
                        Role = x.Role == Enums.V2.Role.Maker ? SharedRole.Maker : SharedRole.Taker
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
        #endregion


        private BitgetProductTypeV2 GetProductType(ApiType? apiType, ExchangeParameters? exchangeParameters)
        {
            if (apiType == ApiType.PerpetualInverse || apiType == ApiType.DeliveryInverse)
            {
                return BitgetProductTypeV2.CoinFutures;
            }

            var productTypeStr = exchangeParameters!.GetValue<string>(Exchange, "ProductType");
            return (BitgetProductTypeV2)Enum.Parse(typeof(BitgetProductTypeV2), productTypeStr);
        }
    }
}

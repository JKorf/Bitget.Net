using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetSocketClientFuturesSharedApi
    {
        #region Subscribe To Futures Order Updates

        async Task<WebSocketResult<UpdateSubscription>> IFuturesOrderSocketClient.SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<DataEvent<SharedFuturesOrder[]>> handler, CancellationToken ct)
            => await SubscribeToFuturesOrderUpdatesAsync(request, x => handler(x.ToType<SharedFuturesOrder[]>(x.Data)), ct).ConfigureAwait(false);

        public SubscribeFuturesOrderOptions SubscribeFuturesOrderOptions { get; } = new SubscribeFuturesOrderOptions(_exchangeName, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<DataEvent<SharedFuturesOrderUpdate[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
            var result = await _api.SubscribeToOrderUpdatesAsync(
                productType,
                update => handler(update.ToType<SharedFuturesOrderUpdate[]>(update.Data.Select(x =>
                    new SharedFuturesOrderUpdate(
                        ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol),
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.OrderType == OrderType.Limit ? SharedOrderType.Limit : x.OrderType == OrderType.Market ? SharedOrderType.Market : SharedOrderType.Other,
                        ParseSide(x),
                        ParseOrderStatus(x.Status),
                        x.CreateTime)
                    {
                        ClientOrderId = x.ClientOrderId?.ToString(),
                        OrderQuantity = new SharedOrderQuantity(x.Quantity, x.QuoteQuantity, x.Quantity),
                        QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, contractQuantity: x.QuantityFilled),
                        TimeInForce = x.TimeInForce == TimeInForce.ImmediateOrCancel ? SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == TimeInForce.FillOrKill ? SharedTimeInForce.FillOrKill : SharedTimeInForce.GoodTillCanceled,
                        AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                        UpdateTime = x.UpdateTime,
#pragma warning disable CS0618 // Type or member is obsolete
                        Fee = Math.Abs(x.Fees.Any() ? x.Fees.Sum(f => f.Fee) : 0),
                        FeeAsset = x.Fees.FirstOrDefault()?.FeeAsset,
#pragma warning restore CS0618 // Type or member is obsolete
                        OrderPrice = x.Price,
                        Leverage = x.Leverage,
                        PositionSide = x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                        ReduceOnly = x.ReduceOnly,
                        StopLossPrice = x.StopLossPrice,
                        TakeProfitPrice = x.TakeProfitPrice,
                        LastTrade = x.LastTradeId == null ? null : 
                            new SharedUserTrade(
                                ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol), 
                                x.Symbol, 
                                x.OrderId, 
                                x.LastTradeId, 
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                new SharedOrderQuantity(x.LastTradeQuantity ?? 0), 
                                x.LastTradeFillPrice ?? 0, 
                                x.LastTradeFillTime!.Value)
                            {
                                Fee = Math.Abs(x.LastTradeFee),
                                FeeAsset = x.LastTradeFeeAsset,
                                Role = x.LastTradeRole == Role.Taker ? SharedRole.Taker : SharedRole.Maker,
                                ClientOrderId = x.ClientOrderId
                            }
                    }
                ).ToArray())),
                ct: ct).ConfigureAwait(false);

            return result;
        }

        #endregion

        private SharedOrderStatus ParseOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Canceled || status == OrderStatus.Rejected)
                return SharedOrderStatus.Canceled;
            if (status == OrderStatus.Initial || status == OrderStatus.Live || status == OrderStatus.New || status == OrderStatus.PartiallyFilled)
                return SharedOrderStatus.Open;
            if (status == OrderStatus.Filled)
                return SharedOrderStatus.Filled;

            return SharedOrderStatus.Unknown;
        }

        private SharedOrderSide ParseSide(BitgetFuturesOrderUpdate x)
        {
            if (x.TradeSide == TradeSide.Open)
                return x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell;

            if (x.TradeSide == TradeSide.Close)
                return x.Side == OrderSide.Buy ? SharedOrderSide.Sell : SharedOrderSide.Buy;

            return x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell;
        }
    }
}

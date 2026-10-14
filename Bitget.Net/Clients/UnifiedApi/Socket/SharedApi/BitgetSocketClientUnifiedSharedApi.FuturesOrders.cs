using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using static CryptoExchange.Net.SharedApis.SharedCapabilities;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetSocketClientUnifiedSharedApi
    {
        #region Place Futures Order

        public SharedFeeDeductionType FuturesFeeDeductionType => SharedFeeDeductionType.AddToCost;
        public SharedFeeAssetType FuturesFeeAssetType => SharedFeeAssetType.InputAsset;
        public SharedOrderType[] FuturesSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.LimitMaker, SharedOrderType.Market };
        public SharedTimeInForce[] FuturesSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        public SharedQuantitySupport FuturesSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset);

        async Task<IExchangeCallResult<SharedId>> IPlaceFuturesOrder.PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
            => await PlaceFuturesOrderAsync(request, ct).ConfigureAwait(false);

        public PlaceFuturesOrderOptions PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<QueryResult<SharedId>> PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var result = await _api.PlaceOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                (request.OrderType == SharedOrderType.Limit || request.OrderType == SharedOrderType.LimitMaker) ? OrderType.Limit : OrderType.Market,
                quantity: request.Quantity?.QuantityInBaseAsset ?? 0,
                price: request.Price,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId,
                positionSide: request.PositionSide == null ? null : request.PositionSide == SharedPositionSide.Long ? PositionSide.Long : PositionSide.Short,
                reduceOnly: request.ReduceOnly,
                tpTriggerPrice: request.TakeProfitPrice,
                slTriggerPrice: request.StopLossPrice,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return QueryResult.Fail<SharedId>(result);

            return QueryResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        #endregion

        #region Cancel Futures Order

        public CancelFuturesOrderOptions CancelFuturesOrderOptions { get; } = new CancelFuturesOrderOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> ICancelFuturesOrder.CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<QueryResult<SharedId>> CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.CancelOrderAsync(category, request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        #endregion

        #region Cancel Futures Order By Client Order Id

        public CancelFuturesOrderByClientOrderIdOptions CancelFuturesOrderByClientOrderIdOptions { get; } = new CancelFuturesOrderByClientOrderIdOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> ICancelFuturesOrderByClientOrderId.CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<QueryResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.CancelOrderAsync(
                category,
                clientOrderId: request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        #endregion


        #region Edit Futures Order

        public EditFuturesOrderOptions EditFuturesOrderOptions { get; } = new EditFuturesOrderOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> IEditFuturesOrder.EditFuturesOrderAsync(EditOrderRequest request, CancellationToken ct)
            => await EditFuturesOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<QueryResult<SharedId>> EditFuturesOrderAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.EditOrderAsync(
                category,
                request.SymbolName(FormatSymbol),
                orderId: request.OrderId,
                quantity: request.Quantity?.QuantityInBaseAsset,
                price: request.Price,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId));
        }

        #endregion

        #region Edit Futures Order By Client Order Id

        public EditFuturesOrderByClientOrderIdOptions EditFuturesOrderByClientOrderIdOptions { get; } = new EditFuturesOrderByClientOrderIdOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> IEditFuturesOrderByClientOrderId.EditFuturesOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
            => await EditFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<QueryResult<SharedId>> EditFuturesOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return QueryResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.EditOrderAsync(
                category,
                request.SymbolName(FormatSymbol),
                clientOrderId: request.OrderId,
                quantity: request.Quantity?.QuantityInBaseAsset,
                price: request.Price,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return QueryResult.Fail<SharedId>(order);

            return QueryResult.Ok(order, new SharedId(order.Data.OrderId));
        }

        #endregion

        #region Subscribe To Futures Order Updates

        public SubscribeFuturesOrderOptions SubscribeFuturesOrderOptions { get; } = new SubscribeFuturesOrderOptions(_exchangeName, true);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<DataEvent<SharedFuturesOrderUpdate[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToOrderUpdatesAsync(
                update =>
                {
                    var futuresOrders = update.Data.Where(x => x.Category != ProductCategory.Spot).ToList();
                    if (futuresOrders.Count == 0)
                        return;

                    handler(update.ToType(futuresOrders.Select(x => 
                        new SharedFuturesOrderUpdate(
                            ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol!,
                            x.OrderId,
                            ParseOrderType(x),
                            x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                            ParseOrderStatus(x),
                            x.CreateTime
                        )
                        {
                            AveragePrice = x.AveragePrice,
                            ClientOrderId = x.ClientOrderId,
                            Leverage = x.Leverage,
                            OrderPrice = x.Price == 0 ? null : x.Price,
                            PositionSide = x.PositionSide == PositionSide.Oneway ? null : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                            UpdateTime = x.UpdateTime,
                            TimeInForce = ParseTimeInForce(x),
                            ReduceOnly = x.ReduceOnly,
                            OrderQuantity = new SharedOrderQuantity(x.Quantity, x.QuoteQuantity == 0 ? null : x.QuoteQuantity),
                            QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled)
                        }
                    ).ToArray()));
                }
            , ct).ConfigureAwait(false);

            return result;         
        }

        private SharedOrderStatus ParseOrderStatus(BitgetUaOrder x)
        {
            if (x.Status == OrderStatus.New
                || x.Status == OrderStatus.Initial
                || x.Status == OrderStatus.Live
                || x.Status == OrderStatus.PartiallyFilled)
            {
                return SharedOrderStatus.Open;
            }

            if (x.Status == OrderStatus.Canceled
                || x.Status == OrderStatus.Rejected)
            {
                return SharedOrderStatus.Canceled;
            }

            if (x.Status == OrderStatus.Filled)
                return SharedOrderStatus.Filled;

            return SharedOrderStatus.Unknown;
        }

        private SharedTimeInForce? ParseTimeInForce(BitgetUaOrder x)
        {
            if (x.TimeInForce == TimeInForce.FillOrKill)
                return SharedTimeInForce.FillOrKill;
            if (x.TimeInForce == TimeInForce.GoodTillCanceled)
                return SharedTimeInForce.GoodTillCanceled;
            if (x.TimeInForce == TimeInForce.ImmediateOrCancel)
                return SharedTimeInForce.ImmediateOrCancel;

            return null;
        }

        private SharedOrderType ParseOrderType(BitgetUaOrder x)
        {
            if (x.OrderType == OrderType.Market)
                return SharedOrderType.Market;

            if (x.TimeInForce == TimeInForce.PostOnly)
                return SharedOrderType.LimitMaker;

            return SharedOrderType.Limit;
        }

        #endregion

    }
}

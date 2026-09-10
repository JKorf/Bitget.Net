using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using ContractType = Bitget.Net.Enums.V2.ContractType;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesSharedApi
    {
        #region Place Futures Trigger Order

        public PlaceFuturesTriggerOrderOptions PlaceFuturesTriggerOrderOptions { get; } = new PlaceFuturesTriggerOrderOptions(_exchangeName, false)
        {
            ParameterRuleOverrides = [
                RequestParameterRuleOverride<PlaceFuturesTriggerOrderRequest>.Required(x => x.PositionMode),
                RequestParameterRuleOverride<PlaceFuturesTriggerOrderRequest>.NotSupported(x => x.Leverage),
            ],
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                ExchangeParameterRule.Required("MarginAsset", "The margin asset to be used", "USDC", ["marginCoin"])
            ]
        };
        async Task<ICallResult<SharedId>> IPlaceFuturesTriggerOrder.PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
            => await PlaceFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
        {
            var (side, tradeSide) = GetTradeSide(request);
            var validationError = PlaceFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.Trading.PlaceTriggerOrderAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                request.Symbol!.GetSymbol(FormatSymbol),
                request.GetParamValue<string>(Exchange, "MarginAsset", "marginCoin")!,
                TriggerPlanType.Normal,
                request.MarginMode == SharedMarginMode.Isolated ? MarginMode.IsolatedMargin : MarginMode.CrossMargin,
                side,
                request.OrderPrice != null ? OrderType.Limit : OrderType.Market,
                orderPrice: request.OrderPrice,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                triggerPrice: request.TriggerPrice,
                tradeSide: tradeSide,
                clientOrderId: request.ClientOrderId,
                reduceOnly: request.ReduceOnly,
                //triggerPriceType: request.TriggerPriceType == null ? null : request.TriggerPriceType == SharedTriggerPriceType.LastPrice ? TriggerPriceType.LastPrice : TriggerPriceType.MarkPrice,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        #endregion

        #region Get Futures Trigger Order

        public GetFuturesTriggerOrderOptions GetFuturesTriggerOrderOptions { get; } = new GetFuturesTriggerOrderOptions(_exchangeName, true);
        async Task<ICallResult<SharedFuturesTriggerOrder>> IGetFuturesTriggerOrder.GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
            => await GetFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesTriggerOrder>> GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOpenTriggerOrdersAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                TriggerPlanTypeFilter.Trigger,
                orderId: request.OrderId).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesTriggerOrder>(orders);

            if (!orders.Data.Orders.Any())
            {
                orders = await _api.Trading.GetClosedTriggerOrdersAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                TriggerPlanTypeFilter.Trigger,
                orderId: request.OrderId).ConfigureAwait(false);
                if (!orders.Success)
                    return HttpResult.Fail<SharedFuturesTriggerOrder>(orders);
            }

            if (!orders.Data.Orders.Any())
                return HttpResult.Fail<SharedFuturesTriggerOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.Orders.Single();

            return HttpResult.Ok(orders, new SharedFuturesTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                order.OrderType == OrderType.Market ? SharedOrderType.Market : SharedOrderType.Limit,
                order.TradeSide == null ? null : order.TradeSide == TradeSide.Open ? SharedTriggerOrderDirection.Enter : SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order.Status),
                order.TriggerPrice ?? 0,
                null,
                order.CreateTime)
            {
                PlacedOrderId = order.OrderId,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.Quantity, contractQuantity: order.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, null, contractQuantity: order.QuantityFilled),
                UpdateTime = order.UpdateTime,
                PositionSide = order.PositionSide == PositionSide.Oneway ? null : order.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ClientOrderId = order.ClientOrderId
            });
        }

        #endregion

        private SharedTriggerOrderStatus ParseTriggerOrderStatus(TriggerOrderStatus? status)
        {
            if (status == TriggerOrderStatus.Executed)
                return SharedTriggerOrderStatus.Filled;

            if (status == TriggerOrderStatus.FailedExecute || status == TriggerOrderStatus.Canceled)
                return SharedTriggerOrderStatus.CanceledOrRejected;

            if (status == TriggerOrderStatus.Live || status == TriggerOrderStatus.Executing)
                return SharedTriggerOrderStatus.Active;

            return SharedTriggerOrderStatus.Unknown;
        }

        #region Cancel Futures Trigger Order

        public CancelFuturesTriggerOrderOptions CancelFuturesTriggerOrderOptions { get; } = new CancelFuturesTriggerOrderOptions(_exchangeName, true);
        async Task<ICallResult<SharedId>> ICancelFuturesTriggerOrder.CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelTriggerOrdersAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                orderIds: [new BitgetCancelOrderRequest { OrderId = request.OrderId }],
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(request.OrderId));
        }

        #endregion


        private (OrderSide, TradeSide?) GetTradeSide(PlaceFuturesTriggerOrderRequest request)
        {
            if (request.PositionMode == SharedPositionMode.OneWay)
            {
                // One way mode
                return
                    (request.PositionSide == SharedPositionSide.Long && request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Buy :
                    request.PositionSide == SharedPositionSide.Long && request.OrderDirection == SharedTriggerOrderDirection.Exit ? OrderSide.Sell :
                    request.PositionSide == SharedPositionSide.Short && request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Sell : OrderSide.Buy, null);
            }

            if (request.PositionSide == SharedPositionSide.Long)
            {
                // Hedge mode long
                if (request.OrderDirection == SharedTriggerOrderDirection.Enter)
                    return (OrderSide.Buy, TradeSide.Open);
                return (OrderSide.Buy, TradeSide.Close);
            }

            // Hedge mode short
            if (request.OrderDirection == SharedTriggerOrderDirection.Enter)
                return (OrderSide.Sell, TradeSide.Open);
            return (OrderSide.Sell, TradeSide.Close);
        }
    }
}

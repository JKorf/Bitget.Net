using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetRestClientSpotSharedApi
    {
        #region Place Spot Trigger Order

        public PlaceSpotTriggerOrderOptions PlaceSpotTriggerOrderOptions { get; } = new PlaceSpotTriggerOrderOptions(_exchangeName, true);
        async Task<ICallResult<SharedId>> IPlaceSpotTriggerOrder.PlaceSpotTriggerOrderAsync(PlaceSpotTriggerOrderRequest request, CancellationToken ct)
            => await PlaceSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> PlaceSpotTriggerOrderAsync(PlaceSpotTriggerOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.Trading.PlaceOrderAsync(
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderSide == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderPrice == null ? OrderType.Market : OrderType.Limit,
                timeInForce: request.OrderPrice == null ? TimeInForce.ImmediateOrCancel : TimeInForce.GoodTillCanceled,
                quantity: request.Quantity.QuantityInBaseAsset ?? request.Quantity.QuantityInQuoteAsset ?? 0,
                price: request.OrderPrice,
                clientOrderId: request.ClientOrderId,
                triggerPrice: request.TriggerPrice,                
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        #endregion

        #region Get Spot Trigger Order

        public GetSpotTriggerOrderOptions GetSpotTriggerOrderOptions { get; } = new GetSpotTriggerOrderOptions(_exchangeName, true);
        async Task<ICallResult<SharedSpotTriggerOrder>> IGetSpotTriggerOrder.GetSpotTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
            => await GetSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotTriggerOrder>> GetSpotTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrderAsync(request.OrderId).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders);

            if (!orders.Data.Any())
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.Single();
            return HttpResult.Ok(orders, new SharedSpotTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType, null),
                order.Side == OrderSide.Buy ? SharedTriggerOrderDirection.Enter: SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order.Status),
                order.TriggerPrice ?? 0,
                order.CreateTime)
            {
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? null : order.Quantity, order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.QuoteQuantityFilled),
                Fee = order.Fees?.NewFees?.TotalFee == null ? null : Math.Abs(order.Fees.NewFees.TotalFee),
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                UpdateTime = order.UpdateTime,
                ClientOrderId = order.ClientOrderId
            });
        }

        #endregion

        private SharedTriggerOrderStatus ParseTriggerOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Filled)
                return SharedTriggerOrderStatus.Filled;

            if (status == OrderStatus.Canceled || status == OrderStatus.Rejected)
                return SharedTriggerOrderStatus.CanceledOrRejected;

            if (status == OrderStatus.Live || status == OrderStatus.PartiallyFilled || status == OrderStatus.Initial || status == OrderStatus.New)
                return SharedTriggerOrderStatus.Active;

            return SharedTriggerOrderStatus.Unknown;
        }

        #region Cancel Spot Trigger Order

        public CancelSpotTriggerOrderOptions CancelSpotTriggerOrderOptions { get; } = new CancelSpotTriggerOrderOptions(_exchangeName, true);
        async Task<ICallResult<SharedId>> ICancelSpotTriggerOrder.CancelSpotTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelSpotTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelOrderAsync(request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        #endregion
    }
}

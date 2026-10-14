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

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetRestClientUnifiedSharedApi
    {

        #region Place Spot Order

        public SharedFeeDeductionType SpotFeeDeductionType => SharedFeeDeductionType.DeductFromOutput;
        public SharedFeeAssetType SpotFeeAssetType => SharedFeeAssetType.OutputAsset;
        public SharedOrderType[] SpotSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.LimitMaker, SharedOrderType.Market };
        public SharedTimeInForce[] SpotSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        public SharedQuantitySupport SpotSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.QuoteAsset,
                SharedQuantityType.BaseAsset);

        public string GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        async Task<IExchangeCallResult<SharedId>> IPlaceSpotOrder.PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
            => await PlaceSpotOrderAsync(request, ct).ConfigureAwait(false);

        public PlaceSpotOrderOptions PlaceSpotOrderOptions { get; } = new PlaceSpotOrderOptions(_exchangeName);
        public async Task<HttpResult<SharedId>> PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.Trading.PlaceOrderAsync(
                Enums.Uta.ProductCategory.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                (request.OrderType == SharedOrderType.Limit || request.OrderType == SharedOrderType.LimitMaker) ? OrderType.Limit : OrderType.Market,
                quantity: (request.OrderType == SharedOrderType.Market && request.Side == SharedOrderSide.Buy ? request.Quantity?.QuantityInQuoteAsset : request.Quantity?.QuantityInBaseAsset) ?? 0,
                price: request.Price,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        #endregion

        #region Get Spot Order

        public GetSpotOrderOptions GetSpotOrderOptions { get; } = new GetSpotOrderOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedSpotOrder>> IGetSpotOrder.GetSpotOrderAsync(GetOrderRequest request, CancellationToken ct)
            => await GetSpotOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotOrder>> GetSpotOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrderAsync(request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, orders.Data.Symbol),
                orders.Data.Symbol,
                orders.Data.OrderId.ToString(),
                ParseOrderType(orders.Data.OrderType, null),
                orders.Data.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(orders.Data.Status),
                orders.Data.CreateTime)
            {
                ClientOrderId = orders.Data.ClientOrderId,
                OrderPrice = orders.Data.Price == 0 ? null : orders.Data.Price,
                OrderQuantity = new SharedOrderQuantity(orders.Data.OrderType == OrderType.Market && orders.Data.Side == OrderSide.Buy ? null : orders.Data.Quantity, orders.Data.QuoteQuantity == 0 ? null : orders.Data.QuoteQuantity),
                QuantityFilled = new SharedOrderQuantity(orders.Data.QuantityFilled, orders.Data.QuoteQuantityFilled),
                AveragePrice = orders.Data.AveragePrice == 0 ? null : orders.Data.AveragePrice,
                UpdateTime = orders.Data.UpdateTime,
                TimeInForce = ParseTimeInForce(orders.Data)
            });
        }

        #endregion

        #region Get Open Spot Orders

        public GetOpenSpotOrdersOptions GetOpenSpotOrdersOptions { get; } = new GetOpenSpotOrdersOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedSpotOrder[]>> IGetOpenSpotOrders.GetOpenSpotOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
            => await GetOpenSpotOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotOrder[]>> GetOpenSpotOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = GetOpenSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            var orders = await _api.Trading.GetOpenOrdersAsync(Enums.Uta.ProductCategory.Spot, symbol, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType, null),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                OrderPrice = x.Price == 0 ? null : x.Price,
                OrderQuantity = new SharedOrderQuantity(x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity, x.QuoteQuantity == 0 ? null : x.QuoteQuantity),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                UpdateTime = x.UpdateTime,
                TimeInForce = ParseTimeInForce(x)
            }).ToArray());
        }

        #endregion

        #region Get Closed Spot Orders

        public GetSpotClosedOrdersOptions GetClosedSpotOrdersOptions { get; } = new GetSpotClosedOrdersOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90)
        };
        async Task<IExchangeCallResult<SharedSpotOrder[]>> IGetClosedSpotOrders.GetClosedSpotOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetClosedSpotOrdersAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotOrder[]>> GetClosedSpotOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetClosedSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var result = await _api.Trading.GetClosedOrdersAsync(
                Enums.Uta.ProductCategory.Spot,
                request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.Cursor == null ? null : Pagination.NextPageFromCursor(result.Data.Cursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxAge: TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x =>
                            new SharedSpotOrder(
                                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                                x.Symbol,
                                x.OrderId.ToString(),
                                ParseOrderType(x.OrderType, null),
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                ParseOrderStatus(x.Status),
                                x.CreateTime)
                            {
                                ClientOrderId = x.ClientOrderId,
                                OrderPrice = x.Price == 0 ? null : x.Price,
                                OrderQuantity = new SharedOrderQuantity(x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity, x.QuoteQuantity == 0 ? null : x.QuoteQuantity),
                                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),
                                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                                UpdateTime = x.UpdateTime,
                                TimeInForce = ParseTimeInForce(x)
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        #region Get Spot Order Trades

        public GetSpotOrderTradesOptions GetSpotOrderTradesOptions { get; } = new GetSpotOrderTradesOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedUserTrade[]>> IGetSpotOrderTrades.GetSpotOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
            => await GetSpotOrderTradesAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedUserTrade[]>> GetSpotOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = GetSpotOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var trades = await _api.Trading.GetUserTradesAsync(
                Enums.Uta.ProductCategory.Spot,
                orderId: request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!trades.Success)
                return HttpResult.Fail<SharedUserTrade[]>(trades);

            return HttpResult.Ok(trades, trades.Data.List.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                new SharedOrderQuantity(x.Quantity),
                x.Price,
                x.CreateTime)
            {
                Fee = x.FeeDetail.FirstOrDefault()?.Fee,
                FeeAsset = x.FeeDetail.FirstOrDefault()?.FeeAsset,
                Role = x.TradeScope == Role.Taker ? SharedRole.Taker : SharedRole.Maker
            }).ToArray());
        }

        #endregion

        #region Get Spot User Trade History

        public GetSpotUserTradeHistoryOptions GetSpotUserTradeHistoryOptions { get; } = new GetSpotUserTradeHistoryOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90)
        };
        async Task<IExchangeCallResult<SharedUserTrade[]>> IGetSpotUserTradeHistory.GetSpotUserTradeHistoryAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetSpotUserTradeHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedUserTrade[]>> GetSpotUserTradeHistoryAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetSpotUserTradeHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, maxPeriod: TimeSpan.FromDays(30));

            // Get data
            var result = await _api.Trading.GetUserTradesAsync(
                Enums.Uta.ProductCategory.Spot,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedUserTrade[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.Cursor == null ? null : Pagination.NextPageFromCursor(result.Data.Cursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxPeriod: TimeSpan.FromDays(30),
                maxAge: TimeSpan.FromDays(90));


            var symbolName = request.SymbolName(FormatSymbol);
            return HttpResult.Ok(result,
                        ExchangeHelpers.ApplyFilter(result.Data.List, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                        .Where(x => x.Symbol == symbolName)
                        .Select(x =>
                           new SharedUserTrade(
                               ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                               x.Symbol,
                               x.OrderId,
                               x.TradeId,
                               x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                               new SharedOrderQuantity(x.Quantity),
                               x.Price,
                               x.CreateTime)
                           {
                               Fee = x.FeeDetail.FirstOrDefault()?.Fee,
                               FeeAsset = x.FeeDetail.FirstOrDefault()?.FeeAsset,
                               Role = x.TradeScope == Role.Taker ? SharedRole.Taker : SharedRole.Maker
                           })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        #region Cancel Spot Order

        public CancelSpotOrderOptions CancelSpotOrderOptions { get; } = new CancelSpotOrderOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedId>> ICancelSpotOrder.CancelSpotOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelSpotOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelSpotOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelOrderAsync(request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
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

        private SharedOrderType ParseOrderType(OrderType type, TimeInForce? tif)
        {
            if (type == OrderType.Market) return SharedOrderType.Market;
            if (type == OrderType.Limit && tif == TimeInForce.PostOnly) return SharedOrderType.LimitMaker;
            if (type == OrderType.Limit) return SharedOrderType.Limit;

            return SharedOrderType.Other;
        }

        private TimeInForce GetTimeInForce(SharedOrderType type, SharedTimeInForce? tif)
        {
            if (type == SharedOrderType.LimitMaker) return TimeInForce.PostOnly;
            if (type == SharedOrderType.Market) return TimeInForce.FillOrKill;
            if (tif == SharedTimeInForce.ImmediateOrCancel) return TimeInForce.ImmediateOrCancel;
            if (tif == SharedTimeInForce.FillOrKill) return TimeInForce.FillOrKill;
            if (tif == SharedTimeInForce.GoodTillCanceled) return TimeInForce.GoodTillCanceled;

            return TimeInForce.GoodTillCanceled;
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

        #region Get Spot Order By Client Order Id

        public GetSpotOrderByClientOrderIdOptions GetSpotOrderByClientOrderIdOptions { get; } = new GetSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedSpotOrder>> IGetSpotOrderByClientOrderId.GetSpotOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
            => await GetSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotOrder>> GetSpotOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetSpotOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrderAsync(clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, orders.Data.Symbol),
                orders.Data.Symbol,
                orders.Data.OrderId.ToString(),
                ParseOrderType(orders.Data.OrderType, null),
                orders.Data.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(orders.Data.Status),
                orders.Data.CreateTime)
            {
                ClientOrderId = orders.Data.ClientOrderId,
                OrderPrice = orders.Data.Price == 0 ? null : orders.Data.Price,
                OrderQuantity = new SharedOrderQuantity(orders.Data.OrderType == OrderType.Market && orders.Data.Side == OrderSide.Buy ? null : orders.Data.Quantity, orders.Data.QuoteQuantity == 0 ? null : orders.Data.QuoteQuantity),
                QuantityFilled = new SharedOrderQuantity(orders.Data.QuantityFilled, orders.Data.QuoteQuantityFilled),
                AveragePrice = orders.Data.AveragePrice == 0 ? null : orders.Data.AveragePrice,
                UpdateTime = orders.Data.UpdateTime,
                TimeInForce = ParseTimeInForce(orders.Data)
            });
        }

        #endregion

        #region Cancel Spot Order By Client Order Id

        public CancelSpotOrderByClientOrderIdOptions CancelSpotOrderByClientOrderIdOptions { get; } = new CancelSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedId>> ICancelSpotOrderByClientOrderId.CancelSpotOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelSpotOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelSpotOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelOrderAsync(
                clientOrderId: request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        #endregion

        #region Cancel All Spot Orders

        public CancelAllSpotOrdersOptions CancelAllSpotOrdersOptions { get; } = new CancelAllSpotOrdersOptions(_exchangeName);
        async Task<IExchangeCallResult> ICancelAllSpotOrders.CancelAllSpotOrdersAsync(CancelAllOrdersRequest request, CancellationToken ct)
            => await CancelAllSpotOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult> CancelAllSpotOrdersAsync(CancelAllOrdersRequest request, CancellationToken ct)
        {
            var validationError = CancelAllSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail(Exchange, validationError);

            var order = await _api.Trading.CancelAllOrdersAsync(Enums.Uta.ProductCategory.Spot, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail(order);

            return HttpResult.Ok(order);
        }

        #endregion

        #region Cancel All Spot Orders

        public CancelAllSpotSymbolOrdersOptions CancelAllSpotSymbolOrdersOptions { get; } = new CancelAllSpotSymbolOrdersOptions(_exchangeName, true);
        async Task<IExchangeCallResult> ICancelAllSpotSymbolOrders.CancelAllSpotSymbolOrdersAsync(CancelAllSymbolOrdersRequest request, CancellationToken ct)
            => await CancelAllSpotSymbolOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult> CancelAllSpotSymbolOrdersAsync(CancelAllSymbolOrdersRequest request, CancellationToken ct)
        {
            var validationError = CancelAllSpotSymbolOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail(Exchange, validationError);

            var order = await _api.Trading.CancelAllOrdersAsync(Enums.Uta.ProductCategory.Spot, request.SymbolName(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail(order);

            return HttpResult.Ok(order);
        }

        #endregion

        #region Edit Spot Order

        public EditSpotOrderOptions EditSpotOrderOptions { get; } = new EditSpotOrderOptions(_exchangeName);
        async Task<IExchangeCallResult<SharedId>> IEditSpotOrder.EditSpotOrderAsync(EditOrderRequest request, CancellationToken ct)
            => await EditSpotOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> EditSpotOrderAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.EditOrderAsync(
                Enums.Uta.ProductCategory.Spot,
                request.SymbolName(FormatSymbol),
                orderId: request.OrderId,
                quantity: request.Quantity?.QuantityInBaseAsset,
                price: request.Price,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId));
        }

        #endregion

        #region Edit Spot Order By Client Order Id

        public EditSpotOrderByClientOrderIdOptions EditSpotOrderByClientOrderIdOptions { get; } = new EditSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedId>> IEditSpotOrderByClientOrderId.EditSpotOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
            => await EditSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> EditSpotOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditSpotOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.EditOrderAsync(
                Enums.Uta.ProductCategory.Spot,
                request.SymbolName(FormatSymbol),
                clientOrderId: request.OrderId,
                quantity: request.Quantity?.QuantityInBaseAsset,
                price: request.Price,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId));
        }

        #endregion

    }
}

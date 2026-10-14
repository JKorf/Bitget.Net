using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
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
        public async Task<HttpResult<SharedId>> PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = PlaceFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var result = await _api.Trading.PlaceOrderAsync(
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
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        #endregion

        #region Get Futures Order

        public GetFuturesOrderOptions GetFuturesOrderOptions { get; } = new GetFuturesOrderOptions(_exchangeName, true)
        {
        };
        async Task<IExchangeCallResult<SharedFuturesOrder>> IGetFuturesOrder.GetFuturesOrderAsync(GetOrderRequest request, CancellationToken ct)
            => await GetFuturesOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesOrder>> GetFuturesOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrderAsync(request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, orders.Data.Symbol),
                orders.Data.Symbol,
                orders.Data.OrderId.ToString(),
                ParseOrderType(orders.Data.OrderType, null),
                orders.Data.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(orders.Data.Status),
                orders.Data.CreateTime)
            {
                ClientOrderId = orders.Data.ClientOrderId,
                OrderPrice = orders.Data.Price == 0 ? null : orders.Data.Price,
                TimeInForce = ParseTimeInForce(orders.Data),
                OrderQuantity = new SharedOrderQuantity(orders.Data.Quantity, orders.Data.QuoteQuantityFilled),
                QuantityFilled = new SharedOrderQuantity(orders.Data.QuantityFilled, orders.Data.QuoteQuantityFilled),
                AveragePrice = orders.Data.AveragePrice == 0 ? null : orders.Data.AveragePrice,
                UpdateTime = orders.Data.UpdateTime,
                PositionSide = orders.Data.PositionSide == null ? null : orders.Data.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = orders.Data.ReduceOnly,
                TakeProfitPrice = orders.Data.TakeProfit,
                StopLossPrice = orders.Data.StopLoss                
            });
        }

        #endregion

        #region Get Open Futures Orders

        public GetOpenFuturesOrdersOptions GetOpenFuturesOrdersOptions { get; } = new GetOpenFuturesOrdersOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedFuturesOrder[]>> IGetOpenFuturesOrders.GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
            => await GetOpenFuturesOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesOrder[]>> GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = GetOpenFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            var category = GetCategory(request);
            var orders = await _api.Trading.GetOpenOrdersAsync(category, symbol, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.List.Select(x => new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType, null),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                OrderPrice = x.Price == 0 ? null : x.Price,
                TimeInForce = ParseTimeInForce(x),
                OrderQuantity = new SharedOrderQuantity(x.Quantity, x.QuoteQuantityFilled),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionSide == null ? null : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
                TakeProfitPrice = x.TakeProfit,
                StopLossPrice = x.StopLoss
            }).ToArray());
        }

        #endregion

        #region Get Closed Futures Orders

        public GetFuturesClosedOrdersOptions GetClosedFuturesOrdersOptions { get; } = new GetFuturesClosedOrdersOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90),
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedFuturesOrder[]>> IGetClosedFuturesOrders.GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetClosedFuturesOrdersAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesOrder[]>> GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetClosedFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var category = GetCategory(request);
            var result = await _api.Trading.GetClosedOrdersAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesOrder[]>(result);

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
                            new SharedFuturesOrder(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                                x.Symbol,
                                x.OrderId.ToString(),
                                ParseOrderType(x.OrderType, null),
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                ParseOrderStatus(x.Status),
                                x.CreateTime)
                            {
                                ClientOrderId = x.ClientOrderId,
                                OrderPrice = x.Price == 0 ? null : x.Price,
                                TimeInForce = ParseTimeInForce(x),
                                OrderQuantity = new SharedOrderQuantity(x.Quantity, x.QuoteQuantityFilled),
                                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),
                                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                                UpdateTime = x.UpdateTime,
                                PositionSide = x.PositionSide == null ? null : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                                ReduceOnly = x.ReduceOnly,
                                TakeProfitPrice = x.TakeProfit,
                                StopLossPrice = x.StopLoss
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        #region Get Futures Order Trades

        public GetFuturesOrderTradesOptions GetFuturesOrderTradesOptions { get; } = new GetFuturesOrderTradesOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedUserTrade[]>> IGetFuturesOrderTrades.GetFuturesOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
            => await GetFuturesOrderTradesAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedUserTrade[]>> GetFuturesOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var category = GetCategory(request);
            var trades = await _api.Trading.GetUserTradesAsync(
                category,
                orderId: request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!trades.Success)
                return HttpResult.Fail<SharedUserTrade[]>(trades);

            return HttpResult.Ok(trades, trades.Data.List.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
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

        #region Get Futures User Trade History

        public GetFuturesUserTradeHistoryOptions GetFuturesUserTradeHistoryOptions { get; } = new GetFuturesUserTradeHistoryOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90),
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedUserTrade[]>> IGetFuturesUserTradeHistory.GetFuturesUserTradeHistoryAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetFuturesUserTradeHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedUserTrade[]>> GetFuturesUserTradeHistoryAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetFuturesUserTradeHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, maxPeriod: TimeSpan.FromDays(30));

            // Get data
            var category = GetCategory(request);
            var result = await _api.Trading.GetUserTradesAsync(
                category,
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
                               ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
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

        #region Cancel Futures Order

        public CancelFuturesOrderOptions CancelFuturesOrderOptions { get; } = new CancelFuturesOrderOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedId>> ICancelFuturesOrder.CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesOrderAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await _api.Trading.CancelOrderAsync(request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        #endregion

        #region Get Futures Order By Client Order Id

        public GetFuturesOrderByClientOrderIdOptions GetFuturesOrderByClientOrderIdOptions { get; } = new GetFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedFuturesOrder>> IGetFuturesOrderByClientOrderId.GetFuturesOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
            => await GetFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesOrder>> GetFuturesOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesOrder>(Exchange, validationError);

            var orders = await _api.Trading.GetOrderAsync(clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedFuturesOrder>(orders);

            return HttpResult.Ok(orders, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, orders.Data.Symbol),
                orders.Data.Symbol,
                orders.Data.OrderId.ToString(),
                ParseOrderType(orders.Data.OrderType, null),
                orders.Data.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(orders.Data.Status),
                orders.Data.CreateTime)
            {
                ClientOrderId = orders.Data.ClientOrderId,
                OrderPrice = orders.Data.Price == 0 ? null : orders.Data.Price,
                TimeInForce = ParseTimeInForce(orders.Data),
                OrderQuantity = new SharedOrderQuantity(orders.Data.Quantity, orders.Data.QuoteQuantityFilled),
                QuantityFilled = new SharedOrderQuantity(orders.Data.QuantityFilled, orders.Data.QuoteQuantityFilled),
                AveragePrice = orders.Data.AveragePrice == 0 ? null : orders.Data.AveragePrice,
                UpdateTime = orders.Data.UpdateTime,
                PositionSide = orders.Data.PositionSide == null ? null : orders.Data.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = orders.Data.ReduceOnly,
                TakeProfitPrice = orders.Data.TakeProfit,
                StopLossPrice = orders.Data.StopLoss
            });
        }

        #endregion

        #region Cancel Futures Order By Client Order Id

        public CancelFuturesOrderByClientOrderIdOptions CancelFuturesOrderByClientOrderIdOptions { get; } = new CancelFuturesOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<IExchangeCallResult<SharedId>> ICancelFuturesOrderByClientOrderId.CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
            => await CancelFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
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

        #region Cancel All Futures Orders

        public CancelAllFuturesOrdersOptions CancelAllFuturesOrdersOptions { get; } = new CancelAllFuturesOrdersOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult> ICancelAllFuturesOrders.CancelAllFuturesOrdersAsync(CancelAllOrdersRequest request, CancellationToken ct)
            => await CancelAllFuturesOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult> CancelAllFuturesOrdersAsync(CancelAllOrdersRequest request, CancellationToken ct)
        {
            var validationError = CancelAllFuturesOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.Trading.CancelAllOrdersAsync(category, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail(order);

            return HttpResult.Ok(order);
        }

        #endregion

        #region Cancel All Futures Orders

        public CancelAllFuturesSymbolOrdersOptions CancelAllFuturesSymbolOrdersOptions { get; } = new CancelAllFuturesSymbolOrdersOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult> ICancelAllFuturesSymbolOrders.CancelAllFuturesSymbolOrdersAsync(CancelAllSymbolOrdersRequest request, CancellationToken ct)
            => await CancelAllFuturesSymbolOrdersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult> CancelAllFuturesSymbolOrdersAsync(CancelAllSymbolOrdersRequest request, CancellationToken ct)
        {
            var validationError = CancelAllFuturesSymbolOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.Trading.CancelAllOrdersAsync(category, request.SymbolName(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail(order);

            return HttpResult.Ok(order);
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

        public async Task<HttpResult<SharedId>> EditFuturesOrderAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditFuturesOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.Trading.EditOrderAsync(
                category,
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

        #region Edit Futures Order By Client Order Id

        public EditFuturesOrderByClientOrderIdOptions EditFuturesOrderByClientOrderIdOptions { get; } = new EditFuturesOrderByClientOrderIdOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> IEditFuturesOrderByClientOrderId.EditFuturesOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
            => await EditFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> EditFuturesOrderByClientOrderIdAsync(EditOrderRequest request, CancellationToken ct)
        {
            var validationError = EditFuturesOrderByClientOrderIdOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.Trading.EditOrderAsync(
                category,
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

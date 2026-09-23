using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.Objects.Errors;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApiTrading : IBitgetRestClientFuturesApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiTrading(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPosition[]>> GetPositionAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/position/single-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPosition[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPosition[]>> GetPositionsAsync(BitgetProductTypeV2 productType, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/position/all-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPosition[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionHistory>> GetPositionHistoryAsync(BitgetProductTypeV2? productType = null, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/position/history-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionHistory>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceOrderAsync(
            BitgetProductTypeV2 productType, 
            string symbol, 
            string marginAsset,
            OrderSide side,
            OrderType type,
            MarginMode marginMode,
            decimal quantity,
            decimal? price = null,
            TimeInForce? timeInForce = null,
            TradeSide? tradeSide = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            CancellationToken ct = default)
        {
            if (tradeSide.HasValue && (tradeSide != TradeSide.Open && tradeSide != TradeSide.Close))
                throw new ArgumentException("Trade side should be either Open or Close if provided", nameof(tradeSide));

            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("side", side);
            parameters.Add("orderType", type);
            parameters.Add("marginMode", marginMode);
            parameters.Add("size", quantity);
            parameters.Add("price", price);
            parameters.Add("force", timeInForce);
            parameters.Add("tradeSide", tradeSide);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("reduceOnly", reduceOnly == null ? null : reduceOnly == true ? "YES" : "NO");
            parameters.Add("presetStopSurplusPrice", takeProfitPrice);
            parameters.Add("presetStopLossPrice", stopLossPrice);
            parameters.Add("presetStopSurplusExecutePrice", takeProfitLimitPrice);
            parameters.Add("presetStopLossExecutePrice", stopLossLimitPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<CallResult<BitgetOrderId>[]>> PlaceMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            MarginMode marginMode,
            IEnumerable<BitgetFuturesPlaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("marginMode", marginMode);
            parameters.Add("orderList", orders.ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var resultData = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            if (!resultData.Success)
                return HttpResult.Fail<CallResult<BitgetOrderId>[]>(resultData);

            var result = new List<CallResult<BitgetOrderId>>();
            foreach (var item in resultData.Data.Success)
                result.Add(CallResult<BitgetOrderId>.Ok(item!));

            foreach (var item in resultData.Data.Failed)
                result.Add(CallResult<BitgetOrderId>.Fail(new ServerError(item.ErrorCode!.Value.ToString(), _baseClient.GetErrorInfo(item.ErrorCode!.Value, item.ErrorMessage!))));

            if (result.All(x => !x.Success))
                return HttpResult.Fail(resultData, new ServerError(new ErrorInfo(ErrorType.AllOrdersFailed, "All orders failed")), result.ToArray());

            return HttpResult.Ok(resultData, result.ToArray());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> EditOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            string? newClientOrderId = null,
            decimal? newPrice = null,
            decimal? newQuantity = null,
            decimal? newTakeProfit = null,
            decimal? newStopLossPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("newClientOid", newClientOrderId);
            parameters.Add("newPrice", newPrice);
            parameters.Add("newSize", newQuantity);
            parameters.Add("newPresetStopSurplusPrice", newTakeProfit);
            parameters.Add("newPresetStopLossPrice", newStopLossPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/modify-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> CancelOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            IEnumerable<BitgetCancelOrderRequest> orders,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("orderIdList", orders.ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/batch-cancel-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelAllOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset?.ToUpperInvariant());

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/cancel-all-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesOrder>> GetOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/detail", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesOrders>> GetOpenOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            OrderStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("status", status);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/orders-pending", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetFuturesOrders>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return result;

            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesOrder>();

            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesOrders>> GetClosedOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/orders-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetFuturesOrders>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return result;
            
            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesOrder>();

            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesUserTrades>> GetUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesUserTrades>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesUserTrades>> GetHistoricalUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/fill-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesUserTrades>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> ClosePositionsAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            PositionSide? side = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("holdSide", side);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/close-positions", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceTpSlOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            PlanType planType,
            decimal? quantity,
            decimal triggerPrice,
            decimal? orderPrice = null,
            TriggerPriceType? triggerPriceType = null,
            PositionSide? hedgeModePositionSide = null,
            OrderSide? oneWaySide = null,
            decimal? trailingStopRate = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            if ((oneWaySide != null && hedgeModePositionSide != null)
                || (oneWaySide == null && hedgeModePositionSide == null))
            {
                throw new ArgumentException("Either hedgeModePositionSide (for two way position mode) or oneWaySide (for one way position mode) should be provided");
            }

            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType); 
            parameters.Add("planType", planType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("size", quantity);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("holdSide", hedgeModePositionSide);
            parameters.Add("holdSide", oneWaySide);
            parameters.Add("triggerType", triggerPriceType);
            parameters.Add("rangeRate", trailingStopRate);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("executePrice", orderPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/place-tpsl-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceTriggerOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            TriggerPlanType planType,
            MarginMode marginMode,
            OrderSide side,
            OrderType orderType,
            decimal quantity,
            decimal triggerPrice,
            decimal? orderPrice = null,
            TriggerPriceType? triggerPriceType = null,
            TradeSide? tradeSide = null,
            decimal? trailingStopRate = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            decimal? takeProfitTriggerPrice = null,
            decimal? takeProfitOrderPrice = null,
            TriggerPriceType? takeProfitPriceType = null,
            decimal? stopLossTriggerPrice = null,
            decimal? stopLossOrderPrice = null,
            TriggerPriceType? stopLossPriceType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("planType", planType);
            parameters.Add("marginMode", marginMode);
            parameters.Add("side", side);
            parameters.Add("orderType", orderType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("size", quantity);
            parameters.Add("price", orderPrice);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("triggerType", triggerPriceType ?? TriggerPriceType.LastPrice);
            parameters.Add("callbackRatio", trailingStopRate);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("reduceOnly", reduceOnly == null ? null : reduceOnly == true ? "YES" : "NO");
            parameters.Add("tradeSide", tradeSide);
            parameters.Add("stopSurplusTriggerPrice", takeProfitTriggerPrice);
            parameters.Add("stopSurplusExecutePrice", takeProfitOrderPrice);
            parameters.Add("stopSurplusTriggerType", takeProfitPriceType);
            parameters.Add("stopLossTriggerPrice", stopLossTriggerPrice);
            parameters.Add("stopLossExecutePrice", stopLossOrderPrice);
            parameters.Add("stopLossTriggerType", stopLossPriceType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/place-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            BitgetProductTypeV2 productType,
            string triggerOrderId,
            TriggerPlanType planType,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("planOrderId", triggerOrderId);
            parameters.Add("productType", productType);
            parameters.Add("planType", planType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/plan-sub-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetTriggerSubOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> EditTriggerOrderAsync(
            BitgetProductTypeV2 productType,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? newQuantity = null,
            decimal? newPrice = null,
            decimal? newTrailingStopRate = null,
            decimal? newTriggerPrice = null,
            TriggerPriceType? newTriggerType = null,
            decimal? newTakeProfitTriggerPrice = null,
            decimal? newTakeProfitOrderPrice = null,
            TriggerPriceType? newTakeProfitPriceType = null,
            decimal? newStopLossTriggerPrice = null,
            decimal? newStopLossOrderPrice = null,
            TriggerPriceType? newStopLossPriceType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("size", newQuantity);
            parameters.Add("price", newPrice);
            parameters.Add("triggerPrice", newTriggerPrice);
            parameters.Add("triggerType", newTriggerType);
            parameters.Add("callbackRatio", newTrailingStopRate);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("orderId", orderId);
            parameters.Add("stopSurplusTriggerPrice", newTakeProfitTriggerPrice);
            parameters.Add("stopSurplusExecutePrice", newTakeProfitOrderPrice);
            parameters.Add("stopSurplusTriggerType", newTakeProfitPriceType);
            parameters.Add("stopLossTriggerPrice", newStopLossTriggerPrice);
            parameters.Add("stopLossExecutePrice", newStopLossOrderPrice);
            parameters.Add("stopLossTriggerType", newStopLossPriceType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/modify-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> EditTpSlOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? newTriggerPrice = null,
            TriggerPriceType? newTriggerType = null,
            decimal? newOrderPrice = null,
            decimal? newQuantity = null,
            decimal? newTrailingStopRate = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("productType", productType);
            parameters.Add("size", newQuantity);
            parameters.Add("executePrice", newOrderPrice);
            parameters.Add("triggerPrice", newTriggerPrice);
            parameters.Add("triggerType", newTriggerType);
            parameters.Add("rangeRate", newTrailingStopRate);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("orderId", orderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/modify-tpsl-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesTriggerOrders>> GetOpenTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            TriggerPlanTypeFilter planType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            string? idLessThan = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("planType", planType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/orders-plan-pending", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesTriggerOrders>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesTriggerOrders>> GetClosedTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            TriggerPlanTypeFilter planType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            ClosedPlanFilter? status = null,
            string? idLessThan = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("planType", planType);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("planStatus", status);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/order/orders-plan-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetFuturesTriggerOrders>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return result;

            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesTriggerOrder>();

            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            CancelTriggerPlanTypeFilter? planType = null,
            string? symbol = null,
            string? marginCoin = null,
            IEnumerable<BitgetCancelOrderRequest>? orderIds = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("planType", planType);
            parameters.Add("symbol", symbol);
            parameters.AddArray("orderIdList", orderIds == null ? null : orderIds.ToArray()!);
            parameters.Add("marginCoin", marginCoin);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/cancel-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #region Set Position Tp Sl

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionTpSl[]>> SetPositionTpSlAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, PositionSide holdSide, decimal? tpTriggerPrice = null, decimal? tpTriggerQuantity = null, TriggerPriceType? tpTriggerType = null, decimal? tpLimitPrice = null, decimal? slTriggerPrice = null, decimal? slTriggerQuantity = null, TriggerPriceType? slTriggerType = null, decimal? slLimitPrice = null, SelfTradePreventionMode? stpMode = null, string? tpClientOrderId = null, string? slClientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("holdSide", holdSide);
            parameters.Add("stopSurplusTriggerPrice", tpTriggerPrice);
            parameters.Add("stopSurplusSize", tpTriggerQuantity);
            parameters.Add("stopSurplusTriggerType", tpTriggerType);
            parameters.Add("stopSurplusExecutePrice", tpLimitPrice);
            parameters.Add("stopLossTriggerPrice", slTriggerPrice);
            parameters.Add("stopLossSize", slTriggerQuantity);
            parameters.Add("stopLossTriggerType", slTriggerType);
            parameters.Add("stopLossExecutePrice", slLimitPrice);
            parameters.Add("stpMode", stpMode);
            parameters.Add("stopSurplusClientOid", tpClientOrderId);
            parameters.Add("stopLossClientOid", slClientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/order/place-pos-tpsl", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetPositionTpSl[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.Objects.Errors;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            TimeInForce timeInForce,
            decimal? price = null,
            string? clientOrderId = null,
            decimal? triggerPrice = null,
            TakeProfitStopLossType? tpslType = null,
            SelfTradePreventionMode? stpMode = null,
            decimal? presetTakeProfitPrice = null,
            decimal? executeTakeProfitPrice = null,
            decimal? presetStopLossPrice = null,
            decimal? executeStopLossPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("side", side);
            parameters.Add("orderType", type);
            parameters.Add("force", timeInForce);
            parameters.Add("size", quantity);
            parameters.Add("price", price);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("tpslType", tpslType);
            parameters.Add("stpMode", stpMode);
            parameters.Add("presetTakeProfitPrice", presetTakeProfitPrice);
            parameters.Add("executeTakeProfitPrice", executeTakeProfitPrice);
            parameters.Add("presetStopLossPrice", presetStopLossPrice);
            parameters.Add("executeStopLossPrice", executeStopLossPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);            
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<CallResult<BitgetOrderId>[]>> PlaceMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetPlaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/batch-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var resultData = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            if (!resultData.Success)
                return HttpResult.Fail<CallResult<BitgetOrderId>[]>(resultData);

            var result = new List<CallResult<BitgetOrderId>>();
            foreach (var item in resultData.Data.Success)
                result.Add(CallResult<BitgetOrderId>.Ok(item!));

            foreach (var item in resultData.Data.Failed)
                result.Add(CallResult<BitgetOrderId>.Fail(new ServerError(item.ErrorCode?.ToString()!, _baseClient.GetErrorInfo(item.ErrorCode?.ToString() ?? string.Empty, item.ErrorMessage!))));

            if (result.All(x => !x.Success))
                return HttpResult.Fail(resultData, new ServerError(new ErrorInfo(ErrorType.AllOrdersFailed, "All orders failed")), result.ToArray());

            return HttpResult.Ok(resultData, result.ToArray());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> CancelReplaceOrderAsync(
            string? orderId,
            string? clientOrderId,
            string symbol,
            decimal quantity,
            decimal price,
            string? newClientOrderId = null,
            decimal? presetTakeProfitPrice = null,
            decimal? executeTakeProfitPrice = null,
            decimal? presetStopLossPrice = null,
            decimal? executeStopLossPrice = null,
            CancellationToken ct = default)
        {
            if ((orderId == null) == (clientOrderId == null))
                throw new ArgumentException("Either orderId or clientOrderId should be provided");

            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("orderId", orderId);

            parameters.Add("symbol", symbol);
            parameters.Add("size", quantity);
            parameters.Add("price", price);
            parameters.Add("newClientOid", newClientOrderId);
            parameters.Add("presetTakeProfitPrice", presetTakeProfitPrice);
            parameters.Add("executeTakeProfitPrice", executeTakeProfitPrice);
            parameters.Add("presetStopLossPrice", presetStopLossPrice);
            parameters.Add("executeStopLossPrice", executeStopLossPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/cancel-replace-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderIdResult>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetOrderId>(result);

            if (!result.Data.Success)
                return HttpResult.Fail<BitgetOrderId>(result, new ServerError(ErrorInfo.Unknown with { Message = result.Data.ErrorMessage! }));

            return HttpResult.Ok<BitgetOrderId>(result, result.Data);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderIdResult[]>> CancelReplaceMultipleOrdersAsync(
            IEnumerable<BitgetReplaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/batch-cancel-replace-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderIdResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            TakeProfitStopLossType? tpslType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("tpslType", tpslType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/batch-cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult> CancelOrdersBySymbolAsync(
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/cancel-symbol-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrder[]>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/orderInfo", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrder[]>> GetOpenOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("tpslType", tpslType);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/unfilled-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrder[]>> GetClosedOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("tpslType", tpslType);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/history-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUserTrade[]>> GetUserTradesAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetUserTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceTriggerOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            decimal triggerPrice,
            QuantityType? quantityType = null,
            TriggerPriceType? triggerPriceType = null,
            decimal? orderPrice = null,
            TimeInForce? timeInForce = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("side", side);
            parameters.Add("orderType", type);
            parameters.Add("size", quantity);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("executePrice", orderPrice);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("force", timeInForce);
            parameters.Add("planType", quantityType);
            parameters.Add("triggerType", triggerPriceType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/place-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> EditTriggerOrderAsync(
            decimal triggerPrice,
            OrderType orderType,
            decimal quantity,
            decimal? orderPrice = null,
            string? orderId = null,
            string? clientOrderId = null,            
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("size", quantity);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("orderType", orderType);
            parameters.Add("executePrice", orderPrice);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/modify-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult> CancelTriggerOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/cancel-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelAllTriggerOrdersAsync(
            IEnumerable<string>? symbols = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.AddArray("symbols", symbols?.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/spot/trade/batch-cancel-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderList>> GetOpenTriggerOrdersAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/current-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            string triggerOrderId,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("planOrderId", triggerOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/plan-sub-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetTriggerSubOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderList>> GetClosedTriggerOrdersAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/spot/trade/history-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

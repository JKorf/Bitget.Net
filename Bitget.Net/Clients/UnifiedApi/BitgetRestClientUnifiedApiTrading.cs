using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.Uta;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.Objects.Errors;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal class BitgetRestClientUnifiedApiTrading : IBitgetRestClientUnifiedApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientUnifiedApi _baseClient;

        internal BitgetRestClientUnifiedApiTrading(BitgetRestClientUnifiedApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrderResult>> PlaceOrderAsync(
            ProductCategory category,
            string symbol,
            OrderSide side,
            OrderType orderType,
            decimal quantity,
            decimal? price = null,
            TimeInForce? timeInForce = null,
            PositionSide? positionSide = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            StpMode? stpMode = null,
            PriceTriggerType? tpTriggerBy = null,
            PriceTriggerType? slTriggerBy = null,
            decimal? tpTriggerPrice = null,
            decimal? slTriggerPrice = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            MarginMode? marginMode = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("side", side);
            parameters.Add("orderType", orderType);
            parameters.Add("qty", quantity);
            parameters.Add("price", price);
            parameters.Add("timeInForce", timeInForce);
            parameters.Add("posSide", positionSide);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("reduceOnly", reduceOnly == null ? null : reduceOnly.Value ? "yes" : "no");
            parameters.Add("stpMode", stpMode);
            parameters.Add("tpTriggerBy", tpTriggerBy);
            parameters.Add("slTriggerBy", slTriggerBy);
            parameters.Add("takeProfit", tpTriggerPrice);
            parameters.Add("stopLoss", slTriggerPrice);
            parameters.Add("tpOrderType", tpOrderType);
            parameters.Add("slOrderType", slOrderType);
            parameters.Add("tpLimitPrice", tpLimitPrice);
            parameters.Add("slLimitPrice", slLimitPrice);
            parameters.Add("marginMode", marginMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/place-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrderResult>> EditOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            bool? autoCancel = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("qty", quantity);
            parameters.Add("price", price);
            parameters.Add("autoCancel", autoCancel == null ? null : autoCancel.Value ? "yes" : "no");
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/modify-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrderResult>> CancelOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel All Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaBatchResult[]>> CancelAllOrdersAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/cancel-symbol-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBatchResultWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetUaBatchResult[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Close Positions

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaBatchResult[]>> ClosePositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/close-positions", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBatchResultWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetUaBatchResult[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrder>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/trade/order-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrder>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrders>> GetOpenOrdersAsync(
            ProductCategory? category = null,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/trade/unfilled-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrders>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get User Trades

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaUserTrades>> GetUserTradesAsync(
            ProductCategory? category = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/trade/fills", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaUserTrades>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Positions

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaPosition[]>> GetPositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/position/current-position", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPositionWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetUaPosition[]>(result);

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Position History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaPositionHistory>> GetPositionHistoryAsync(
            ProductCategory category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/position/history-position", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPositionHistory>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Position Adl Rank

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaAdlRank[]>> GetPositionAdlRankAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/position/adlRank", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAdlRank[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Open Available

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaMaxOpenAvailable>> GetMaxOpenAvailableAsync(
            ProductCategory category,
            string symbol,
            OrderType orderType,
            OrderSide side,
            decimal quantity,
            decimal? price = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("orderType", orderType);
            parameters.Add("side", side);
            parameters.Add("size", quantity);
            parameters.Add("price", price);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/max-open-available", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaMaxOpenAvailable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Strategy Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrderResult>> PlaceStrategyOrderAsync(
            ProductCategory category,
            string symbol,
            StrategyType? type = null,
            string? clientOrderId = null,
            TpslMode? tpslMode = null,
            decimal? quantity = null,
            OrderSide? side = null,
            PositionSide? positionSide = null,
            bool? reduceOnly = null,
            TriggerPriceType? tpTriggerBy = null,
            TriggerPriceType? slTriggerBy = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            TriggerPriceType? triggerBy = null,
            decimal? triggerPrice = null,
            OrderType? triggerOrderType = null,
            decimal? triggerOrderPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("type", type);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("tpslMode", tpslMode);
            parameters.Add("qty", quantity);
            parameters.Add("side", side);
            parameters.Add("posSide", positionSide);
            parameters.Add("reduceOnly", reduceOnly, BoolSerialization.String);
            parameters.Add("tpTriggerBy", tpTriggerBy);
            parameters.Add("slTriggerBy", slTriggerBy);
            parameters.Add("takeProfit", takeProfit);
            parameters.Add("stopLoss", stopLoss);
            parameters.Add("tpOrderType", tpOrderType);
            parameters.Add("slOrderType", slOrderType);
            parameters.Add("tpLimitPrice", tpLimitPrice);
            parameters.Add("slLimitPrice", slLimitPrice);
            parameters.Add("triggerBy", triggerBy);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("triggerOrderType", triggerOrderType);
            parameters.Add("triggerOrderPrice", triggerOrderPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/place-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Strategy Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaOrderResult>> EditStrategyOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            TriggerPriceType? tpTriggerBy = null,
            TriggerPriceType? slTriggerBy = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            TriggerPriceType? triggerBy = null,
            decimal? triggerPrice = null,
            OrderType? triggerOrderType = null,
            decimal? triggerOrderPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("qty", quantity);
            parameters.Add("tpTriggerBy", tpTriggerBy);
            parameters.Add("slTriggerBy", slTriggerBy);
            parameters.Add("takeProfit", takeProfit);
            parameters.Add("stopLoss", stopLoss);
            parameters.Add("tpOrderType", tpOrderType);
            parameters.Add("slOrderType", slOrderType);
            parameters.Add("tpLimitPrice", tpLimitPrice);
            parameters.Add("slLimitPrice", slLimitPrice);
            parameters.Add("triggerBy", triggerBy);
            parameters.Add("triggerPrice", triggerPrice);
            parameters.Add("triggerOrderType", triggerOrderType);
            parameters.Add("triggerOrderPrice", triggerOrderPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/modify-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Strategy Order

        /// <inheritdoc />
        public async Task<HttpResult> CancelStrategyOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/trade/cancel-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Strategy Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaStrategyOrder[]>> GetOpenStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("type", type);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/trade/unfilled-strategy-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaStrategyOrder[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Closed Strategy Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaStrategyOrders>> GetClosedStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("type", type);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/trade/history-strategy-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaStrategyOrders>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

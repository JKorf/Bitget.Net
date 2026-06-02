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
        public async Task<WebCallResult<BitgetUaOrderResult>> PlaceOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", orderType);
            parameters.AddString("qty", quantity);
            parameters.AddOptional("price", price);
            parameters.AddOptionalEnum("timeInForce", timeInForce);
            parameters.AddOptionalEnum("posSide", positionSide);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("reduceOnly", reduceOnly == null ? null : reduceOnly.Value ? "yes" : "no");
            parameters.AddOptionalEnum("stpMode", stpMode);
            parameters.AddOptionalEnum("tpTriggerBy", tpTriggerBy);
            parameters.AddOptionalEnum("slTriggerBy", slTriggerBy);
            parameters.AddOptional("takeProfit", tpTriggerPrice);
            parameters.AddOptional("stopLoss", slTriggerPrice);
            parameters.AddOptionalEnum("tpOrderType", tpOrderType);
            parameters.AddOptionalEnum("slOrderType", slOrderType);
            parameters.AddOptional("tpLimitPrice", tpLimitPrice);
            parameters.AddOptional("slLimitPrice", slLimitPrice);
            parameters.AddOptionalEnum("marginMode", marginMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/place-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrderResult>> EditOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            bool? autoCancel = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalString("qty", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptional("autoCancel", autoCancel == null ? null : autoCancel.Value ? "yes" : "no");
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/modify-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrderResult>> CancelOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel All Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaBatchResult[]>> CancelAllOrdersAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/cancel-symbol-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBatchResultWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetUaBatchResult[]>(result.Data?.List);
        }

        #endregion

        #region Close Positions

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaBatchResult[]>> ClosePositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/close-positions", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBatchResultWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetUaBatchResult[]>(result.Data?.List);
        }

        #endregion

        #region Get Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrder>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/trade/order-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrder>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrders>> GetOpenOrdersAsync(
            ProductCategory? category = null,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/trade/unfilled-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrders>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaUserTrades>> GetUserTradesAsync(
            ProductCategory? category = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalEnum("category", category);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/trade/fills", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaUserTrades>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Positions

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaPosition[]>> GetPositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/position/current-position", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPositionWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetUaPosition[]>(result.Data?.List);
        }

        #endregion

        #region Get Position History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaPositionHistory>> GetPositionHistoryAsync(
            ProductCategory category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/position/history-position", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPositionHistory>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Position Adl Rank

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaAdlRank[]>> GetPositionAdlRankAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/position/adlRank", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAdlRank[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Open Available

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaMaxOpenAvailable>> GetMaxOpenAvailableAsync(
            ProductCategory category,
            string symbol,
            OrderType orderType,
            OrderSide side,
            decimal quantity,
            decimal? price = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("orderType", orderType);
            parameters.AddEnum("side", side);
            parameters.AddString("size", quantity);
            parameters.AddOptionalString("price", price);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/max-open-available", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaMaxOpenAvailable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Strategy Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrderResult>> PlaceStrategyOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("tpslMode", tpslMode);
            parameters.AddOptionalString("qty", quantity);
            parameters.AddOptionalEnum("side", side);
            parameters.AddOptionalEnum("posSide", positionSide);
            parameters.AddOptionalBoolString("reduceOnly", reduceOnly);
            parameters.AddOptionalEnum("tpTriggerBy", tpTriggerBy);
            parameters.AddOptionalEnum("slTriggerBy", slTriggerBy);
            parameters.AddOptionalString("takeProfit", takeProfit);
            parameters.AddOptionalString("stopLoss", stopLoss);
            parameters.AddOptionalEnum("tpOrderType", tpOrderType);
            parameters.AddOptionalEnum("slOrderType", slOrderType);
            parameters.AddOptionalString("tpLimitPrice", tpLimitPrice);
            parameters.AddOptionalString("slLimitPrice", slLimitPrice);
            parameters.AddOptionalEnum("triggerBy", triggerBy);
            parameters.AddOptionalString("triggerPrice", triggerPrice);
            parameters.AddOptionalEnum("triggerOrderType", triggerOrderType);
            parameters.AddOptionalString("triggerOrderPrice", triggerOrderPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/place-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Edit Strategy Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrderResult>> EditStrategyOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalString("qty", quantity);
            parameters.AddOptionalEnum("tpTriggerBy", tpTriggerBy);
            parameters.AddOptionalEnum("slTriggerBy", slTriggerBy);
            parameters.AddOptionalString("takeProfit", takeProfit);
            parameters.AddOptionalString("stopLoss", stopLoss);
            parameters.AddOptionalEnum("tpOrderType", tpOrderType);
            parameters.AddOptionalEnum("slOrderType", slOrderType);
            parameters.AddOptionalString("tpLimitPrice", tpLimitPrice);
            parameters.AddOptionalString("slLimitPrice", slLimitPrice);
            parameters.AddOptionalEnum("triggerBy", triggerBy);
            parameters.AddOptionalString("triggerPrice", triggerPrice);
            parameters.AddOptionalEnum("triggerOrderType", triggerOrderType);
            parameters.AddOptionalString("triggerOrderPrice", triggerOrderPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/modify-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Strategy Order

        /// <inheritdoc />
        public async Task<WebCallResult> CancelStrategyOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/trade/cancel-strategy-order", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Strategy Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaStrategyOrder[]>> GetOpenStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptionalEnum("type", type);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/trade/unfilled-strategy-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaStrategyOrder[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Closed Strategy Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaStrategyOrders>> GetClosedStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/trade/history-strategy-orders", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaStrategyOrders>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

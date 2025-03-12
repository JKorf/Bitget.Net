using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

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
        public async Task<WebCallResult<BitgetOrderId>> PlaceOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddEnum("force", timeInForce);
            parameters.AddString("size", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalString("triggerPrice", triggerPrice);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("tpslType", tpslType);
            parameters.AddOptionalEnum("stpMode", stpMode);
            parameters.AddOptionalString("presetTakeProfitPrice", presetTakeProfitPrice);
            parameters.AddOptionalString("executeTakeProfitPrice", executeTakeProfitPrice);
            parameters.AddOptionalString("presetStopLossPrice", presetStopLossPrice);
            parameters.AddOptionalString("executeStopLossPrice", executeStopLossPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/place-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);            
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> PlaceMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetPlaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-orders", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);            
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelReplaceOrderAsync(
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

            var parameters = new ParameterCollection();
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("orderId", orderId);

            parameters.Add("symbol", symbol);
            parameters.AddString("size", quantity);
            parameters.AddString("price", price);
            parameters.AddOptional("newClientOid", newClientOrderId);
            parameters.AddOptionalString("presetTakeProfitPrice", presetTakeProfitPrice);
            parameters.AddOptionalString("executeTakeProfitPrice", executeTakeProfitPrice);
            parameters.AddOptionalString("presetStopLossPrice", presetStopLossPrice);
            parameters.AddOptionalString("executeStopLossPrice", executeStopLossPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-replace-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderIdResult>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BitgetOrderId>(result.Data);

            if (!result.Data.Success)
                return result.AsError<BitgetOrderId>(new ServerError(result.Data.ErrorMessage!));

            return result.As<BitgetOrderId>(result.Data);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderIdResult[]>> CancelReplaceMultipleOrdersAsync(
            IEnumerable<BitgetReplaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-cancel-replace-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderIdResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            TakeProfitStopLossType? tpslType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("tpslType", tpslType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-cancel-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelOrdersBySymbolAsync(
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-symbol-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrder[]>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/orderInfo", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrder[]>> GetOpenOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptionalEnum("tpslType", tpslType);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/unfilled-orders", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrder[]>> GetClosedOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptionalEnum("tpslType", tpslType);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/history-orders", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserTrade[]>> GetUserTradesAsync(
            string symbol,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/fills", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetUserTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceTriggerOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddOptionalString("executePrice", orderPrice);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("force", timeInForce);
            parameters.AddOptionalEnum("planType", quantityType);
            parameters.AddOptionalEnum("triggerType", triggerPriceType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/place-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> EditTriggerOrderAsync(
            decimal triggerPrice,
            OrderType orderType,
            decimal quantity,
            decimal? orderPrice = null,
            string? orderId = null,
            string? clientOrderId = null,            
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddEnum("orderType", orderType);
            parameters.AddOptionalString("executePrice", orderPrice);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/modify-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelTriggerOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllTriggerOrdersAsync(
            IEnumerable<string>? symbols = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbols", symbols);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-cancel-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderList>> GetOpenTriggerOrdersAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/current-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            string triggerOrderId,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("planOrderId", triggerOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/plan-sub-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetTriggerSubOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderList>> GetClosedTriggerOrdersAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddMilliseconds("startTime", startTime);
            parameters.AddMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/history-plan-order", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

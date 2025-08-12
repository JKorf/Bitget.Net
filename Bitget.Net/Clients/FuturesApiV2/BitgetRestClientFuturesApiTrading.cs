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
        public async Task<WebCallResult<BitgetPosition[]>> GetPositionAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/position/single-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPosition[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPosition[]>> GetPositionsAsync(BitgetProductTypeV2 productType, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/position/all-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPosition[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionHistory>> GetPositionHistoryAsync(BitgetProductTypeV2? productType = null, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/position/history-position", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionHistory>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceOrderAsync(
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

            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddEnum("marginMode", marginMode);
            parameters.AddString("size", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalEnum("force", timeInForce);
            parameters.AddOptionalEnum("tradeSide", tradeSide);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("reduceOnly", reduceOnly == null ? null : reduceOnly == true ? "YES" : "NO");
            parameters.AddOptionalString("presetStopSurplusPrice", takeProfitPrice);
            parameters.AddOptionalString("presetStopLossPrice", stopLossPrice);
            parameters.AddOptionalString("presetStopSurplusExecutePrice", takeProfitLimitPrice);
            parameters.AddOptionalString("presetStopLossExecutePrice", stopLossLimitPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<CallResult<BitgetOrderId>[]>> PlaceMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            MarginMode marginMode,
            IEnumerable<BitgetFuturesPlaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddEnum("marginMode", marginMode);
            parameters.Add("orderList", orders.ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var resultData = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            if (!resultData)
                return resultData.As<CallResult<BitgetOrderId>[]>(default);

            var result = new List<CallResult<BitgetOrderId>>();
            foreach (var item in resultData.Data.Success)
                result.Add(new CallResult<BitgetOrderId>(item!));

            foreach (var item in resultData.Data.Failed)
                result.Add(new CallResult<BitgetOrderId>(new ServerError(item.ErrorCode!.Value.ToString(), _baseClient.GetErrorInfo(item.ErrorCode!.Value, item.ErrorMessage!))));

            if (result.All(x => !x.Success))
                return resultData.AsErrorWithData(new ServerError(null, new ErrorInfo(ErrorType.AllOrdersFailed, "All orders failed")), result.ToArray());

            return resultData.As(result.ToArray());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> EditOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("newClientOid", newClientOrderId);
            parameters.AddOptionalString("newPrice", newPrice);
            parameters.AddOptionalString("newQuantity", newQuantity);
            parameters.AddOptionalString("newPresetStopSurplusPrice", newTakeProfit);
            parameters.AddOptionalString("newPresetStopLossPrice", newStopLossPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/modify-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("marginCoin", marginAsset);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            IEnumerable<BitgetCancelOrderRequest> orders,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("marginCoin", marginAsset);
            parameters.AddOptional("orderIdList", orders.ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/batch-cancel-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("marginCoin", marginAsset?.ToUpperInvariant());

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/cancel-all-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrder>> GetOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/detail", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesOrder>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrders>> GetOpenOrdersAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("status", status);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/orders-pending", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetFuturesOrders>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result;

            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesOrder>();

            return result.As(result.Data);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrders>> GetClosedOrdersAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/orders-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetFuturesOrders>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BitgetFuturesOrders>(default);
            
            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesOrder>();

            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesUserTrades>> GetUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesUserTrades>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesUserTrades>> GetHistoricalUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/fill-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesUserTrades>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> ClosePositionsAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            PositionSide? side = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("holdSide", side);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/close-positions", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceTpSlOrderAsync(
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

            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType); 
            parameters.AddEnum("planType", planType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddOptionalString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddOptionalEnum("holdSide", hedgeModePositionSide);
            parameters.AddOptionalEnum("holdSide", oneWaySide);
            parameters.AddOptionalEnum("triggerType", triggerPriceType);
            parameters.AddOptionalString("rangeRate", trailingStopRate);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalString("executePrice", orderPrice);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/place-tpsl-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceTriggerOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("planType", planType);
            parameters.AddEnum("marginMode", marginMode);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", orderType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddString("size", quantity);
            parameters.AddOptionalString("price", orderPrice);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddEnum("triggerType", triggerPriceType ?? TriggerPriceType.LastPrice);
            parameters.AddOptionalString("callbackRatio", trailingStopRate);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("reduceOnly", reduceOnly == null ? null : reduceOnly == true ? "YES" : "NO");
            parameters.AddOptionalEnum("tradeSide", tradeSide);
            parameters.AddOptionalString("stopSurplusTriggerPrice", takeProfitTriggerPrice);
            parameters.AddOptionalString("stopSurplusExecutePrice", takeProfitOrderPrice);
            parameters.AddOptionalEnum("stopSurplusTriggerType", takeProfitPriceType);
            parameters.AddOptionalString("stopLossTriggerPrice", stopLossTriggerPrice);
            parameters.AddOptionalString("stopLossExecutePrice", stopLossOrderPrice);
            parameters.AddOptionalEnum("stopLossTriggerType", stopLossPriceType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/place-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            BitgetProductTypeV2 productType,
            string triggerOrderId,
            TriggerPlanType planType,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("planOrderId", triggerOrderId);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("planType", planType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/plan-sub-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetTriggerSubOrder[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> EditTriggerOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalString("size", newQuantity);
            parameters.AddOptionalString("price", newPrice);
            parameters.AddOptionalString("triggerPrice", newTriggerPrice);
            parameters.AddOptionalEnum("triggerType", newTriggerType);
            parameters.AddOptionalString("callbackRatio", newTrailingStopRate);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalString("stopSurplusTriggerPrice", newTakeProfitTriggerPrice);
            parameters.AddOptionalString("stopSurplusExecutePrice", newTakeProfitOrderPrice);
            parameters.AddOptionalEnum("stopSurplusTriggerType", newTakeProfitPriceType);
            parameters.AddOptionalString("stopLossTriggerPrice", newStopLossTriggerPrice);
            parameters.AddOptionalString("stopLossExecutePrice", newStopLossOrderPrice);
            parameters.AddOptionalEnum("stopLossTriggerType", newStopLossPriceType);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/modify-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> EditTpSlOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalString("size", newQuantity);
            parameters.AddOptionalString("executePrice", newOrderPrice);
            parameters.AddOptionalString("triggerPrice", newTriggerPrice);
            parameters.AddOptionalEnum("triggerType", newTriggerType);
            parameters.AddOptionalString("rangeRate", newTrailingStopRate);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("orderId", orderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/modify-tpsl-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesTriggerOrders>> GetOpenTriggerOrdersAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("planType", planType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/orders-plan-pending", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesTriggerOrders>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesTriggerOrders>> GetClosedTriggerOrdersAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("planType", planType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptionalEnum("planStatus", status);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/order/orders-plan-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));

            var result = await _baseClient.SendAsync<BitgetFuturesTriggerOrders>(request, parameters, ct).ConfigureAwait(false);

            if (!result)
                return result.As<BitgetFuturesTriggerOrders>(default);

            if (result.Data.Orders == null)
                result.Data.Orders = Array.Empty<BitgetFuturesTriggerOrder>();

            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            CancelTriggerPlanTypeFilter? planType = null,
            string? symbol = null,
            string? marginCoin = null,
            IEnumerable<BitgetCancelOrderRequest>? orderIds = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalEnum("planType", planType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderIdList", orderIds == null ? null : orderIds.ToArray()!);
            parameters.AddOptional("marginCoin", marginCoin);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/cancel-plan-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #region Set Position Tp Sl

        /// <inheritdoc />
        public async Task<WebCallResult<BitMartPositionTpSl[]>> SetPositionTpSlAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, PositionSide holdSide, decimal? tpTriggerPrice = null, decimal? tpTriggerQuantity = null, TriggerPriceType? tpTriggerType = null, decimal? tpLimitPrice = null, decimal? slTriggerPrice = null, decimal? slTriggerQuantity = null, TriggerPriceType? slTriggerType = null, decimal? slLimitPrice = null, SelfTradePreventionMode? stpMode = null, string? tpClientOrderId = null, string? slClientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddEnum("holdSide", holdSide);
            parameters.AddOptionalString("stopSurplusTriggerPrice", tpTriggerPrice);
            parameters.AddOptionalString("stopSurplusSize", tpTriggerQuantity);
            parameters.AddOptionalEnum("stopSurplusTriggerType", tpTriggerType);
            parameters.AddOptionalString("stopSurplusExecutePrice", tpLimitPrice);
            parameters.AddOptionalString("stopLossTriggerPrice", slTriggerPrice);
            parameters.AddOptionalString("stopLossSize", slTriggerQuantity);
            parameters.AddOptionalEnum("stopLossTriggerType", slTriggerType);
            parameters.AddOptionalString("stopLossExecutePrice", slLimitPrice);
            parameters.AddOptionalEnum("stpMode", stpMode);
            parameters.AddOptional("stopSurplusClientOid", tpClientOrderId);
            parameters.AddOptional("stopLossClientOid", slClientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/order/place-pos-tpsl", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitMartPositionTpSl[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

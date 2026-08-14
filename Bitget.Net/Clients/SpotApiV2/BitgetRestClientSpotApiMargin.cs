using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientSpotApiMargin : IBitgetRestClientSpotApiMargin
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiMargin(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Margin Symbols

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMarginSymbol[]>> GetMarginSymbolsAsync(CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/currencies", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMarginSymbol[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Margin Symbols

        /// <inheritdoc />
        public async Task<HttpResult<BitgetInterestRate>> GetInterestRatesAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/interest-rate-record", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetInterestRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Borrow History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossBorrowHistory>>> GetCrossBorrowHistoryAsync(
            string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("loanId", loanId);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/borrow-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Repay History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossRepayHistory>>> GetCrossRepayHistoryAsync(
            string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("repayId", repayId);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/repay-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossRepayHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Interest History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossInterest>>> GetCrossInterestHistoryAsync(string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/interest-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossInterest>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Liquidation History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossLiquidation>>> GetCrossLiquidationHistoryAsync(
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/liquidation-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidation>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Financial History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossFinancial>>> GetCrossFinancialHistoryAsync(
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("marginType", marginType);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/financial-records", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossFinancial>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Balances

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossBalance[]>> GetCrossBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/assets", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossBalance[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Borrow

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossBorrowResult>> CrossBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("borrowAmount", quantity);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/borrow", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossBorrowResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Repay

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossRepayResult>> CrossRepayAsync(string asset, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("repayAmount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Risk Rate

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossRiskRate>> GetCrossRiskRateAsync(CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/risk-rate", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossRiskRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Max Borrowable

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossMaxBorrowable>> GetCrossMaxBorrowableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/max-borrowable-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossMaxBorrowable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Max Transferable

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossMaxTransferable>> GetCrossMaxTransferableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/max-transfer-out-amount", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Interest And Limit

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossInterestLimit[]>> GetCrossInterestAndLimitAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/interest-rate-and-limit", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossInterestLimit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Tier Config

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossTierConfig[]>> GetCrossTierConfigAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/tier-data", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossTierConfig[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Flash Repay

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossFlashRepayResult>> CrossFlashRepayAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/flash-repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Flash Repay Status

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossFlashRepayStatus[]>> GetCrossFlashRepayStatusAsync(string ids, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("idList", ids);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/account/query-flash-repay-status", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayStatus[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Cross Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceCrossOrderAsync(
            string symbol,
            LoanType loanType,
            OrderSide orderSide,
            OrderType orderType, 
            TimeInForce timeInForce,
            decimal? price = null,
            decimal? quantity = null,
            string? quoteQuantity = null,
            string? clientOrderId = null,
            SelfTradePreventionMode? selfTradePreventionMode = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("loanType", loanType);
            parameters.Add("side", orderSide);
            parameters.Add("orderType", orderType);
            parameters.Add("force", timeInForce);
            parameters.Add("price", price);
            parameters.Add("baseSize", quantity);
            parameters.Add("quoteSize", quoteQuantity);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("stpMode", selfTradePreventionMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Multiple Cross Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderResult[]>> PlaceMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", requests.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Cross Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> CancelCrossOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Multiple Cross Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/crossed/batch-cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Open Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/open-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Closed Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("enterPointSource", enterPointSource);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/history-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross User Trades

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetCrossUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Liquidation Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetCrossLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("type", type);
            parameters.Add("fromCoin", fromAsset);
            parameters.Add("toCoin", toAsset);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/crossed/liquidation-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion


        #region Get Isolated Borrow History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>> GetIsolatedBorrowHistoryAsync(
            string symbol,
            string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("loanId", loanId);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/borrow-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Repay History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>> GetIsolatedRepayHistoryAsync(
            string symbol,
            string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("repayId", repayId);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/repay-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Interest History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetIsolatedInterest>>> GetIsolatedInterestHistoryAsync(string symbol, string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/interest-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedInterest>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Liquidation History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetIsolatedLiquidation>>> GetIsolatedLiquidationHistoryAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/liquidation-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedLiquidation>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Financial History

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetIsolatedFinancial>>> GetIsolatedFinancialHistoryAsync(
            string symbol,
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("marginType", marginType);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/financial-records", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedFinancial>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Balances

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedBalance[]>> GetIsolatedBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/assets", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedBalance[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Isolated Borrow

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedBorrowResult>> IsolatedBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("borrowAmount", quantity);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/borrow", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedBorrowResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Isolated Repay

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedRepayResult>> IsolatedRepayAsync(string asset, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("repayAmount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Risk Rate

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedRiskRate[]>> GetIsolatedRiskRateAsync(CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/risk-rate", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedRiskRate[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Interest And Limit

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedInterestLimit[]>> GetIsolatedInterestAndLimitAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/interest-rate-and-limit", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedInterestLimit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Tier Config

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedTierConfig[]>> GetIsolatedTierConfigAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/tier-data", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedTierConfig[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Max Borrowable

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedMaxBorrowable>> GetIsolatedMaxBorrowableAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/max-borrowable-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedMaxBorrowable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Max Transferable

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedMaxTransferable>> GetIsolatedMaxTransferableAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/max-transfer-out-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Isolated Repay

        /// <inheritdoc />
        public async Task<HttpResult<BitgetIsolatedFlashRepayResult[]>> IsolatedFlashRepayAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.AddArray("symbolList", symbols);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/flash-repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedFlashRepayResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Flash Repay Status

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCrossFlashRepayStatus[]>> GetIsolatedFlashRepayStatusAsync(string ids, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("idList", ids);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/account/query-flash-repay-status", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayStatus[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Isolated Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> PlaceIsolatedOrderAsync(
            string symbol,
            LoanType loanType,
            OrderSide orderSide,
            OrderType orderType,
            TimeInForce timeInForce,
            decimal? price = null,
            decimal? quantity = null,
            string? quoteQuantity = null,
            string? clientOrderId = null,
            SelfTradePreventionMode? selfTradePreventionMode = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("loanType", loanType);
            parameters.Add("side", orderSide);
            parameters.Add("orderType", orderType);
            parameters.Add("force", timeInForce);
            parameters.Add("price", price);
            parameters.Add("baseSize", quantity);
            parameters.Add("quoteSize", quoteQuantity);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("stpMode", selfTradePreventionMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Multiple Cross Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderResult[]>> PlaceMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", requests.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Isolated Order

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderId>> CancelIsolatedOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Multiple Isolated Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOrderMultipleResult>> CancelMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/margin/isolated/batch-cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Open Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/open-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Closed Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("enterPointSource", enterPointSource);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/history-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion


        #region Get Isolated User Trades

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetIsolatedUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Liquidation Orders

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetIsolatedLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("type", type);
            parameters.Add("fromCoin", fromAsset);
            parameters.Add("toCoin", toAsset);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/margin/isolated/liquidation-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion
    }
}

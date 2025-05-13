using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using System.Collections.Generic;
using System.Globalization;

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
        public async Task<WebCallResult<BitgetMarginSymbol[]>> GetMarginSymbolsAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/currencies", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMarginSymbol[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Margin Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetInterestRate>> GetInterestRatesAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/interest-rate-record", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetInterestRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Borrow History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossBorrowHistory>>> GetCrossBorrowHistoryAsync(
            string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("loanId", loanId);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/borrow-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Repay History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossRepayHistory>>> GetCrossRepayHistoryAsync(
            string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("repayId", repayId);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/repay-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossRepayHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Interest History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossInterest>>> GetCrossInterestHistoryAsync(string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/interest-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossInterest>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Liquidation History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidation>>> GetCrossLiquidationHistoryAsync(
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/liquidation-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidation>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Financial History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossFinancial>>> GetCrossFinancialHistoryAsync(
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalEnum("marginType", marginType);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/financial-records", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossFinancial>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossBalance[]>> GetCrossBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/assets", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossBalance[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Borrow

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossBorrowResult>> CrossBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddString("borrowAmount", quantity);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/borrow", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossBorrowResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossRepayResult>> CrossRepayAsync(string asset, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddString("repayAmount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Risk Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossRiskRate>> GetCrossRiskRateAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/risk-rate", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossRiskRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Max Borrowable

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossMaxBorrowable>> GetCrossMaxBorrowableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/max-borrowable-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossMaxBorrowable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Max Transferable

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossMaxTransferable>> GetCrossMaxTransferableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/max-transfer-out-amount", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Interest And Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossInterestLimit[]>> GetCrossInterestAndLimitAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/interest-rate-and-limit", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossInterestLimit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Tier Config

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossTierConfig[]>> GetCrossTierConfigAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/tier-data", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossTierConfig[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Flash Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossFlashRepayResult>> CrossFlashRepayAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/flash-repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Flash Repay Status

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossFlashRepayStatus[]>> GetCrossFlashRepayStatusAsync(string ids, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("idList", ids);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/query-flash-repay-status", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayStatus[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Cross Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceCrossOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("loanType", loanType);
            parameters.AddEnum("side", orderSide);
            parameters.AddEnum("orderType", orderType);
            parameters.AddEnum("force", timeInForce);
            parameters.AddOptional("price", price);
            parameters.AddOptionalString("baseSize", quantity);
            parameters.AddOptional("quoteSize", quoteQuantity);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("stpMode", selfTradePreventionMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Multiple Cross Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult[]>> PlaceMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", requests.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Cross Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelCrossOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Multiple Cross Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleCrossOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/batch-cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Open Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/open-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Closed Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetCrossClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("enterPointSource", enterPointSource);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/history-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetCrossUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Liquidation Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetCrossLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptional("fromCoin", fromAsset);
            parameters.AddOptional("toCoin", toAsset);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/liquidation-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion


        #region Get Isolated Borrow History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>> GetIsolatedBorrowHistoryAsync(
            string symbol,
            string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("loanId", loanId);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/borrow-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Repay History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>> GetIsolatedRepayHistoryAsync(
            string symbol,
            string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("repayId", repayId);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/repay-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Interest History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedInterest>>> GetIsolatedInterestHistoryAsync(string symbol, string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/interest-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedInterest>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Liquidation History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedLiquidation>>> GetIsolatedLiquidationHistoryAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/liquidation-history", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedLiquidation>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Financial History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetIsolatedFinancial>>> GetIsolatedFinancialHistoryAsync(
            string symbol,
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptionalEnum("marginType", marginType);
            parameters.AddOptional("coin", asset);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/financial-records", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetIsolatedFinancial>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedBalance[]>> GetIsolatedBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/account/assets", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedBalance[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Isolated Borrow

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedBorrowResult>> IsolatedBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddString("borrowAmount", quantity);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/account/borrow", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedBorrowResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Isolated Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedRepayResult>> IsolatedRepayAsync(string asset, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddString("repayAmount", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/account/repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Risk Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedRiskRate[]>> GetIsolatedRiskRateAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/account/risk-rate", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedRiskRate[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Interest And Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedInterestLimit[]>> GetIsolatedInterestAndLimitAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/interest-rate-and-limit", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedInterestLimit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Tier Config

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedTierConfig[]>> GetIsolatedTierConfigAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/tier-data", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedTierConfig[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Max Borrowable

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedMaxBorrowable>> GetIsolatedMaxBorrowableAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/account/max-borrowable-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedMaxBorrowable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Max Transferable

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedMaxTransferable>> GetIsolatedMaxTransferableAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/account/max-transfer-out-amount", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cross Isolated Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIsolatedFlashRepayResult[]>> IsolatedFlashRepayAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbolList", symbols);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/account/flash-repay", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetIsolatedFlashRepayResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Flash Repay Status

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossFlashRepayStatus[]>> GetIsolatedFlashRepayStatusAsync(string ids, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("idList", ids);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/account/query-flash-repay-status", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCrossFlashRepayStatus[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Isolated Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceIsolatedOrderAsync(
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("loanType", loanType);
            parameters.AddEnum("side", orderSide);
            parameters.AddEnum("orderType", orderType);
            parameters.AddEnum("force", timeInForce);
            parameters.AddOptional("price", price);
            parameters.AddOptionalString("baseSize", quantity);
            parameters.AddOptional("quoteSize", quoteQuantity);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("stpMode", selfTradePreventionMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Multiple Cross Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult[]>> PlaceMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCrossOrderRequest> requests,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", requests.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/batch-place-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderResult[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Isolated Order

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelIsolatedOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Multiple Isolated Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleIsolatedOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/isolated/batch-cancel-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Open Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedOpenOrdersAsync(string symbol, string? orderId = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/open-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Closed Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossOrder>>> GetIsolatedClosedOrdersAsync(string symbol, string? orderId = null, string? enterPointSource = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("enterPointSource", enterPointSource);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/history-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion


        #region Get Isolated User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossUserTrade>>> GetIsolatedUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddMillisecondsString("startTime", startTime ?? DateTime.UtcNow.AddDays(-30));
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/fills", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossUserTrade>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Isolated Liquidation Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>> GetIsolatedLiquidationOrdersAsync(string? symbol = null, LiquidationType? type = null, string? fromAsset = null, string? toAsset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptional("fromCoin", fromAsset);
            parameters.AddOptional("toCoin", toAsset);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("idLessThan", idLessThan);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/isolated/liquidation-order", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion
    }
}

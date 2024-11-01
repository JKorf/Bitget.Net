using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
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
        public async Task<WebCallResult<IEnumerable<BitgetMarginSymbol>>> GetMarginSymbolsAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/currencies", BitgetExchange.RateLimiter.Overal, 1, false);
            var result = await _baseClient.SendAsync<IEnumerable<BitgetMarginSymbol>>(request, parameters, ct).ConfigureAwait(false);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/borrow-history", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Repay History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMinMaxResult<BitgetRepayHistory>>> GetCrossRepayHistoryAsync(
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/repay-history", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetRepayHistory>>(request, parameters, ct).ConfigureAwait(false);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/interest-history", BitgetExchange.RateLimiter.Overal, 1, true);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/liquidation-history", BitgetExchange.RateLimiter.Overal, 1, true);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/financial-records", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<BitgetMinMaxResult<BitgetCrossFinancial>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Balances

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetCrossBalance>>> GetCrossBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/assets", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<IEnumerable<BitgetCrossBalance>>(request, parameters, ct).ConfigureAwait(false);
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
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/borrow", BitgetExchange.RateLimiter.Overal, 1, true);
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
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/margin/crossed/account/repay", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<BitgetCrossRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Risk Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCrossRiskRate>> GetCrossRiskRateAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/risk-rate", BitgetExchange.RateLimiter.Overal, 1, true);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/max-borrowable-amount", BitgetExchange.RateLimiter.Overal, 1, true);
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/account/max-transfer-out-amount", BitgetExchange.RateLimiter.Overal, 1, false);
            var result = await _baseClient.SendAsync<BitgetCrossMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Cross Interest And Limit

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetCrossInterestLimit>>> GetCrossInterestAndLimitAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/margin/crossed/interest-rate-and-limit", BitgetExchange.RateLimiter.Overal, 1, true);
            var result = await _baseClient.SendAsync<IEnumerable<BitgetCrossInterestLimit>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

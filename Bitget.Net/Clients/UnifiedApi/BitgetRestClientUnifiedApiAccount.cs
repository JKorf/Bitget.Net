using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal class BitgetRestClientUnifiedApiAccount : IBitgetRestClientUnifiedApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientUnifiedApi _baseClient;

        internal BitgetRestClientUnifiedApiAccount(BitgetRestClientUnifiedApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaBalances>> GetBalancesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/assets", BitgetExchange.RateLimiter.Overall, 1, true, 
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBalances>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Funding Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFundingAsset[]>> GetFundingBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/funding-assets", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFundingAsset[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Account Info

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/settings", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAccountInfo>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Leverage

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(
            ProductCategory category,
            string symbol,
            decimal leverage,
            string? asset = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddString("leverage", leverage);
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalEnum("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/set-leverage", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Hold Mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetHoldModeAsync(HoldingMode holdMode, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("holdMode", holdMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/set-hold-mode", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Financial Recods

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFinancialRecordPage>> GetFinancialRecordsAsync(
            ProductCategory category,
            string? asset = null,
            string? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("coin", asset);
            parameters.AddOptional("type", type);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/financial-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFinancialRecordPage>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Repayable Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaRepayableAssets>> GetRepayableAssetsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/repayable-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaRepayableAssets>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

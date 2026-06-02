using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
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

        #region Get Account Config

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaAccountConfig>> GetAccountConfigAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/settings", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAccountConfig>(request, null, ct).ConfigureAwait(false);
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

        #region Get Payment Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaPaymentAssets>> GetPaymentAssetsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/payment-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPaymentAssets>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Repay

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaRepayResult>> RepayAsync(
            IEnumerable<string> repayableAssets,
            IEnumerable<string> paymentAssets,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("repayableCoinList", repayableAssets.ToArray());
            parameters.Add("paymentCoinList", paymentAssets.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/repay", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Convert Records

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaConvertRecords>> GetConvertRecordsAsync(
            string fromAsset,
            string toAsset,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("fromAsset", fromAsset);
            parameters.Add("toAsset", toAsset);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/convert-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaConvertRecords>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Switch Deduct

        /// <inheritdoc />
        public async Task<WebCallResult> SwitchDeductAsync(bool deduct, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("deduct", deduct ? "on" : "off");
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/switch-deduct", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Deposit Account

        /// <inheritdoc />
        public async Task<WebCallResult> SetDepositAccountAsync(
            string asset,
            UtaAccountType accountType,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("accountType", accountType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/deposit-account", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deduct Status

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaDeductStatus>> GetDeductStatusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/deduct-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeductStatus>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Fee

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFeeRate>> GetFeeAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/fee-rate", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFeeRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Switch To Classic Mode

        /// <inheritdoc />
        public async Task<WebCallResult> SwitchToClassicModeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/switch", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Switch To Classic Status

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaSwitchStatus>> GetSwitchToClassicStatusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/switch-status", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaSwitchStatus>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Transferable

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaMaxTransferable>> GetMaxTransferableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/max-transferable", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Interest Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaUserOpenInterestLimit>> GetOpenInterestLimitAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/open-interest-limit", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaUserOpenInterestLimit>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Account Info

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAccountInfo>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Delta Info

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaDeltaInfo>> GetDeltaInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/delta-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeltaInfo>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Account Mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetAccountModeAsync(
            AccountLevel mode,
            string? subAccountId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("mode", mode);
            parameters.AddOptional("targetUid", subAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/adjust-account-mode", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Transferable Assets

        /// <inheritdoc />
        public async Task<WebCallResult<string[]>> GetTransferableAssetsAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("fromType", fromType);
            parameters.AddEnum("toType", toType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/transferable-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<string[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaTransferId>> TransferAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            string asset,
            decimal quantity,
            string? symbol = null,
            bool? allowBorrow = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("fromType", fromType);
            parameters.AddEnum("toType", toType);
            parameters.Add("coin", asset);
            parameters.AddString("amount", quantity);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalBoolString("allowBorrow", allowBorrow);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/transfer", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaTransferId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deposit Address

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaDepositAddress>> GetDepositAddressAsync(
            string asset,
            string? network = null,
            decimal? quantity = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddOptional("chain", network);
            parameters.AddOptionalString("size", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/deposit-address", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDepositAddress>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deposit Records

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaDeposit[]>> GetDepositRecordsAsync(
            string? asset = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/deposit-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeposit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Withdraw

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaWithdrawResult>> WithdrawAsync(
            string asset,
            Enums.V2.TransferType transferType,
            string address,
            decimal quantity,
            string? network = null,
            string? innerWithdrawType = null,
            string? areaCode = null,
            string? tag = null,
            string? remark = null,
            string? clientOrderId = null,
            string? memberCode = null,
            string? identityType = null,
            string? companyName = null,
            string? firstName = null,
            string? lastName = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("transferType", transferType);
            parameters.Add("address", address);
            parameters.AddString("size", quantity);
            parameters.AddOptional("chain", network);
            parameters.AddOptional("innerToType", innerWithdrawType);
            parameters.AddOptional("areaCode", areaCode);
            parameters.AddOptional("tag", tag);
            parameters.AddOptional("remark", remark);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("memberCode", memberCode);
            parameters.AddOptional("identityType", identityType);
            parameters.AddOptional("companyName", companyName);
            parameters.AddOptional("firstName", firstName);
            parameters.AddOptional("lastName", lastName);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/withdrawal", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaWithdrawResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Withdrawal Records

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaWithdrawRecord[]>> GetWithdrawalRecordsAsync(
            string? asset = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/withdrawal-records", BitgetExchange.RateLimiter.Overall, 1, true);
            var result = await _baseClient.SendAsync<BitgetUaWithdrawRecord[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Withdraw Address Book

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaAddressBook>> GetWithdrawAddressBookAsync(
            string? asset = null,
            AddressBookType? type = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/account/withdraw-address", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAddressBook>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Withdrawal

        /// <inheritdoc />
        public async Task<WebCallResult> CancelWithdrawalAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v3/account/cancel-withdrawal", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

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
        public async Task<HttpResult<BitgetUaBalances>> GetBalancesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/assets", BitgetExchange.RateLimiter.Overall, 1, true, 
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaBalances>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Funding Balances

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaFundingAsset[]>> GetFundingBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/funding-assets", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFundingAsset[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Account Config

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaAccountConfig>> GetAccountConfigAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/settings", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAccountConfig>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Leverage

        /// <inheritdoc />
        public async Task<HttpResult> SetLeverageAsync(
            ProductCategory category,
            string symbol,
            decimal leverage,
            string? asset = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            parameters.Add("leverage", leverage);
            parameters.Add("coin", asset);
            parameters.Add("posSide", positionSide);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/set-leverage", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Hold Mode

        /// <inheritdoc />
        public async Task<HttpResult> SetHoldModeAsync(HoldingMode holdMode, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("holdMode", holdMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/set-hold-mode", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Financial Recods

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaFinancialRecordPage>> GetFinancialRecordsAsync(
            ProductCategory category,
            string? asset = null,
            string? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("coin", asset);
            parameters.Add("type", type);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/financial-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFinancialRecordPage>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Repayable Assets

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaRepayableAssets>> GetRepayableAssetsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/repayable-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaRepayableAssets>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Payment Assets

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaPaymentAssets>> GetPaymentAssetsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/payment-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPaymentAssets>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Repay

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaRepayResult>> RepayAsync(
            IEnumerable<string> repayableAssets,
            IEnumerable<string> paymentAssets,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("repayableCoinList", repayableAssets.ToArray());
            parameters.Add("paymentCoinList", paymentAssets.ToArray());
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/repay", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaRepayResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Convert Records

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaConvertRecords>> GetConvertRecordsAsync(
            string fromAsset,
            string toAsset,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("fromAsset", fromAsset);
            parameters.Add("toAsset", toAsset);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/convert-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaConvertRecords>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Switch Deduct

        /// <inheritdoc />
        public async Task<HttpResult> SwitchDeductAsync(bool deduct, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("deduct", deduct ? "on" : "off");
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/switch-deduct", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Deposit Account

        /// <inheritdoc />
        public async Task<HttpResult> SetDepositAccountAsync(
            string asset,
            UtaAccountType accountType,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("accountType", accountType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/deposit-account", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deduct Status

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaDeductStatus>> GetDeductStatusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/deduct-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeductStatus>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Fee

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaFeeRate>> GetFeeAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/fee-rate", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFeeRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Switch To Classic Mode

        /// <inheritdoc />
        public async Task<HttpResult> SwitchToClassicModeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/switch", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Switch To Classic Status

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaSwitchStatus>> GetSwitchToClassicStatusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/switch-status", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaSwitchStatus>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Max Transferable

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaMaxTransferable>> GetMaxTransferableAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/max-transferable", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaMaxTransferable>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Interest Limit

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaUserOpenInterestLimit>> GetOpenInterestLimitAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/open-interest-limit", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaUserOpenInterestLimit>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Account Info

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAccountInfo>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Delta Info

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaDeltaInfo>> GetDeltaInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/delta-info", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeltaInfo>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Set Account Mode

        /// <inheritdoc />
        public async Task<HttpResult> SetAccountModeAsync(
            AccountLevel mode,
            string? subAccountId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("mode", mode);
            parameters.Add("targetUid", subAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/adjust-account-mode", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Transferable Assets

        /// <inheritdoc />
        public async Task<HttpResult<string[]>> GetTransferableAssetsAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("fromType", fromType);
            parameters.Add("toType", toType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/transferable-coins", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<string[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Transfer

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaTransferId>> TransferAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            string asset,
            decimal quantity,
            string? symbol = null,
            bool? allowBorrow = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("fromType", fromType);
            parameters.Add("toType", toType);
            parameters.Add("coin", asset);
            parameters.Add("amount", quantity);
            parameters.Add("symbol", symbol);
            parameters.Add("allowBorrow", allowBorrow, BoolSerialization.String);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/transfer", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaTransferId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deposit Address

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaDepositAddress>> GetDepositAddressAsync(
            string asset,
            string? network = null,
            decimal? quantity = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("chain", network);
            parameters.Add("size", quantity);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/deposit-address", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDepositAddress>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Deposit Records

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaDeposit[]>> GetDepositRecordsAsync(
            string? asset = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("orderId", orderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/deposit-records", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDeposit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Withdraw

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaWithdrawResult>> WithdrawAsync(
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
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("transferType", transferType);
            parameters.Add("address", address);
            parameters.Add("size", quantity);
            parameters.Add("chain", network);
            parameters.Add("innerToType", innerWithdrawType);
            parameters.Add("areaCode", areaCode);
            parameters.Add("tag", tag);
            parameters.Add("remark", remark);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("memberCode", memberCode);
            parameters.Add("identityType", identityType);
            parameters.Add("companyName", companyName);
            parameters.Add("firstName", firstName);
            parameters.Add("lastName", lastName);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/withdrawal", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaWithdrawResult>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Withdrawal Records

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaWithdrawRecord[]>> GetWithdrawalRecordsAsync(
            string? asset = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/withdrawal-records", BitgetExchange.RateLimiter.Overall, 1, true);
            var result = await _baseClient.SendAsync<BitgetUaWithdrawRecord[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Withdraw Address Book

        /// <inheritdoc />
        public async Task<HttpResult<BitgetUaAddressBook>> GetWithdrawAddressBookAsync(
            string? asset = null,
            AddressBookType? type = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("type", type);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/account/withdraw-address", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaAddressBook>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Withdrawal

        /// <inheritdoc />
        public async Task<HttpResult> CancelWithdrawalAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("orderId", orderId);
            parameters.Add("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v3/account/cancel-withdrawal", BitgetExchange.RateLimiter.Overall, 1, true, limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using System.Globalization;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiAccount : IBitgetRestClientSpotApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiAccount(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetBalance>>> GetFundingBalancesAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/account/funding-assets", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetBalance>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetAssetValue>>> GetAssetsValuationAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/account/all-account-balance", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetAssetValue>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserFee>> GetTradeFeeAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("businessType", businessType);
            parameters.Add("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/common/trade-rate", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetUserFee>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/account/info", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetAccountInfo>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetSpotBalance>>> GetSpotBalancesAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/account/assets", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetSpotBalance>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> SetDepositAccountAsync(string asset, Enums.V2.AccountType accountType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("accountType", accountType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/wallet/modify-deposit-account", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetSpotLedgerEntry>>> GetLedgerAsync(string? asset = null, Enums.V2.GroupType? groupType = null, Enums.V2.BusinessType? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset); ;
            parameters.AddOptionalEnum("groupType", groupType); ;
            parameters.AddOptionalEnum("businessType", businessType); ;
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/account/bills", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetSpotLedgerEntry>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, decimal quantity, string? symbol = null, string? clientId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("fromType", fromAccount);
            parameters.AddEnum("toType", toAccount);
            parameters.AddString("amount", quantity);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("clientOid", clientId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/wallet/transfer", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetTransferResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<string>>> GetTransferableAssetsAsync(Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("fromType", fromAccount);
            parameters.AddEnum("toType", toAccount);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/wallet/transfer-coin-info", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<string>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, Enums.V2.TransferType transferType, string address, decimal quantity, string? network = null, string? innerTargetType = null, string? areaCode = null, string? tag = null, string? remark = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("transferType", transferType);
            parameters.Add("address", address);
            parameters.AddString("size", quantity);
            parameters.AddOptional("chain", network);
            parameters.AddOptional("areaCode", areaCode);
            parameters.AddOptional("innerToType", innerTargetType);
            parameters.AddOptional("tag", tag);
            parameters.AddOptional("remark", remark);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/wallet/withdrawal", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetWithdrawResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTransferRecord>>> GetTransferHistoryAsync(string asset, Enums.V2.TransferAccountType fromAccount, DateTime? startTime = null, DateTime? endTime = null, string? clientOrderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddEnum("fromType", fromAccount);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/account/transferRecords", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetTransferRecord>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> SetBgbDeductEnabledAsync(bool enable, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("deduct", enable ? "on" : "off");
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/account/switch-deduct", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetBgbDeduct>> GetBgbDeductEnabledAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/account/deduct-info", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetBgbDeduct>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string? network = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            parameters.AddOptional("chain", network);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/wallet/deposit-address", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetDepositAddress>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelWithdrawalAsync(string withdrawalOrderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderId", withdrawalOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/wallet/cancel-withdrawal", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetWithdrawalRecord>>> GetWithdrawalHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalEnum("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddMilliseconds("startTime", startTime);
            parameters.AddMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/wallet/withdrawal-records", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetWithdrawalRecord>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetDepositRecord>>> GetDepositHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalEnum("orderId", orderId);
            parameters.AddMilliseconds("startTime", startTime);
            parameters.AddMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/wallet/deposit-records", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetDepositRecord>>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

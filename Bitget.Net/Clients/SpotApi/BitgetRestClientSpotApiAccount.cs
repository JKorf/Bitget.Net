﻿using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Globalization;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiAccount : IBitgetRestClientSpotApiAccount
    {
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiAccount(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetBalance>>("/api/spot/v1/account/assets", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesLiteAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetBalance>>("/api/spot/v1/account/assets-lite", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<BitgetApiKeyInfo>("/api/spot/v1/account/getInfo", HttpMethod.Get, ct, null, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetBill>>> GetBillsAsync(string? asset = null, BitgetGroupType? groupType = null, string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, int? pageSize = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalEnum("groupType", groupType);
            parameters.AddOptional("businessType", bizType);
            parameters.AddOptional("idLessThan", endId);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", pageSize);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetBill>>("/api/v2/spot/account/bills", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTransfer>>> GetTransferHistoryAsync(string assetId, BitgetAccountType fromType, DateTime startTime, DateTime endTime, string? clientOrderId = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 500);

            var parameters = new Dictionary<string, object>()
            {
                { "coinId", assetId },
                { "fromType", EnumConverter.GetString(fromType) },
                { "before", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "after", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };

            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("limit", limit);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetTransfer>>("/api/spot/v1/account/transferRecords", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string? symbol = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "amount", quantity },
                { "fromType", EnumConverter.GetString(fromType).ToLowerInvariant() },
                { "toType", EnumConverter.GetString(toType).ToLowerInvariant() }
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetTransferResult>("/api/spot/v1/wallet/transfer-v2", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> SubTransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string clientOrderId, string fromUserId, string toUserId, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "amount", quantity },
                { "fromType", EnumConverter.GetString(fromType).ToLowerInvariant() },
                { "toType", EnumConverter.GetString(toType).ToLowerInvariant() },
                { "clientOid", clientOrderId },
                { "fromUserId", fromUserId },
                { "toUserId", toUserId },
            };

            return await _baseClient.ExecuteAsync("/api/spot/v1/wallet/subTransfer", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string network, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "chain", network }
            };
            return await _baseClient.ExecuteAsync<BitgetDepositAddress>("/api/spot/v1/wallet/deposit-address", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, string address, string network, decimal quantity, string? tag = null, string? remark = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "address", address },
                { "chain", network },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("tag", tag);
            parameters.AddOptionalParameter("remark", remark);
            parameters.AddOptionalParameter("clientOid", clientOrderId);

            return await _baseClient.ExecuteAsync<BitgetWithdrawResult>("/api/spot/v1/wallet/withdrawal-v2", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetWithdrawResult>> InnerWithdrawAsync(string asset, string toUserId, decimal quantity, string? toType = null, string? areaCode = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "toUid", toUserId },
                { "quantity", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("toType", toType);
            parameters.AddOptionalParameter("areaCode", areaCode);
            parameters.AddOptionalParameter("clientOid", clientOrderId);

            return await _baseClient.ExecuteAsync<BitgetWithdrawResult>("/api/spot/v1/wallet/withdrawal-inner-v2", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default)
        {
            pageSize?.ValidateIntBetween(nameof(pageSize), 1, 100);

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMicroseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMicroseconds(endTime));
            parameters.AddOptionalParameter("pageNo", page);
            parameters.AddOptionalParameter("pageSize", pageSize);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetWithdrawal>>("/api/spot/v1/wallet/withdrawal-list", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetDeposit>>> GetDepositHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default)
        {
            pageSize?.ValidateIntBetween(nameof(pageSize), 1, 200);

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMicroseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMicroseconds(endTime));
            parameters.AddOptionalParameter("pageNo", page);
            parameters.AddOptionalParameter("pageSize", pageSize);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetDeposit>>("/api/spot/v1/wallet/deposit-list", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserFee>> GetUserFeeRatioAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "business", EnumConverter.GetString(businessType) }
            };

            return await _baseClient.ExecuteAsync<BitgetUserFee>("/api/user/v1/fee/query", HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }
    }
}

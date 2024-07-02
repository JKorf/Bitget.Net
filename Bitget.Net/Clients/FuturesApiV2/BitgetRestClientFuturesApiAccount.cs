﻿using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientFuturesApiAccount : IBitgetRestClientFuturesApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiAccount(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesBalance>> GetBalanceAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("symbol", symbol);
            parameters.AddEnum("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/account/account", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesBalance>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesBalance>>> GetBalancesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/account/accounts", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<IEnumerable<BitgetFuturesBalance>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionLeverage>> SetLeverageAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal leverage, PositionSide? side = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddString("leverage", leverage);
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalEnum("holdSide", side);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/account/set-leverage", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionLeverage>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> AdjustMarginAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal quantity, PositionSide? side = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddString("amount", quantity);
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalEnum("holdSide", side);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/account/set-margin", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionLeverage>> SetMarginModeAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, MarginMode? mode = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("marginMode", mode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/account/set-margin-mode", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionLeverage>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionMode>> SetPositionModeAsync(BitgetProductTypeV2 productType, PositionMode mode, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("posMode", mode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/mix/account/set-position-mode", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionMode>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesLedger>> GetLedgerAsync(BitgetProductTypeV2 productType, string? asset = null,string? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("coin", asset); 
            parameters.AddOptional("businessType", businessType); ;
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/account/bill", BitgetExchange.RateLimiter.Overal, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesLedger>(request, parameters, ct).ConfigureAwait(false);
        }

    }
}

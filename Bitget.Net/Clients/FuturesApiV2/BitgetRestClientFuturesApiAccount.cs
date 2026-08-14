using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApiAccount : IBitgetRestClientFuturesApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiAccount(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesBalance>> GetBalanceAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/account/account", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesBalance>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesBalance[]>> GetBalancesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/account/accounts", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesBalance[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionLeverage>> SetLeverageAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal? leverage = null, PositionSide? side = null, decimal? longLeverage = null, decimal? shortLeverage = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("leverage", leverage);
            parameters.Add("longLeverage", longLeverage);
            parameters.Add("shortLeverage", shortLeverage);
            parameters.Add("productType", productType);
            parameters.Add("holdSide", side);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/account/set-leverage", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionLeverage>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult> AdjustMarginAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal quantity, PositionSide? side = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("amount", quantity);
            parameters.Add("productType", productType);
            parameters.Add("holdSide", side);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/account/set-margin", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionLeverage>> SetMarginModeAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, MarginMode? mode = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("productType", productType);
            parameters.Add("marginMode", mode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/account/set-margin-mode", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionLeverage>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionMode>> SetPositionModeAsync(BitgetProductTypeV2 productType, PositionMode mode, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("posMode", mode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/api/v2/mix/account/set-position-mode", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetPositionMode>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesLedger>> GetLedgerAsync(BitgetProductTypeV2 productType, string? asset = null,string? businessType = null, DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("coin", asset); 
            parameters.Add("businessType", businessType); ;
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/account/bill", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesLedger>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesAdlRank[]>> GetAdlRankAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/position/adlRank", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetFuturesAdlRank[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetLiquidationPrice>> GetLiquidationPriceAsync(
            BitgetProductTypeV2 productType, 
            string symbol,
            string marginAsset,
            PositionSide side, 
            OrderType orderType,
            decimal openQuantity,
            decimal? openPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("posSide", side);
            parameters.Add("orderType", orderType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("openAmount", openQuantity);
            parameters.Add("openPrice", openPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/account/liq-price", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetLiquidationPrice>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetMaxOpenQuantity>> GetOpenableQuantityAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            PositionSide side,
            OrderType orderType,
            decimal? openPrice = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("posSide", side);
            parameters.Add("orderType", orderType);
            parameters.Add("symbol", symbol);
            parameters.Add("marginCoin", marginAsset);
            parameters.Add("openPrice", openPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/account/max-open", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetMaxOpenQuantity>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

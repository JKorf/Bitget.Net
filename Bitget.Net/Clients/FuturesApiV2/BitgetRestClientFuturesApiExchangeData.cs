using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApiExchangeData : IBitgetRestClientFuturesApiExchangeData
    {
        private readonly BitgetRestClientFuturesApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal BitgetRestClientFuturesApiExchangeData(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/public/time", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetServerTime>(request, null, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<DateTime>(result);

            return HttpResult.Ok(result, result.Data.ServerTime);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetContract[]>> GetContractsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/contracts", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetContract[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetVipFeeRate[]>> GetVipFeeRatesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/vip-fee-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetVipFeeRate[]>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesOrderBook>> GetOrderBookAsync(BitgetProductTypeV2 productType, string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default)
        {
            mergeStep?.ValidateIntBetween(nameof(mergeStep), 0, 3);

            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("precision", mergeStep == null? null: "scale" + mergeStep);
            parameters.Add("limit", limit == -1 ? "max" : limit?.ToString());
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/merge-depth", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesOrderBook>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesTicker>> GetTickerAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/ticker", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFuturesTicker[]>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetFuturesTicker>(result);

            return HttpResult.Ok(result, result.Data.Single());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesTicker[]>> GetTickersAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/tickers", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesTicker[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetTrade[]>> GetRecentTradesAsync(BitgetProductTypeV2 productType, string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/fills", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetTrade[]>> GetTradesAsync(BitgetProductTypeV2 productType, string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/fills-history", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesKline[]>> GetKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, KlineType? klineType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("granularity", interval);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("kLineType", klineType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesKline[]>> GetHistoricalKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("granularity", interval);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/history-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesKline[]>> GetHistoricalIndexPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("granularity", interval);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/history-index-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesKline[]>> GetHistoricalMarkPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("granularity", interval);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/history-mark-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOpenInterest>> GetOpenInterestAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/open-interest", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOpenInterestResult>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetOpenInterest>(result);

            return HttpResult.Ok(result, result.Data.OpenInterest.Single());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFundingTime>> GetNextFundingTimeAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/funding-time", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFundingTime[]>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetFundingTime>(result);

            return HttpResult.Ok(result, result.Data.First());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFuturesPrices>> GetPricesAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/symbol-price", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFuturesPrices[]>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetFuturesPrices>(result);

            return HttpResult.Ok(result, result.Data.First());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetFundingRate[]>> GetHistoricalFundingRateAsync(BitgetProductTypeV2 productType, string symbol, int? pageSize = null, int? page = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("pageSize", pageSize);
            parameters.Add("pageNo", page);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/history-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCurrentFundingRate>> GetFundingRateAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/current-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCurrentFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BitgetCurrentFundingRate>(result);

            return HttpResult.Ok(result, result.Data.First());
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCurrentFundingRate[]>> GetFundingRatesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/current-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCurrentFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetPositionTier[]>> GetPositionTiersAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/query-position-lever", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetPositionTier[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetOiLimit[]>> GetOiLimitsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/mix/market/oi-limit", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetOiLimit[]>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

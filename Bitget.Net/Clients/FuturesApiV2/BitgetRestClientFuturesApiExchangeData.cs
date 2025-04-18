using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
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
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/public/time", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetServerTime>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.ServerTime);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetContract[]>> GetContractsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/contracts", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetContract[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetVipFeeRate[]>> GetVipFeeRatesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/vip-fee-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetVipFeeRate[]>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrderBook>> GetOrderBookAsync(BitgetProductTypeV2 productType, string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default)
        {
            mergeStep?.ValidateIntBetween(nameof(mergeStep), 0, 3);

            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("precision", mergeStep == null? null: "scale" + mergeStep);
            parameters.AddOptional("limit", limit == -1 ? "max" : limit?.ToString());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/merge-depth", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesOrderBook>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/ticker", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFuturesTicker[]>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetFuturesTicker>(result.Data?.Single());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesTicker[]>> GetTickersAsync(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/tickers", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesTicker[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTrade[]>> GetRecentTradesAsync(BitgetProductTypeV2 productType, string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/fills", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTrade[]>> GetTradesAsync(BitgetProductTypeV2 productType, string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/fills-history", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetTrade[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesKline[]>> GetKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, KlineType? klineType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("granularity", interval);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptionalEnum("kLineType", klineType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("granularity", interval);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/history-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalIndexPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("granularity", interval);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/history-index-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalMarkPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddEnum("granularity", interval);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/history-mark-candles", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFuturesKline[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/open-interest", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetOpenInterestResult>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetOpenInterest>(result.Data?.OpenInterest.First());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/funding-time", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFundingTime[]>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetFundingTime>(result.Data?.FirstOrDefault());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesPrices>> GetPricesAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/symbol-price", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetFuturesPrices[]>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetFuturesPrices>(result.Data?.First());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFundingRate[]>> GetHistoricalFundingRateAsync(BitgetProductTypeV2 productType, string symbol, int? pageSize = null, int? page = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("pageSize", pageSize);
            parameters.AddOptional("pageNo", page);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/history-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCurrentFundingRate>> GetFundingRateAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/current-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCurrentFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetCurrentFundingRate>(result.Data?.First());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionTier[]>> GetPositionTiersAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/query-position-lever", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetPositionTier[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOiLimit[]>> GetOiLimitsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/mix/market/oi-limit", BitgetExchange.RateLimiter.Overall, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetOiLimit[]>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

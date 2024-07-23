using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientSpotApiExchangeData : IBitgetRestClientSpotApiExchangeData
    {
        private readonly BitgetRestClientSpotApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal BitgetRestClientSpotApiExchangeData(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/public/time", BitgetExchange.RateLimiter.Overal, 1, false, preventCaching: true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetServerTime>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.ServerTime);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/public/coins", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(3, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetAsset>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetSymbol>>> GetSymbolsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/public/symbols", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetVipFeeRate>>> GetVipFeeRatesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/vip-fee-rate", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetVipFeeRate>>(request, null, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTicker>>> GetTickersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/tickers", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetTicker>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default)
        {
            mergeStep?.ValidateIntBetween(nameof(mergeStep), 0, 5);

            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("step", mergeStep + mergeStep);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/orderbook", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<BitgetOrderBook>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("granularity", interval);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/candles", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetKline>>> GetHistoricalKlinesAsync(string symbol, KlineInterval interval, DateTime endTime, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("granularity", interval);
            parameters.AddMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/history-candles", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetKline>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);;
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/fills", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetTrade>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol); ;
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/market/fills-history", BitgetExchange.RateLimiter.Overal, 1, false,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            return await _baseClient.SendAsync<IEnumerable<BitgetTrade>>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

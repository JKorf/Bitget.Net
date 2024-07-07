using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models;
using Bitget.Net.Enums;
using Bitget.Net.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.FuturesApi;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApiExchangeData : IBitgetRestClientFuturesApiExchangeData
    {
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiExchangeData(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.ExecuteAsync<long>(_baseClient.GetUri("/api/spot/v1/public/time"), HttpMethod.Get, ct).ConfigureAwait(false);
            return result.As(result ? DateTimeConverter.ConvertFromMilliseconds(result.Data) : default);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesSymbol>>> GetSymbolsAsync(BitgetProductType type, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) }
            };
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesSymbol>>(_baseClient.GetUri("/api/mix/v1/market/contracts"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default)
        {
            mergeLevel?.ValidateIntBetween(nameof(mergeLevel), 0, 3);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("precision", mergeLevel == null ? null : "scale" + mergeLevel);
            parameters.AddOptionalParameter("limit", limit?.ToString());
            return await _baseClient.ExecuteAsync<BitgetFuturesOrderBook>(_baseClient.GetUri("/api/mix/v1/market/merge-depth"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntValues(nameof(limit), 5, 15, 50, 100);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            return await _baseClient.ExecuteAsync<BitgetOrderBook>(_baseClient.GetUri("/api/mix/v1/market/depth"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetFuturesTicker>(_baseClient.GetUri("/api/mix/v1/market/ticker"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesTicker>>> GetTickersAsync(BitgetProductType type, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) }
            };
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesTicker>>(_baseClient.GetUri("/api/mix/v1/market/tickers"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFeeLevel>>(_baseClient.GetUri("/api/mix/v1/market/contract-vip-level"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 100);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesTrade>>(_baseClient.GetUri("/api/mix/v1/market/fills"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetTradeHistoryAsync(string symbol, string? maxTradeId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 1000);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("tradeId", maxTradeId?.ToString());
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesTrade>>(_baseClient.GetUri("/api/mix/v1/market/fills-history"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 1000);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("granularity", EnumConverter.GetString(interval));
            parameters.AddOptionalParameter("kLineType", EnumConverter.GetString(priceType));
            return await _baseClient.ExecuteRawAsync<IEnumerable<BitgetFuturesKline>>(_baseClient.GetUri("/api/mix/v1/market/candles"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 200);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("granularity", EnumConverter.GetString(interval));
            parameters.AddOptionalParameter("kLineType", EnumConverter.GetString(priceType));
            return await _baseClient.ExecuteRawAsync<IEnumerable<BitgetFuturesKline>>(_baseClient.GetUri("/api/mix/v1/market/history-candles"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalIndexKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 200);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("granularity", EnumConverter.GetString(interval));
            parameters.AddOptionalParameter("kLineType", EnumConverter.GetString(priceType));
            return await _baseClient.ExecuteRawAsync<IEnumerable<BitgetFuturesKline>>(_baseClient.GetUri("/api/mix/v1/market/history-index-candles"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalMarkKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 200);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("granularity", EnumConverter.GetString(interval));
            parameters.AddOptionalParameter("kLineType", EnumConverter.GetString(priceType));
            return await _baseClient.ExecuteRawAsync<IEnumerable<BitgetFuturesKline>>(_baseClient.GetUri("/api/mix/v1/market/history-mark-candles"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetIndexPrice>> GetIndexPriceAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetIndexPrice>(_baseClient.GetUri("/api/mix/v1/market/index"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetFundingTime>(_baseClient.GetUri("/api/mix/v1/market/funding-time"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFundingRateHistory>>> GetFundingRateHistoryAsync(string symbol, int? page = null, int? pageSize = null, bool? nextPage = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            parameters.AddOptionalParameter("pageSize", pageSize);
            parameters.AddOptionalParameter("pageNo", page);
            parameters.AddOptionalParameter("nextPage", nextPage);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFundingRateHistory>>(_baseClient.GetUri("/api/mix/v1/market/history-fundRate"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFundingRate>> GetFundingRateAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetFundingRate>(_baseClient.GetUri("/api/mix/v1/market/current-fundRate"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetOpenInterest>(_baseClient.GetUri("/api/mix/v1/market/open-interest"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMarkPrice>> GetMarkPriceAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetMarkPrice>(_baseClient.GetUri("/api/mix/v1/market/mark-price"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetLeverageInfo>> GetLeverageInfoAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<BitgetLeverageInfo>(_baseClient.GetUri("/api/mix/v1/market/symbol-leverage"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetPositionTier>>> GetPositionsTiersAsync(BitgetProductType type, string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) },
                { "symbol", symbol.ToUpperInvariant() }
            };
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetPositionTier>>(_baseClient.GetUri("/api/mix/v1/market/queryPositionLever"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetPositionRisk>>> GetPositionRiskLimitAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetPositionRisk>>(_baseClient.GetUri("/api/mix/v1/market/open-limit"), HttpMethod.Get, ct, null).ConfigureAwait(false);
        }
    }
}

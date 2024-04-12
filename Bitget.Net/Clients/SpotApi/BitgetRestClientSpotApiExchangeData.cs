using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Enums;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiExchangeData : IBitgetRestClientSpotApiExchangeData
    {
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiExchangeData(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var result = await _baseClient.ExecuteAsync<long>("/api/spot/v1/public/time", HttpMethod.Get, ct).ConfigureAwait(false);
            return result.As(result ? DateTimeConverter.ConvertFromMilliseconds(result.Data) : default);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetNotification>>> GetNotificationsAsync(string languageType, string? noticeType = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "languageType", languageType }
            };
            parameters.AddOptionalParameter("noticeType", noticeType);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(startTime));

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetNotification>>("/api/spot/v1/notice/queryAllNotices", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetAsset>>("/api/spot/v1/public/currencies", HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetSymbol>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetSymbol>>("/api/spot/v1/public/products", HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            return await _baseClient.ExecuteAsync<BitgetTicker>("/api/spot/v1/market/ticker", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTicker>>> GetTickersAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetTicker>>("/api/spot/v1/market/tickers", HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 500);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetTrade>>("/api/spot/v1/market/fills", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(string symbol, string? tradeId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 500);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("tradeId", tradeId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetTrade>>("/api/spot/v1/market/fills-history", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetKline>>> GetKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 1000);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "period", EnumConverter.GetString(interval) },
            };
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("after", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("before", DateTimeConverter.ConvertToMilliseconds(endTime));

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetKline>>("/api/spot/v1/market/candles", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetKline>>> GetHistoricalKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime endTime, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 200);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "period", EnumConverter.GetString(interval) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) }
            };
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetKline>>("/api/spot/v1/market/history-candles", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntBetween(nameof(limit), 1, 200);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            if (mergeLevel != null)
                parameters.AddOptionalParameter("type", "step" + mergeLevel);
            parameters.AddOptionalParameter("limit", limit);

            return await _baseClient.ExecuteAsync<BitgetOrderBook>("/api/spot/v1/market/depth", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default)
        {
            limit?.ValidateIntValues(nameof(limit), 1, 5, 15, 50);

            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            if (mergeLevel != null)
                parameters.AddOptionalParameter("precision", "scale" + mergeLevel);
            parameters.AddOptionalParameter("limit", limit?.ToString() ?? "max");

            return await _baseClient.ExecuteAsync<BitgetOrderBook>("/api/spot/v1/market/merge-depth", HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFeeLevel>>("/api/spot/v1/market/spot-vip-level", HttpMethod.Get, ct).ConfigureAwait(false);
        }
    }
}

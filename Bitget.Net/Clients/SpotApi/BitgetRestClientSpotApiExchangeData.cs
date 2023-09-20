using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models;
using Bitget.Net.Interfaces.Clients.SpotApi;

namespace Bitget.Net.Clients.SpotApi
{
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
            var result = await _baseClient.ExecuteAsync<long>(_baseClient.GetUri("/api/spot/v1/public/time"), HttpMethod.Get, ct, ignoreRatelimit: true).ConfigureAwait(false);
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

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetNotification>>(_baseClient.GetUri("/api/spot/v1/notice/queryAllNotices"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(CancellationToken ct = default)
        {
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetAsset>>(_baseClient.GetUri("/api/spot/v1/public/currencies"), HttpMethod.Get, ct).ConfigureAwait(false);
        }
    }
}

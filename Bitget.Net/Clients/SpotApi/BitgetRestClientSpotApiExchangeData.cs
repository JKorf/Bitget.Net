using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Clients.SpotApi
{
    public class BitgetRestClientSpotApiExchangeData
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
    }
}

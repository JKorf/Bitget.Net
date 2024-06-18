using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Enums;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiExchangeData : IBitgetRestClientSpotApiExchangeData
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
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/public/time", BitgetExchange.RateLimiter.Overal, 1, false, 20, TimeSpan.FromSeconds(1));
            var result = await _baseClient.SendAsync<BitgetServerTime>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.ServerTime);
        }

    }
}

using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Globalization;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiAccount : IBitgetRestClientSpotApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiAccount(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetAssetValue>>> GetAssetsValuationAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/account/all-account-balance", BitgetExchange.RateLimiter.Overal, 1, true, 1, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetAssetValue>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserFee>> GetTradeFeeAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("businessType", businessType);
            parameters.Add("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/common/trade-rate", BitgetExchange.RateLimiter.Overal, 1, true, 10, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetUserFee>(request, parameters, ct).ConfigureAwait(false);
        }

    }
}

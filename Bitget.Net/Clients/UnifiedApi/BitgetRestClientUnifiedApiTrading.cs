using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.Objects.Errors;
using Bitget.Net.Interfaces.Clients.UnifiedApi;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal class BitgetRestClientUnifiedApiTrading : IBitgetRestClientUnifiedApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientUnifiedApi _baseClient;

        internal BitgetRestClientUnifiedApiTrading(BitgetRestClientUnifiedApi baseClient)
        {
            _baseClient = baseClient;
        }

    }
}

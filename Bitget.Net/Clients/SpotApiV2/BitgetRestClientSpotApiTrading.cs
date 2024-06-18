using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

    }
}

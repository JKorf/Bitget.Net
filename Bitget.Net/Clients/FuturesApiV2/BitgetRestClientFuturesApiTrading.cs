using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientFuturesApiTrading : IBitgetRestClientFuturesApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiTrading(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

    }
}

using Bitget.Net.Clients.SpotApi;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Globalization;

namespace Bitget.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    public class BitgetRestClientFuturesApiAccount : IBitgetRestClientFuturesApiAccount
    {
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiAccount(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetBalance>>(_baseClient.GetUri("/api/spot/v1/account/assets"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

    }
}

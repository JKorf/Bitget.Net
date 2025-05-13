using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.CopyTradingApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.CopyTradingApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientCopyTradingApiTrader : IBitgetRestClientCopyTradingApiTrader
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientCopyTradingApi _baseClient;

        internal BitgetRestClientCopyTradingApiTrader(BitgetRestClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCopyTradingSymbolSettings[]>> GetCopyTradeSymbolSettings(BitgetProductTypeV2 productType, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/copy/mix-trader/config-query-symbols", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetCopyTradingSymbolSettings[]>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

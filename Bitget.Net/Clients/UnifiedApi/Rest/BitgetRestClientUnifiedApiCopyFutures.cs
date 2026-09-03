using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal class BitgetRestClientUnifiedApiCopyFutures : IBitgetRestClientUnifiedApiCopyFutures
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientUnifiedApi _baseClient;

        internal BitgetRestClientUnifiedApiCopyFutures(BitgetRestClientUnifiedApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Trading Pairs

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCopyTradingSymbol[]>> GetTradingPairsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v3/copy/futures/trading-pairs", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetCopyTradingSymbol[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

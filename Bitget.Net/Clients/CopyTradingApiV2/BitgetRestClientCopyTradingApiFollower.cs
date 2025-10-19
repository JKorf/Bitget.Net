using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.CopyTradingApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bitget.Net.Clients.CopyTradingApiV2
{
    /// <inheritdoc />
    internal class BitgetRestClientCopyTradingApiFollower : IBitgetRestClientCopyTradingApiFollower
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientCopyTradingApi _baseClient;

        internal BitgetRestClientCopyTradingApiFollower(BitgetRestClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetCopyTradingMyTrader[]>> GetMyTradersAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 20, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            if (startTime is not null)
                parameters.AddMillisecondsString("startTime", startTime.Value);
            if (endTime is not null)
                parameters.AddMillisecondsString("endTime", endTime.Value);
            parameters.AddString("pageNo", pageNo);
            parameters.AddString("pageSize", pageSize);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/copy/mix-follower/query-traders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetCopyTradingMyTrader[]>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

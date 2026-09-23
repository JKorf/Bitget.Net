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
        public async Task<HttpResult<BitgetCopyTradingMyTrader[]>> GetMyTradersAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 20, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("pageNo", pageNo);
            parameters.Add("pageSize", pageSize);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/copy/mix-follower/query-traders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetCopyTradingMyTrader[]>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<HttpResult<BitgetCopyTradingCurrentOrders>> GetCurrentOrdersAsync(BitgetProductTypeV2 productType, string? idLessThan = null, string? idGreaterThan = null, DateTime? startTime = null, DateTime? endTime = null, int limit = 20, string? symbol = null, string? traderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("idGreaterThan", idGreaterThan);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            if (limit<1)
                limit = 1;
            if (limit > 100)
                limit = 100;
            parameters.Add("limit", limit);
            parameters.Add("symbol", symbol);
            parameters.Add("productType", productType);
            parameters.Add("traderId", traderId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/api/v2/copy/mix-follower/query-current-orders", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BitgetCopyTradingCurrentOrders>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}

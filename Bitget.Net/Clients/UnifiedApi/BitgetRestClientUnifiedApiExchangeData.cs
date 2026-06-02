using CryptoExchange.Net.Objects;
using CryptoExchange.Net;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Enums.Uta;
using CryptoExchange.Net.RateLimiting.Guards;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal class BitgetRestClientUnifiedApiExchangeData : IBitgetRestClientUnifiedApiExchangeData
    {
        private readonly BitgetRestClientUnifiedApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal BitgetRestClientUnifiedApiExchangeData(BitgetRestClientUnifiedApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/public/time", BitgetExchange.RateLimiter.Overall, 1, false, preventCaching: true,
                limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetServerTime>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data?.ServerTime ?? default);
        }

        #region Get Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaSpotTicker[]>> GetSpotTickersAsync(
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", ProductCategory.Spot);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/tickers", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaSpotTicker[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Tickers

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFuturesTicker[]>> GetFuturesTickersAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/tickers", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFuturesTicker[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Spot Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaSpotSymbol[]>> GetSpotSymbolsAsync(
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", ProductCategory.Spot);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/instruments", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaSpotSymbol[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Margin Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaMarginSymbol[]>> GetMarginSymbolsAsync(
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", ProductCategory.Margin);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/instruments", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaMarginSymbol[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFuturesSymbol[]>> GetFuturesSymbolsAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/instruments", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFuturesSymbol[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order Book

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOrderBook>> GetOrderBookAsync(
            ProductCategory category,
            string symbol,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/orderbook", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOrderBook>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Recent Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaTrade[]>> GetRecentTradesAsync(
            ProductCategory category,
            string symbol,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/fills", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaTrade[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Proof Of Reserves

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaProofOfReserves>> GetProofOfReservesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/proof-of-reserves", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaProofOfReserves>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOpenInterest>> GetOpenInterestAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/open-interest", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOpenInterest>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Klines

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaKline[]>> GetKlinesAsync(
            ProductCategory category,
            string symbol,
            KlineUaInterval interval,
            KlineType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("interval", interval);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/candles", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaKline[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Kline History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaKline[]>> GetKlineHistoryAsync(
            ProductCategory category,
            string symbol,
            KlineUaInterval interval,
            KlineType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("interval", interval);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/history-candles", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaKline[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Funding Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFundingRate[]>> GetFundingRateAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/current-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFundingRate[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaFundingRateHistory[]>> GetFundingRateHistoryAsync(
            ProductCategory category,
            string symbol,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("cursor", page);
            parameters.AddOptional("limit", pageSize);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/history-fund-rate", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaFundingRateHistoryWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BitgetUaFundingRateHistory[]>(result.Data?.ResultList);
        }

        #endregion

        #region Get Discount Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaDiscountRates[]>> GetDiscountRateAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/discount-rate", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaDiscountRates[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Margin Loan Interest Rates

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaLoanInterestRate>> GetMarginLoanInterestRatesAsync(string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/margin-loans", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaLoanInterestRate>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Position Tiers

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaPositionTier[]>> GetPositionTiersAsync(
            ProductCategory category,
            string? symbol = null,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("coin", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/position-tier", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(20, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaPositionTier[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Open Interest Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaOpenInterestLimit[]>> GetOpenInterestLimitAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/oi-limit", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaOpenInterestLimit[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Index Components

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUaIndexComponents>> GetIndexComponentsAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v3/market/index-components", BitgetExchange.RateLimiter.Overall, 1, false, limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            var result = await _baseClient.SendAsync<BitgetUaIndexComponents>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}

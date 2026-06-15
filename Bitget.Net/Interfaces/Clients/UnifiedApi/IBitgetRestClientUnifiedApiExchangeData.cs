using Bitget.Net.Enums.Uta;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBitgetRestClientUnifiedApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/common/public/Get-Server-Time" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/public/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get supported futures symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Instruments" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/instruments<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFuturesSymbol[]>> GetFuturesSymbolsAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get supported spot symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Instruments" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/instruments<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaSpotSymbol[]>> GetSpotSymbolsAsync(
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get supported margin symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Instruments" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/instruments<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaMarginSymbol[]>> GetMarginSymbolsAsync(
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get spot tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Tickers" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/tickers<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaSpotTicker[]>> GetSpotTickersAsync(
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get futures tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Tickers" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/tickers<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Futures category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFuturesTicker[]>> GetFuturesTickersAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get order book snapshot
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/OrderBook" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/orderbook<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 200</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaOrderBook>> GetOrderBookAsync(
            ProductCategory category,
            string symbol,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get the most recent trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Fills" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/fills<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaTrade[]>> GetRecentTradesAsync(
            ProductCategory category,
            string symbol,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get exchange's proof of reserves
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Proof-Of-Reserves" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/proof-of-reserves<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaProofOfReserves>> GetProofOfReservesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get open interest for symbol(s)
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Open-Interest" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/open-interest<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaOpenInterest>> GetOpenInterestAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get klines/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/candles<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="type">["<c>type</c>"] Kline type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaKline[]>> GetKlinesAsync(
            ProductCategory category,
            string symbol,
            KlineUaInterval interval,
            KlineType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get kline history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-History-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/history-candles<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="interval">["<c>interval</c>"] Kline interval</param>
        /// <param name="type">["<c>type</c>"] Kline type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaKline[]>> GetKlineHistoryAsync(
            ProductCategory category,
            string symbol,
            KlineUaInterval interval,
            KlineType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get current funding rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Current-Funding-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/current-fund-rate<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFundingRate[]>> GetFundingRateAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-History-Funding-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/history-fund-rate<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="page">["<c>cursor</c>"] Page</param>
        /// <param name="pageSize">["<c>limit</c>"] Page size, max 100</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFundingRateHistory[]>> GetFundingRateHistoryAsync(
            ProductCategory category,
            string symbol,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get margin loan discount rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Discount-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/discount-rate<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaDiscountRates[]>> GetDiscountRateAsync(CancellationToken ct = default);

        /// <summary>
        /// Get margin loan interest rates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Margin-Loans" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/margin-loans<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaLoanInterestRate>> GetMarginLoanInterestRatesAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Position-Tier-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/position-tier<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaPositionTier[]>> GetPositionTiersAsync(
            ProductCategory category,
            string? symbol = null,
            string? asset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get open interest limit
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Contracts-Oi" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/oi-limit<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaOpenInterestLimit[]>> GetOpenInterestLimitAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get index components
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/public/Get-Index-Components" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/index-components<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaIndexComponents>> GetIndexComponentsAsync(string symbol, CancellationToken ct = default);

    }
}

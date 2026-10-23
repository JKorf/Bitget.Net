using Bitget.Net.Enums;
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-server-time" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get announcements
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-coins" /><br />
        /// Endpoint:<br />
        /// GET api/v3/public/annoucements
        /// </para>
        /// </summary>
        /// </summary>
        /// <param name="type">["<c>annType</c>"] Filter by type</param>
        /// <param name="language">["<c>language</c>"] Language</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="cursor">["<c>cursor</c>"] Page cursor</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetAnnouncement[]>> GetAnnouncementsAsync(
            AnnouncementType? type = null,
            string? language = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? cursor = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get list of supported assets and their networks
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-coins" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/coins
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BitgetAsset[]>> GetAssetsAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get supported futures symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-instruments" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-instruments" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-instruments" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-tickers" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-tickers" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-order-book" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-recent-public-fills" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/public-config#get-proof-of-reserves" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/derivatives#get-open-interest-oi" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-kline-candlestick" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/market-data#get-kline-candlestick-history" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/derivatives#get-current-funding-rate" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/derivatives#get-funding-rate-history" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/trading-risk-rules#get-discount-rate" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/trading-risk-rules#get-margin-loan" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/margin-loans<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaLoanInterestRate>> GetMarginLoanInterestRatesAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get position tiers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/docs/catalog/market/trading-risk-rules#get-position-tier" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/trading-risk-rules#get-open-interest-limit" /><br />
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
        /// <a href="https://www.bitget.com/docs/catalog/market/derivatives#get-index-price-components" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/index-components<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaIndexComponents>> GetIndexComponentsAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get open interest history for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/docs/catalog/market/derivatives#get-open-interest-history" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/market/open-interest-history<br />
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="period">["<c>period</c>"] The period, for example `1h`. Supports 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<BitgetUaOpenInterestHistory[]>> GetOpenInterestHistoryAsync(
            string symbol,
            string period,
            CancellationToken ct = default);

    }
}

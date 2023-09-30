using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBitgetRestClientSpotApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get server notifications of the last month
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#notice" /></para>
        /// </summary>
        /// <param name="languageType">The language type</param>
        /// <param name="noticeType">Filter by notice type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetNotification>>> GetNotificationsAsync(string languageType, string? noticeType = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of supported assets on the platform
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-list" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a list of supported symbols on the platform
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-symbols" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetSymbol>>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a single symbol ticker
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-single-ticker" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get all symbol tickers
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-all-tickers" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTicker>>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Get recent trades
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-recent-trades" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="limit">Results to return, max 500</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-market-trades" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="tradeId">Filter by trade id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Results to return, max 500</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(string symbol, string? tradeId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="interval">The kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Results to return, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetKline>>> GetKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical kline/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-history-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="interval">The kline interval</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Results to return, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetKline>>> GetHistoricalKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime endTime, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-depth" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="mergeLevel">Merge level for entries</param>
        /// <param name="limit">Results to return, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get merged order book
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-merged-depth-data" /></para>
        /// </summary>
        /// <param name="symbol">The id of the symbol</param>
        /// <param name="mergeLevel">Merge level for entires</param>
        /// <param name="limit">Results to return, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get limits according to the VIP levels
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default);
    }
}

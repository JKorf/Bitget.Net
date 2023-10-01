using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBitgetRestClientFuturesApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbols" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesSymbol>>> GetSymbolsAsync(BitgetProductType type, CancellationToken ct = default);

        /// <summary>
        /// Get merged order book
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-merged-depth-data" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="mergeLevel">Merge level for entries</param>
        /// <param name="limit">Results to return, 1/5/15/50, defaults to 100</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-depth" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">Results to return, 1/5/15/50/100</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get ticker
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-single-symbol-ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get tickers
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbol-ticker" /></para>
        /// </summary>
        /// <param name="type">Type of symbols</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesTicker>>> GetTickersAsync(BitgetProductType type, CancellationToken ct = default);

        /// <summary>
        /// Get fee information
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#vip-fee-rate" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get recent trades for a symbol
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-recent-fills" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history for a symbol
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-fills" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="maxTradeId">Return trades before this id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetTradeHistoryAsync(string symbol, string? maxTradeId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get klines/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="priceType">Price type</param>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get klines/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="priceType">Price type</param>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get index klines/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-index-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="priceType">Price type</param>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalIndexKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark klines/candlestick data
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-mark-candle-data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="priceType">Price type</param>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalMarkKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get the index price for a symbol
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-index-price" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetIndexPrice>> GetIndexPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get next funding time
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-next-funding-time" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-funding-rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="nextPage">Whether to query the next page default false</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFundingRateHistory>>> GetFundingRateHistoryAsync(string symbol, int? page = null, int? pageSize = null, bool? nextPage = null, CancellationToken ct = default);

        /// <summary>
        /// Get current funding rate
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingRate>> GetFundingRateAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get open interest rate
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get mark price
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-mark-price" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetMarkPrice>> GetMarkPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get leverage info
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-leverage" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetLeverageInfo>> GetLeverageInfoAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get position tiers
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-position-tier" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPositionTier>>> GetPositionsTiersAsync(BitgetProductType type, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get position risk limit
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-risk-position-limit" /></para>
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPositionRisk>>> GetPositionRiskLimitAsync(CancellationToken ct = default);
    }
}

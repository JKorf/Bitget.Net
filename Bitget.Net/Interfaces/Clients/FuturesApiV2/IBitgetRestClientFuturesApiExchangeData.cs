using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBitgetRestClientFuturesApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://www.bitget.com/api-doc/common/public/Get-Server-Time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get list of contracts
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-All-Symbols-Contracts" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetContract>>> GetContractsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of VIP levels and fee rates
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-VIP-Fee-Rate" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetVipFeeRate>>> GetVipFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get futures order book
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Merge-Depth" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="productType">Product type</param>
        /// <param name="mergeStep">Merge step</param>
        /// <param name="limit">The book depth, 1, 5, 15, 50, 100 or -1. -1 will request the max gear of the symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrderBook>> GetOrderBookAsync(BitgetProductTypeV2 productType, string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures ticker
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Ticker" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get all futures tickers
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-All-Symbol-Ticker" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesTicker>>> GetTickersAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Recent-Fills" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(BitgetProductTypeV2 productType, string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trades
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Fills-History" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(BitgetProductTypeV2 productType, string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline/candlestick data
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Candle-Data" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="klineType">Price type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, KlineType? klineType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical market price kline/candlestick data
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-History-Candle-Data" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical index price kline/candlestick data
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-History-Index-Candle-Data" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalIndexPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical mark price kline/candlestick data
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-History-Mark-Candle-Data" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalMarkPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get open interest
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Open-Interest" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get next funding time
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Symbol-Next-Funding-Time" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get prices
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Symbol-Price" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesPrices>> GetPricesAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get historical funding rate
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-History-Funding-Rate" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page number</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFundingRate>>> GetHistoricalFundingRateAsync(BitgetProductTypeV2 productType, string symbol, int? pageSize = null, int? page = null, CancellationToken ct = default);

        /// <summary>
        /// Get current funding rate
        /// <para><a href="https://www.bitget.com/api-doc/contract/market/Get-Current-Funding-Rate" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingRate>> GetFundingRateAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get position tiers
        /// <para><a href="https://www.bitget.com/api-doc/contract/position/Get-Query-Position-Lever" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPositionTier>>> GetPositionTiersAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);
    }
}

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
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/common/public/Get-Server-Time" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/public/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get list of contracts
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-All-Symbols-Contracts" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/contracts
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetContract[]>> GetContractsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of VIP levels and fee rates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-VIP-Fee-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/vip-fee-rate
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetVipFeeRate[]>> GetVipFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get futures order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Merge-Depth" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/merge-depth
        /// </para>
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
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Ticker" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/ticker
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get all futures tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-All-Symbol-Ticker" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/tickers
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTicker[]>> GetTickersAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Recent-Fills" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/fills
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTrade[]>> GetRecentTradesAsync(BitgetProductTypeV2 productType, string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Fills-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/fills-history
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTrade[]>> GetTradesAsync(BitgetProductTypeV2 productType, string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/candles
        /// </para>
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
        Task<WebCallResult<BitgetFuturesKline[]>> GetKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, KlineType? klineType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical market price kline/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-History-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/history-candles
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical index price kline/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-History-Index-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/history-index-candles
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalIndexPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical mark price kline/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-History-Mark-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/history-mark-candles
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesKline[]>> GetHistoricalMarkPriceKlinesAsync(BitgetProductTypeV2 productType, string symbol, BitgetFuturesKlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get open interest
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Open-Interest" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/open-interest
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get next funding time
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Symbol-Next-Funding-Time" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/funding-time
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get prices
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Symbol-Price" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/symbol-price
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesPrices>> GetPricesAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get historical funding rate
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-History-Funding-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/history-fund-rate
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page number</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFundingRate[]>> GetHistoricalFundingRateAsync(BitgetProductTypeV2 productType, string symbol, int? pageSize = null, int? page = null, CancellationToken ct = default);

        /// <summary>
        /// Get current funding rate for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Current-Funding-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/current-fund-rate
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetCurrentFundingRate>> GetFundingRateAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get current funding rate for all symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Current-Funding-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/current-fund-rate
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetCurrentFundingRate[]>> GetFundingRatesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Get position tiers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/position/Get-Query-Position-Lever" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/query-position-lever
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionTier[]>> GetPositionTiersAsync(BitgetProductTypeV2 productType, string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get contracts notional position value limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/market/Get-Contracts-Oi" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/market/oi-limit
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOiLimit[]>> GetOiLimitsAsync(BitgetProductTypeV2 productType, string? symbol = null, CancellationToken ct = default);
    }
}

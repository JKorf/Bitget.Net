using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBitgetRestClientSpotApiExchangeData
    {
        /// <summary>
        /// Get the server time
        /// <para><a href="https://www.bitget.com/api-doc/common/public/Get-Server-Time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get list of supported assets and their networks
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Coin-List" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of supported symbols and their trading rules
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Symbols" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetSymbol>>> GetSymbolsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of VIP levels and fee rates
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-VIP-Fee-Rate" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetVipFeeRate>>> GetVipFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get tickers
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Tickers" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTicker>>> GetTickersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Orderbook" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="mergeStep">Merge step</param>
        /// <param name="limit">Max number of rows</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline/candlestick data
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Candle-Data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetKline>>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical kline data
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-History-Candle-Data" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetKline>>> GetHistoricalKlinesAsync(string symbol, KlineInterval interval, DateTime endTime, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get the most recent trades on the symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Recent-Trades" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trades
        /// <para><a href="https://www.bitget.com/api-doc/spot/market/Get-Market-Trades" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);
    }
}

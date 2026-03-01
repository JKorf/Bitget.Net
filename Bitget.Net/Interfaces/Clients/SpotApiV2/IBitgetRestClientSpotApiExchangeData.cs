using Bitget.Net.Enums;
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
        /// Get announcements
        /// </summary>
        /// <param name="type">Filter by type</param>
        /// <param name="language">Language</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="cursor">Page cursor</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetAnnouncement[]>> GetAnnouncementsAsync(
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
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Coin-List" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/public/coins
        /// </para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetAsset[]>> GetAssetsAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of supported symbols and their trading rules
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Symbols" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/public/symbols
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetSymbol[]>> GetSymbolsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of VIP levels and fee rates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-VIP-Fee-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/vip-fee-rate
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetVipFeeRate[]>> GetVipFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Tickers" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTicker[]>> GetTickersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Orderbook" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/orderbook
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="mergeStep">Merge step</param>
        /// <param name="limit">Max number of rows</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeStep = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline/candlestick data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/candles
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetKline[]>> GetKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical kline data
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-History-Candle-Data" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/history-candles
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetKline[]>> GetHistoricalKlinesAsync(string symbol, KlineInterval interval, DateTime endTime, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get the most recent trades on the symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Recent-Trades" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/fills
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTrade[]>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/market/Get-Market-Trades" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/market/fills-history
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTrade[]>> GetTradesAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);
    }
}

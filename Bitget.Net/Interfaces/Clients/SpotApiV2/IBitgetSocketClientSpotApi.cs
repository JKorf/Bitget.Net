using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget spot streams
    /// </summary>
    public interface IBitgetSocketClientSpotApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Get the shared socket subscription client
        /// </summary>
        public IBitgetSocketClientSpotApiShared SharedClient { get; }

        /// <summary>
        /// Subscribe to ticker updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Tickers-Channel" /></para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Tickers-Channel" /></para>
        /// </summary>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Trades-Channel" /></para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Trades-Channel" /></para>
        /// </summary>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Candlesticks-Channel" /></para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Candlesticks-Channel" /></para>
        /// </summary>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Depth-Channel" /></para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updates after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/public/Depth-Channel" /></para>
        /// </summary>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updatesa after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/private/Order-Channel" /></para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BitgetOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/private/Fill-Channel" /></para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BitgetUserTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trigger order updates
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/private/Plan-Order-Channel" /></para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(Action<DataEvent<IEnumerable<BitgetTriggerOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates
        /// <para><a href="https://www.bitget.com/api-doc/spot/websocket/private/Account-Channel" /></para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BitgetBalanceUpdate>>> handler, CancellationToken ct = default);
    }
}
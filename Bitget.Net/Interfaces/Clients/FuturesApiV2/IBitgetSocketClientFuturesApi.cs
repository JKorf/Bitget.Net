using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Bitget futures streams
    /// </summary>
    public interface IBitgetSocketClientFuturesApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Get the shared socket subscription client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        IBitgetSocketClientFuturesApiShared SharedClient { get; }
        
        /// <summary>
        /// Subscribe to ticker updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Tickers-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: ticker)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetFuturesTickerUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for multiple symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Tickers-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: ticker)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/New-Trades-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: trade)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for multiple symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/New-Trades-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: trade)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Candlesticks-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: candle{interval})
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, string symbol, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<BitgetFuturesKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Candlesticks-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: candle{interval})
        /// </para>
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="symbols">Symbols, for example `ETHUSDT`</param>
        /// <param name="interval">Interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<BitgetFuturesKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Order-Book-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: books{depth})
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbols, for example `ETHUSDT`</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updates after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/public/Order-Book-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/public (channel: books{depth})
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">Symbols, for example `ETHUSDT`</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updates after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account balance updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Account-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: account)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesBalanceUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: positions)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: fill)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesUserTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: orders)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesOrderUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trigger order updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Plan-Order-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: orders-algo)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesTriggerOrderUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position history/closing updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/History-Positions-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: positions-history)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionHistoryUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionHistoryUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to equity updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/Equity-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: equity)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToEquityUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetEquityUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ADL notification updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/websocket/private/ADL-Notification-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v2/ws/private (channel: adl-noti)
        /// </para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        Task<CallResult<UpdateSubscription>> SubscribeToAdlUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetAdlNotification[]>> handler, CancellationToken ct = default);
    }
}

using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget spot streams
    /// </summary>
    public interface IBitgetSocketClientUnifiedApi : ISocketApiClient<BitgetCredentials>, IDisposable
    {
        /// <summary>
        /// Subscribe to ticker updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Tickers-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: ticker)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(AccountType type, string symbol, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Tickers-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: ticker)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(AccountType type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Candlesticks-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: kline)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(AccountType type, string symbol, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Candlesticks-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: kline)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(AccountType type, IEnumerable<string> symbols, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Order-Book-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: depth)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="depth">The depth, 1, 5, 50 or null for incremental updates</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(AccountType type, string symbol, int? depth, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Order-Book-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: depth)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="depth">The depth, 1, 5, 50 or null for incremental updates</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(AccountType type, IEnumerable<string> symbols, int? depth, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/New-Trades-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: publicTrade)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(AccountType type, string symbol, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/New-Trades-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: publicTrade)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="symbols">The symbols, for example `ETHUSDT`</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(AccountType type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to liquidation updates for symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/public/Liquidation-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/public (channel: liquidation)
        /// </para>
        /// </summary>
        /// <param name="type">Symbol type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(AccountType type, Action<DataEvent<BitgetUaLiquidationUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account balance updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Account-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: account)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BitgetUaAccountUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Positions-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: position)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitgetUaPositionUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Order-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: order)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitgetUaOrder[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Fill-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: fill)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BitgetUaUserTrade[]>> handler, CancellationToken ct = default);
    }
}

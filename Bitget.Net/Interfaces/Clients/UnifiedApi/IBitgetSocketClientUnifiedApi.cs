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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(ProductCategory type, string symbol, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(ProductCategory type, string symbol, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(ProductCategory type, string symbol, int? depth, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, int? depth, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(ProductCategory type, string symbol, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(ProductCategory type, Action<DataEvent<BitgetUaLiquidationUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BitgetUaAccountUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitgetUaPositionUpdate[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitgetUaOrder[]>> handler, CancellationToken ct = default);

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
        Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BitgetUaUserTrade[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Fast-Fill-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: fast-fill)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToFastUserTradeUpdatesAsync(Action<DataEvent<BitgetUaFastUserTrade>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user strategy order updates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Strategy-Order-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: strategy-order)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToStrategyOrderUpdatesAsync(Action<DataEvent<BitgetUaStrategyOrder[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user ADL notifications
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/ADL-Notification-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (channel: adl-notification)
        /// </para>
        /// </summary>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToAdlUpdatesAsync(Action<DataEvent<BitgetUaAdlUpdate[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Place-Order-Channel" /><br />
        /// Endpoint:<br />
        /// WSS /v3/ws/private (topic: place-order)
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>qty</c>"] Quantity</param>
        /// <param name="price">["<c>price</c>"] Order limit price</param>
        /// <param name="timeInForce">["<c>timeInForce</c>"] Time in force</param>
        /// <param name="positionSide">["<c>posSide</c>"] Position side</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Reduce only</param>
        /// <param name="stpMode">["<c>stpMode</c>"] Stp mode</param>
        /// <param name="tpTriggerBy">["<c>tpTriggerBy</c>"] Take profit trigger type</param>
        /// <param name="slTriggerBy">["<c>slTriggerBy</c>"] Stop loss trigger type</param>
        /// <param name="tpTriggerPrice">["<c>takeProfit</c>"] Take profit trigger price</param>
        /// <param name="slTriggerPrice">["<c>stopLoss</c>"] Stop loss trigger price</param>
        /// <param name="tpOrderType">["<c>tpOrderType</c>"] Take profit order type</param>
        /// <param name="slOrderType">["<c>slOrderType</c>"] Stop loss order type</param>
        /// <param name="tpLimitPrice">["<c>tpLimitPrice</c>"] Take profit limit price</param>
        /// <param name="slLimitPrice">["<c>slLimitPrice</c>"] Stop loss limit price</param>
        /// <param name="marginMode">["<c>marginMode</c>"] Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        public Task<QueryResult<BitgetUaOrderResult>> PlaceOrderAsync(
            ProductCategory category,
            string symbol,
            OrderSide side,
            OrderType orderType,
            decimal quantity,
            decimal? price = null,
            TimeInForce? timeInForce = null,
            PositionSide? positionSide = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            StpMode? stpMode = null,
            PriceTriggerType? tpTriggerBy = null,
            PriceTriggerType? slTriggerBy = null,
            decimal? tpTriggerPrice = null,
            decimal? slTriggerPrice = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            MarginMode? marginMode = null,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an open order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/websocket/private/Modify-Order-Channel" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/modify-order<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="quantity">["<c>qty</c>"] New quantity</param>
        /// <param name="price">["<c>price</c>"] New price</param>
        /// <param name="autoCancel">["<c>autoCancel</c>"] Will the original order be canceled if the order modification fails</param>
        /// <param name="ct">Cancellation token</param>
        Task<QueryResult<BitgetUaOrderResult>> EditOrderAsync(
            ProductCategory category,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            bool? autoCancel = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel an open order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Cancel-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/cancel-order<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<QueryResult<BitgetUaOrderResult>> CancelOrderAsync(
            ProductCategory category,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);
    }
}

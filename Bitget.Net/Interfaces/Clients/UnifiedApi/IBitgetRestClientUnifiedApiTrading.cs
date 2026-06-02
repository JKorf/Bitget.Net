using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.Uta;
using CryptoExchange.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBitgetRestClientUnifiedApiTrading
    {
        /// <summary>
        /// Place a new order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Place-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/place-order<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>qty</c>"] Quantity. In quote asset for market buy orders</param>
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
        Task<WebCallResult<BitgetUaOrderResult>> PlaceOrderAsync(
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
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Modify-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/modify-order<br />
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="quantity">["<c>qty</c>"] New quantity</param>
        /// <param name="price">["<c>price</c>"] New price</param>
        /// <param name="autoCancel">["<c>autoCancel</c>"] Will the original order be canceled if the order modification fails</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrderResult>> EditOrderAsync(
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
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrderResult>> CancelOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel all orders matching the parameters
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Cancel-All-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/cancel-symbol-order<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaBatchResult[]>> CancelAllOrdersAsync(
            ProductCategory category,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Close-All-Positions" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/close-positions<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="positionSide">["<c>posSide</c>"] Position side</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaBatchResult[]>> ClosePositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get order by id
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Order-Details" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/trade/order-info<br />
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrder>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Order-Pending" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/trade/unfilled-orders<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrders>> GetOpenOrdersAsync(
            ProductCategory? category = null,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Order-Fills" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/trade/fills<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaUserTrades>> GetUserTradesAsync(
            ProductCategory? category = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get open positions
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Position" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/position/current-position<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Product category</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="positionSide">["<c>posSide</c>"] Filter by position side</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaPosition[]>> GetPositionsAsync(
            ProductCategory category,
            string? symbol = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get position history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Position-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/position/history-position<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaPositionHistory>> GetPositionHistoryAsync(
            ProductCategory category,
            string? symbol = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get ADL ranking
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Position-ADL-Rank" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/position/adlRank<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaAdlRank[]>> GetPositionAdlRankAsync(CancellationToken ct = default);

        /// <summary>
        /// Get max open available
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/trade/Get-Max-Open-Available" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/max-open-available<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="quantity">["<c>size</c>"] Order quantity</param>
        /// <param name="price">["<c>price</c>"] Order price</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaMaxOpenAvailable>> GetMaxOpenAvailableAsync(
            ProductCategory category,
            string symbol,
            OrderType orderType,
            OrderSide side,
            decimal quantity,
            decimal? price = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place a new strategy order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/strategy/Place-Strategy-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/place-strategy-order<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="type">["<c>type</c>"] Type of strategy order</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="tpslMode">["<c>tpslMode</c>"] TP/SL mode</param>
        /// <param name="quantity">["<c>qty</c>"] Order quantity</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="positionSide">["<c>posSide</c>"] Position side</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Reduce only</param>
        /// <param name="tpTriggerBy">["<c>tpTriggerBy</c>"] Take profit trigger by</param>
        /// <param name="slTriggerBy">["<c>slTriggerBy</c>"] Stop loss trigger by</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] Take profit trigger price</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] Stop loss trigger price</param>
        /// <param name="tpOrderType">["<c>tpOrderType</c>"] Take profit order type</param>
        /// <param name="slOrderType">["<c>slOrderType</c>"] Stop loss order type</param>
        /// <param name="tpLimitPrice">["<c>tpLimitPrice</c>"] Take profit limit price</param>
        /// <param name="slLimitPrice">["<c>slLimitPrice</c>"] Stop loss limit price</param>
        /// <param name="triggerBy">["<c>triggerBy</c>"] Trigger order trigger price type</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="triggerOrderType">["<c>triggerOrderType</c>"] Trigger order type</param>
        /// <param name="triggerOrderPrice">["<c>triggerOrderPrice</c>"] Trigger order price</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrderResult>> PlaceStrategyOrderAsync(
            ProductCategory category,
            string symbol,
            StrategyType? type = null,
            string? clientOrderId = null,
            TpslMode? tpslMode = null,
            decimal? quantity = null,
            OrderSide? side = null,
            PositionSide? positionSide = null,
            bool? reduceOnly = null,
            TriggerPriceType? tpTriggerBy = null,
            TriggerPriceType? slTriggerBy = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            TriggerPriceType? triggerBy = null,
            decimal? triggerPrice = null,
            OrderType? triggerOrderType = null,
            decimal? triggerOrderPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/strategy/Modify-Strategy-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/modify-strategy-order<br />
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="quantity">["<c>qty</c>"] Partial Tp/sl quantity</param>
        /// /// <param name="tpTriggerBy">["<c>tpTriggerBy</c>"] Take profit trigger by</param>
        /// <param name="slTriggerBy">["<c>slTriggerBy</c>"] Stop loss trigger by</param>
        /// <param name="takeProfit">["<c>takeProfit</c>"] Take profit trigger price</param>
        /// <param name="stopLoss">["<c>stopLoss</c>"] Stop loss trigger price</param>
        /// <param name="tpOrderType">["<c>tpOrderType</c>"] Take profit order type</param>
        /// <param name="slOrderType">["<c>slOrderType</c>"] Stop loss order type</param>
        /// <param name="tpLimitPrice">["<c>tpLimitPrice</c>"] Take profit limit price</param>
        /// <param name="slLimitPrice">["<c>slLimitPrice</c>"] Stop loss limit price</param>
        /// <param name="triggerBy">["<c>triggerBy</c>"] Trigger order trigger price type</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="triggerOrderType">["<c>triggerOrderType</c>"] Trigger order type</param>
        /// <param name="triggerOrderPrice">["<c>triggerOrderPrice</c>"] Trigger order price</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaOrderResult>> EditStrategyOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            TriggerPriceType? tpTriggerBy = null,
            TriggerPriceType? slTriggerBy = null,
            decimal? takeProfit = null,
            decimal? stopLoss = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            TriggerPriceType? triggerBy = null,
            decimal? triggerPrice = null,
            OrderType? triggerOrderType = null,
            decimal? triggerOrderPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel a strategy order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/strategy/Cancel-Strategy-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/trade/cancel-strategy-order<br />
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult> CancelStrategyOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get open strategy orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/strategy/Get-Unfilled-Strategy-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/trade/unfilled-strategy-orders<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaStrategyOrder[]>> GetOpenStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/strategy/Get-History-Strategy-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/trade/history-strategy-orders<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaStrategyOrders>> GetClosedStrategyOrdersAsync(
            ProductCategory category,
            StrategyType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

    }
}

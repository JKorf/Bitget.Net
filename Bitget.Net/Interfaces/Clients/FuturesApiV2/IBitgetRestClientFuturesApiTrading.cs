using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Bitget trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBitgetRestClientFuturesApiTrading
    {
        /// <summary>
        /// Get a position
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/position/get-single-position" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/position/single-position
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPosition[]>> GetPositionAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get all positions
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/position/get-all-position" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/position/all-position
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPosition[]>> GetPositionsAsync(BitgetProductTypeV2 productType, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get position history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/position/Get-History-Position" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/position/history-position
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Filter by product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionHistory>> GetPositionHistoryAsync(BitgetProductTypeV2? productType = null, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Place-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/place-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="type">["<c>orderType</c>"] Order type</param>
        /// <param name="marginMode">["<c>marginMode</c>"] Margin mode</param>
        /// <param name="quantity">["<c>size</c>"] Quantity</param>
        /// <param name="price">["<c>price</c>"] Limit price</param>
        /// <param name="timeInForce">["<c>force</c>"] Time in force</param>
        /// <param name="tradeSide">["<c>tradeSide</c>"] Trade side</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Reduce only order</param>
        /// <param name="takeProfitPrice">["<c>presetStopSurplusPrice</c>"] Take profit price</param>
        /// <param name="stopLossPrice">["<c>presetStopLossPrice</c>"] Stop loss price</param>
        /// <param name="takeProfitLimitPrice">["<c>presetStopSurplusExecutePrice</c>"] Take profit limit order price</param>
        /// <param name="stopLossLimitPrice">["<c>presetStopLossExecutePrice</c>"] Stop loss limit order price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> PlaceOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            OrderSide side,
            OrderType type,
            MarginMode marginMode,
            decimal quantity,
            decimal? price = null,
            TimeInForce? timeInForce = null,
            TradeSide? tradeSide = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            decimal? takeProfitPrice = null,
            decimal? stopLossPrice = null,
            decimal? takeProfitLimitPrice = null,
            decimal? stopLossLimitPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders in a single call
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Batch-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/batch-place-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="marginMode">["<c>marginMode</c>"] Margin mode</param>
        /// <param name="orders">["<c>orderList</c>"] Orders</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<CallResult<BitgetOrderId>[]>> PlaceMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            MarginMode marginMode,
            IEnumerable<BitgetFuturesPlaceOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Modify-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/modify-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id. Either this or orderId should be provided</param>
        /// <param name="newClientOrderId">["<c>newClientOid</c>"] New client order id</param>
        /// <param name="newPrice">["<c>newPrice</c>"] New price</param>
        /// <param name="newQuantity">["<c>newSize</c>"] New quantity</param>
        /// <param name="newTakeProfit">["<c>newPresetStopSurplusPrice</c>"] New take profit price</param>
        /// <param name="newStopLossPrice">["<c>newPresetStopLossPrice</c>"] New stop loss price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> EditOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            string? newClientOrderId = null,
            decimal? newPrice = null,
            decimal? newQuantity = null,
            decimal? newTakeProfit = null,
            decimal? newStopLossPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Cancel-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/cancel-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id. Either this or orderId should be provided</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> CancelOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            string? marginAsset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders. Make sure to check the individual order responses for success
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Batch-Cancel-Orders" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/batch-cancel-orders
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="orders">["<c>orderIdList</c>"] Orders to cancel</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            IEnumerable<BitgetCancelOrderRequest> orders,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get order details
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Get-Order-Details" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/detail
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrder>> GetOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get open orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Get-Orders-Pending" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/orders-pending
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="status">["<c>status</c>"] Filter by status</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrders>> GetOpenOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            OrderStatus? status = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get closed orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Get-Orders-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/orders-history
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrders>> GetClosedOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel all orders matching the filters
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Cancel-All-Orders" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/cancel-all-orders
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Get-Order-Fills" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/fills
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesUserTrades>> GetUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get historical user trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Get-Fill-History" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/fill-history
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesUserTrades>> GetHistoricalUserTradesAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Close positions by market order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/trade/Flash-Close-Position" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/close-positions
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="side">["<c>holdSide</c>"] Position side; only respected if in hedge mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> ClosePositionsAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            PositionSide? side = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place a take profit / stop loss order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Place-Tpsl-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/place-tpsl-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="planType">["<c>planType</c>"] Plan type, TakeProfit, StopLoss, TailingStop, PositionTakeProfit or PositionStopLoss</param>
        /// <param name="quantity">["<c>size</c>"] Quantity</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="orderPrice">["<c>executePrice</c>"] Order limit price</param>
        /// <param name="triggerPriceType">["<c>triggerType</c>"] Trigger price type</param>
        /// <param name="hedgeModePositionSide">["<c>holdSide</c>"] Position side for when in hedge mode, either this or oneWaySide should be provided</param>
        /// <param name="oneWaySide">["<c>holdSide</c>"] Order side for when in one way mode, either this or hedgeModePositionSide should be provided</param>
        /// <param name="trailingStopRate">["<c>rangeRate</c>"] Tailing stop rate</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> PlaceTpSlOrderAsync(
           BitgetProductTypeV2 productType,
           string symbol,
           string marginAsset,
           PlanType planType,
           decimal? quantity,
           decimal triggerPrice,
           decimal? orderPrice = null,
           TriggerPriceType? triggerPriceType = null,
           PositionSide? hedgeModePositionSide = null,
           OrderSide? oneWaySide = null,
           decimal? trailingStopRate = null,
           string? clientOrderId = null,
           CancellationToken ct = default);

        /// <summary>
        /// Place a new trigger order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Place-Plan-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/place-plan-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="planType">["<c>planType</c>"] Plan type</param>
        /// <param name="marginMode">["<c>marginMode</c>"] Margin mode</param>
        /// <param name="side">["<c>side</c>"] Order side</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="quantity">["<c>size</c>"] Order quantity</param>
        /// <param name="triggerPrice">["<c>triggerPrice</c>"] Trigger price</param>
        /// <param name="orderPrice">["<c>price</c>"] Order limit price</param>
        /// <param name="triggerPriceType">["<c>triggerType</c>"] Trigger price type</param>
        /// <param name="tradeSide">["<c>tradeSide</c>"] Trade side</param>
        /// <param name="trailingStopRate">["<c>callbackRatio</c>"] Trailing stop rate</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="reduceOnly">["<c>reduceOnly</c>"] Reduce only</param>
        /// <param name="takeProfitTriggerPrice">["<c>stopSurplusTriggerPrice</c>"] Take profit trigger price</param>
        /// <param name="takeProfitOrderPrice">["<c>stopSurplusExecutePrice</c>"] Take profit order price</param>
        /// <param name="takeProfitPriceType">["<c>stopSurplusTriggerType</c>"] Take profit price type</param>
        /// <param name="stopLossTriggerPrice">["<c>stopLossTriggerPrice</c>"] Stop loss trigger price</param>
        /// <param name="stopLossOrderPrice">["<c>stopLossExecutePrice</c>"] Stop loss order price</param>
        /// <param name="stopLossPriceType">["<c>stopLossTriggerType</c>"] Stop loss price type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> PlaceTriggerOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            TriggerPlanType planType,
            MarginMode marginMode,
            OrderSide side,
            OrderType orderType,
            decimal quantity,
            decimal triggerPrice,
            decimal? orderPrice = null,
            TriggerPriceType? triggerPriceType = null,
            TradeSide? tradeSide = null,
            decimal? trailingStopRate = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            decimal? takeProfitTriggerPrice = null,
            decimal? takeProfitOrderPrice = null,
            TriggerPriceType? takeProfitPriceType = null,
            decimal? stopLossTriggerPrice = null,
            decimal? stopLossOrderPrice = null,
            TriggerPriceType? stopLossPriceType = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get trigger order sub orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Plan-Sub-Orders" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/plan-sub-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="triggerOrderId">["<c>planOrderId</c>"] Trigger order id</param>
        /// <param name="planType">["<c>planType</c>"] Plan type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            BitgetProductTypeV2 productType,
            string triggerOrderId,
            TriggerPlanType planType,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an existing trigger order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Modify-Plan-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/modify-plan-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="newQuantity">["<c>size</c>"] New quantity</param>
        /// <param name="newPrice">["<c>price</c>"] New price</param>
        /// <param name="newTrailingStopRate">["<c>callbackRatio</c>"] New trailing stop rate</param>
        /// <param name="newTriggerPrice">["<c>triggerPrice</c>"] New trigger price</param>
        /// <param name="newTriggerType">["<c>triggerType</c>"] New trigger price type</param>
        /// <param name="newTakeProfitTriggerPrice">["<c>stopSurplusTriggerPrice</c>"] New take profit trigger price</param>
        /// <param name="newTakeProfitOrderPrice">["<c>stopSurplusExecutePrice</c>"] New take profit order price</param>
        /// <param name="newTakeProfitPriceType">["<c>stopSurplusTriggerType</c>"] New take profit price type</param>
        /// <param name="newStopLossTriggerPrice">["<c>stopLossTriggerPrice</c>"] New stop loss trigger price</param>
        /// <param name="newStopLossOrderPrice">["<c>stopLossExecutePrice</c>"] New stop loss order price</param>
        /// <param name="newStopLossPriceType">["<c>stopLossTriggerType</c>"] New stop loss trigger price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> EditTriggerOrderAsync(
            BitgetProductTypeV2 productType,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? newQuantity = null,
            decimal? newPrice = null,
            decimal? newTrailingStopRate = null,
            decimal? newTriggerPrice = null,
            TriggerPriceType? newTriggerType = null,
            decimal? newTakeProfitTriggerPrice = null,
            decimal? newTakeProfitOrderPrice = null,
            TriggerPriceType? newTakeProfitPriceType = null,
            decimal? newStopLossTriggerPrice = null,
            decimal? newStopLossOrderPrice = null,
            TriggerPriceType? newStopLossPriceType = null,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an existing tp/sl order
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Modify-Tpsl-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/modify-tpsl-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id, either this or orderId should be provided</param>
        /// <param name="newTriggerPrice">["<c>triggerPrice</c>"] New trigger price</param>
        /// <param name="newTriggerType">["<c>triggerType</c>"] New trigger type</param>
        /// <param name="newOrderPrice">["<c>executePrice</c>"] New order price</param>
        /// <param name="newQuantity">["<c>size</c>"] New quantity</param>
        /// <param name="newTrailingStopRate">["<c>rangeRate</c>"] New trailing stop rate</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> EditTpSlOrderAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? newTriggerPrice = null,
            TriggerPriceType? newTriggerType = null,
            decimal? newOrderPrice = null,
            decimal? newQuantity = null,
            decimal? newTrailingStopRate = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get open trigger orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/get-orders-plan-pending" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/orders-plan-pending
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="planType">["<c>planType</c>"] Plan type</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTriggerOrders>> GetOpenTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            TriggerPlanTypeFilter planType,
            string? symbol = null,
            string? orderId = null,
            string? clientOrderId = null,
            string? idLessThan = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get closed trigger orders
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/orders-plan-history" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/order/orders-plan-history
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="planType">["<c>planType</c>"] Plan type</param>
        /// <param name="symbol">["<c>symbol</c>"] Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="status">["<c>planStatus</c>"] Filter by status</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesTriggerOrders>> GetClosedTriggerOrdersAsync(
           BitgetProductTypeV2 productType,
           TriggerPlanTypeFilter planType,
           string? symbol = null,
           string? orderId = null,
           string? clientOrderId = null,
           ClosedPlanFilter? status = null,
           string? idLessThan = null,
           DateTime? startTime = null,
           DateTime? endTime = null,
           int? limit = null,
           CancellationToken ct = default);

        /// <summary>
        /// Cancel trigger orders matching the parameters
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Cancel-Plan-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/cancel-plan-order
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="planType">["<c>planType</c>"] Plan type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginCoin">["<c>marginCoin</c>"] Margin coin</param>
        /// <param name="orderIds">["<c>orderIdList</c>"] Order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            CancelTriggerPlanTypeFilter? planType = null,
            string? symbol = null,
            string? marginCoin = null,
            IEnumerable<BitgetCancelOrderRequest>? orderIds = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set the Tp/Sl for an open position
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/plan/Place-Pos-Tpsl-Order" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/order/place-pos-tpsl
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset</param>
        /// <param name="holdSide">["<c>holdSide</c>"]</param>
        /// <param name="tpTriggerPrice">["<c>stopSurplusTriggerPrice</c>"] Take profit trigger price</param>
        /// <param name="tpTriggerQuantity">["<c>stopSurplusSize</c>"] Take profit quantity</param>
        /// <param name="tpTriggerType">["<c>stopSurplusTriggerType</c>"] Take profit trigger type</param>
        /// <param name="tpLimitPrice">["<c>stopSurplusExecutePrice</c>"] Take profit limit price</param>
        /// <param name="slTriggerPrice">["<c>stopLossTriggerPrice</c>"] Stop loss trigger price</param>
        /// <param name="slTriggerQuantity">["<c>stopLossSize</c>"] Stop loss trigger quantity</param>
        /// <param name="slTriggerType">["<c>stopLossTriggerType</c>"] Stop loss trigger type</param>
        /// <param name="slLimitPrice">["<c>stopLossExecutePrice</c>"] Stop loss limit price</param>
        /// <param name="stpMode">["<c>stpMode</c>"] Self trade prevention mode</param>
        /// <param name="tpClientOrderId">["<c>stopSurplusClientOid</c>"] Take profit client order id</param>
        /// <param name="slClientOrderId">["<c>stopLossClientOid</c>"] Stop loss client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetPositionTpSl[]>> SetPositionTpSlAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, PositionSide holdSide, decimal? tpTriggerPrice = null, decimal? tpTriggerQuantity = null, TriggerPriceType? tpTriggerType = null, decimal? tpLimitPrice = null, decimal? slTriggerPrice = null, decimal? slTriggerQuantity = null, TriggerPriceType? slTriggerType = null, decimal? slLimitPrice = null, SelfTradePreventionMode? stpMode = null, string? tpClientOrderId = null, string? slClientOrderId = null, CancellationToken ct = default);

    }
}

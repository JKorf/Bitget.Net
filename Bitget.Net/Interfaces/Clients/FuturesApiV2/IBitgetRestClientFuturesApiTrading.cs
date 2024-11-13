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
        /// <para><a href="https://www.bitget.com/api-doc/contract/position/get-single-position" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get all positions
        /// <para><a href="https://www.bitget.com/api-doc/contract/position/get-all-position" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionsAsync(BitgetProductTypeV2 productType, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get position history
        /// <para><a href="https://www.bitget.com/api-doc/contract/position/Get-History-Position" /></para>
        /// </summary>
        /// <param name="productType">Filter by product type</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionHistory>> GetPositionHistoryAsync(BitgetProductTypeV2? productType = null, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Place-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="marginMode">Margin mode</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Limit price</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="tradeSide">Trade side</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="reduceOnly">Reduce only order</param>
        /// <param name="takeProfitPrice">Take profit price</param>
        /// <param name="stopLossPrice">Stop loss price</param>
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
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders in a single call
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Batch-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="marginMode">Margin mode</param>
        /// <param name="orders">Orders</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> PlaceMultipleOrdersAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            MarginMode marginMode,
            IEnumerable<BitgetFuturesPlaceOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Modify-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="newClientOrderId">New client order id</param>
        /// <param name="newPrice">New price</param>
        /// <param name="newQuantity">New quantity</param>
        /// <param name="newTakeProfit">New take profit price</param>
        /// <param name="newStopLossPrice">New stop loss price</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Cancel-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="marginAsset">Margin asset</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Batch-Cancel-Orders" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="orders">Orders to cancel</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Get-Order-Details" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Get-Orders-Pending" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Get-Orders-History" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Cancel-All-Orders" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllOrdersAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            string? marginAsset = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Get-Order-Fills" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Get-Fill-History" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Flash-Close-Position" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Position side; only respected if in hedge mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> ClosePositionsAsync(
            BitgetProductTypeV2 productType,
            string? symbol = null,
            PositionSide? side = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place a take profit / stop loss order
        /// <para><a href="https://www.bitget.com/api-doc/contract/trade/Flash-Close-Position" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="planType">Plan type, TakeProfit, StopLoss, TailingStop, PositionTakeProfit or PositionStopLoss</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="orderPrice">Order limit price</param>
        /// <param name="triggerPriceType">Trigger price type</param>
        /// <param name="hedgeModePositionSide">Position side for when in hedge mode, either this or oneWaySide should be provided</param>
        /// <param name="oneWaySide">Order side for when in one way mode, either this or hedgeModePositionSide should be provided</param>
        /// <param name="trailingStopRate">Tailing stop rate</param>
        /// <param name="clientOrderId">Client order id</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/Place-Plan-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="planType">Plan type</param>
        /// <param name="marginMode">Margin mode</param>
        /// <param name="side">Order side</param>
        /// <param name="orderType">Order type</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="orderPrice">Order limit price</param>
        /// <param name="triggerPriceType">Trigger price type</param>
        /// <param name="tradeSide">Trade side</param>
        /// <param name="trailingStopRate">Trailing stop rate</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="takeProfitTriggerPrice">Take profit trigger price</param>
        /// <param name="takeProfitOrderPrice">Take profit order price</param>
        /// <param name="takeProfitPriceType">Take profit price type</param>
        /// <param name="stopLossTriggerPrice">Stop loss trigger price</param>
        /// <param name="stopLossOrderPrice">Stop loss order price</param>
        /// <param name="stopLossPriceType">Stop loss price type</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/Plan-Sub-Orders" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="triggerOrderId">Trigger order id</param>
        /// <param name="planType">Plan type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTriggerSubOrder>>> GetTriggerSubOrdersAsync(
            BitgetProductTypeV2 productType,
            string triggerOrderId,
            TriggerPlanType planType,
            CancellationToken ct = default);

        /// <summary>
        /// Edit an existing trigger order
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/Modify-Plan-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="newQuantity">New quantity</param>
        /// <param name="newPrice">New price</param>
        /// <param name="newTrailingStopRate">New trailing stop rate</param>
        /// <param name="newTriggerPrice">New trigger price</param>
        /// <param name="newTriggerType">New trigger price type</param>
        /// <param name="newTakeProfitTriggerPrice">New take profit trigger price</param>
        /// <param name="newTakeProfitOrderPrice">New take profit order price</param>
        /// <param name="newTakeProfitPriceType">New take profit price type</param>
        /// <param name="newStopLossTriggerPrice">New stop loss trigger price</param>
        /// <param name="newStopLossOrderPrice">New stop loss order price</param>
        /// <param name="newStopLossPriceType">New stop loss trigger price</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/Modify-Tpsl-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">Margin asset, for example `USDT`</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="newTriggerPrice">New trigger price</param>
        /// <param name="newTriggerType">New trigger type</param>
        /// <param name="newOrderPrice">New order price</param>
        /// <param name="newQuantity">New quantity</param>
        /// <param name="newTrailingStopRate">New trailing stop rate</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/get-orders-plan-pending" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="planType">Plan type</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/orders-plan-history" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="planType">Plan type</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
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
        /// <para><a href="https://www.bitget.com/api-doc/contract/plan/Cancel-Plan-Order" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="planType">Plan type</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="marginCoin">Margin coin</param>
        /// <param name="orderIds">Order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelTriggerOrdersAsync(
            BitgetProductTypeV2 productType,
            CancelTriggerPlanTypeFilter? planType = null,
            string? symbol = null,
            string? marginCoin = null,
            IEnumerable<BitgetCancelOrderRequest>? orderIds = null,
            CancellationToken ct = default);
    }
}

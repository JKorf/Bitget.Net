using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBitgetRestClientSpotApiTrading
    {
        /// <summary>
        /// Place a new order
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Place-Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity. For limit and market-sell orders this is in base asset, for market-buy orders it is in quote asset.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Limit price</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="tpslType">Tpsl type</param>
        /// <param name="stpMode">Self trade prevention mode</param>
        /// <param name="presetTakeProfitPrice">Take profit price</param>
        /// <param name="executeTakeProfitPrice">Take profit execute price</param>
        /// <param name="presetStopLossPrice">Stop loss price</param>
        /// <param name="executeStopLossPrice">Stop loss execute price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            TimeInForce timeInForce,
            decimal? price = null,
            string? clientOrderId = null,
            decimal? triggerPrice = null,
            TakeProfitStopLossType? tpslType = null,
            SelfTradePreventionMode? stpMode = null,
            decimal? presetTakeProfitPrice = null,
            decimal? executeTakeProfitPrice = null,
            decimal? presetStopLossPrice = null,
            decimal? executeStopLossPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place multiple orders in a single call
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Batch-Place-Orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orders">Orders to place</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> PlaceMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetPlaceOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel an existing order and replace it with a new order
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Cancel-Replace-Order" /></para>
        /// </summary>
        /// <param name="orderId">Order id of order to cancel. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id of order to cancel. Either this or orderId should be provided</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Limit price</param>
        /// <param name="newClientOrderId">New client order id</param>
        /// <param name="presetTakeProfitPrice">Take profit price</param>
        /// <param name="executeTakeProfitPrice">Take profit execute price</param>
        /// <param name="presetStopLossPrice">Stop loss price</param>
        /// <param name="executeStopLossPrice">Stop loss execute price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> CancelReplaceOrderAsync(
            string? orderId,
            string? clientOrderId,
            string symbol,
            decimal quantity,
            decimal price,
            string? newClientOrderId = null,
            decimal? presetTakeProfitPrice = null,
            decimal? executeTakeProfitPrice = null,
            decimal? presetStopLossPrice = null,
            decimal? executeStopLossPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel and replace multiple orders. Make sure to check the response model to see if each order was successfully replaced
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Batch-Cancel-Replace-Order" /></para>
        /// </summary>
        /// <param name="orders">Orders to cancel and replace</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderIdResult[]>> CancelReplaceMultipleOrdersAsync(
            IEnumerable<BitgetReplaceOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Place-Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="tpslType">Tpsl type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            TakeProfitStopLossType? tpslType = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple orders in a single call
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Batch-Cancel-Orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orders">Orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel all orders on a symbol
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Cancel-Symbol-Orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelOrdersBySymbolAsync(
            string symbol,
            CancellationToken ct = default);

        /// <summary>
        /// Get order info
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Get-Order-Info" /></para>
        /// </summary>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrder[]>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get current open orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Get-Unfilled-Orders" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="tpslType">Tpsl type</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrder[]>> GetOpenOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get closed orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Get-History-Orders" /></para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="tpslType">Tpsl type</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrder[]>> GetClosedOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get user trade history
        /// <para><a href="https://www.bitget.com/api-doc/spot/trade/Get-Fills" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserTrade[]>> GetUserTradesAsync(
            string symbol,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place a trigger order
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Place-Plan-Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="quantityType">Asset the quantity is in</param>
        /// <param name="triggerPriceType">Trigger price type</param>
        /// <param name="orderPrice">Order price (when orderType is limit)</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> PlaceTriggerOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            decimal triggerPrice,
            QuantityType? quantityType = null,
            TriggerPriceType? triggerPriceType = null,
            decimal? orderPrice = null,
            TimeInForce? timeInForce = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Edit a trigger order
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Modify-Plan-Order" /></para>
        /// </summary>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="orderType">Order type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="orderPrice">Order price for limit orders</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client Order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderId>> EditTriggerOrderAsync(
            decimal triggerPrice,
            OrderType orderType,
            decimal quantity,
            decimal? orderPrice = null,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel a trigger order
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Cancel-Plan-Order" /></para>
        /// </summary>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client Order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelTriggerOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel all trigger orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Batch-Cancel-Plan-Order" /></para>
        /// </summary>
        /// <param name="symbols">Only cancel trigger orders on these symbols, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllTriggerOrdersAsync(
            IEnumerable<string>? symbols = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get list of currently open trigger orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Get-Current-Plan-Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderList>> GetOpenTriggerOrdersAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get trigger order sub orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Get-Plan-Sub-Order" /></para>
        /// </summary>
        /// <param name="triggerOrderId">Trigger order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTriggerSubOrder[]>> GetTriggerSubOrdersAsync(
            string triggerOrderId,
            CancellationToken ct = default);

        /// <summary>
        /// Get closed trigger orders
        /// <para><a href="https://www.bitget.com/api-doc/spot/plan/Get-History-Plan-Order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderList>> GetClosedTriggerOrdersAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            int? limit = null,
            CancellationToken ct = default);
    }
}

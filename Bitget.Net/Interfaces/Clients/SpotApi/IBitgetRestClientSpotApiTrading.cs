using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Bitget trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBitgetRestClientSpotApiTrading
    {
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#trade" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="price">Limit order price</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, BitgetTimeInForce timeInForce, decimal? price, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-v2" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all orders for a symbol
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-by-symbol" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelOrdersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get order info by id
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-order-details" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Order id. Either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id. Either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrder>> GetOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get orders
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-order-list" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrdersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-order-history" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="startId">Return results with id after this</param>
        /// <param name="endId">Return results with id before this</param>
        /// <param name="limit">Max results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderHistoryAsync(string symbol, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-transaction-details" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startId">Filter by start id</param>
        /// <param name="endId">Filter by end id</param>
        /// <param name="limit">Max results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = null, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new planned order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#place-plan-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="side">Order side</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="executePrice">Execution price (if limit order)</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, decimal triggerPrice, BitgetTriggerType triggerType, decimal? executePrice = null, BitgetTimeInForce? timeInForce = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Modify an existing plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#modify-plan-order" /></para>
        /// </summary>
        /// <param name="orderId">Order id of order to edit, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id of order to edit, either this or orderId should be provided</param>
        /// <param name="type">Order type</param>
        /// <param name="quantity">Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="executePrice">Execution price (if limit order)</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(string? orderId, string? clientOrderId, BitgetOrderType type, decimal quantity, decimal triggerPrice, decimal? executePrice = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel a plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#cancel-plan-order" /></para>
        /// </summary>
        /// <param name="orderId">Order id of order to cancel, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id of order to cancel, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelPlanOrderAsync(string? orderId, string? clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Get current plan orders
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-current-plan-orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="fromId">Return results after this order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrdersAsync(string symbol, int pageSize, string? fromId = null, CancellationToken ct = default);

        /// <summary>
        /// Get historic plan orders
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-history-plan-orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="fromId">Return results after this order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrderHistoryAsync(string symbol, int pageSize, DateTime startTime, DateTime endTime, string? fromId = null, CancellationToken ct = default);
    }
}

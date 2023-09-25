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
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-order-list" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="startId">Return results with id after this</param>
        /// <param name="endId">Return results with id before this</param>
        /// <param name="limit">Max results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderHistoryAsync(string symbol, string? startId, string? endId, int? limit = null, CancellationToken ct = default);

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
    }
}

using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Bitget trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IBitgetRestClientFuturesApiTrading
    {
        /// <summary>
        /// Place a new order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#place-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="side">Position side</param>
        /// <param name="type">Position side</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="takeProfitPrice">Preset take profit price</param>
        /// <param name="stopLossPrice">Preset stop loss price</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(
                                                    string symbol,
                                                    string marginAsset,
                                                    BitgetFuturesOrderSide side,
                                                    BitgetOrderType type,
                                                    decimal quantity,
                                                    decimal? price = null,
                                                    BitgetTimeInForce? timeInForce = null,
                                                    bool? reduceOnly = null,
                                                    decimal? takeProfitPrice = null,
                                                    decimal? stopLossPrice = null,
                                                    string? clientOrderId = null,
                                                    CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#cancel-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Edit an order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#modify-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="newClientOrderId">New client order id</param>
        /// <param name="price">New price</param>
        /// <param name="quantity">New quantity</param>
        /// <param name="takeProfitPrice">new take profit price</param>
        /// <param name="stopLossPrice">New stop loss price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> EditOrderAsync(string symbol,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                string? newClientOrderId = null,
                                                                decimal? price = null,
                                                                decimal? quantity = null,
                                                                decimal? takeProfitPrice = null,
                                                                decimal? stopLossPrice = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Get list of open orders for a symbol
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-open-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get list of open order for a product type
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-all-open-order" /></para>
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="marginAsset">Filter by margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrder>> GetOpenOrdersAsync(BitgetProductType type, string? marginAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-orders" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="endId">Last end Id of last query</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(string symbol, DateTime startTime, DateTime endTime, int pageSize, string? endId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-history-orders" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="endId">Last end Id of last query</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(BitgetProductType type, DateTime startTime, DateTime endTime, int pageSize, string? endId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get an order by id
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-order-details" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesOrder>> GetOrderAsync(string symbol,
                                                                string? orderId = null,
                                                                string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-order-fill-detail" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="endId">Last end Id of last query</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(string symbol,
                                                                string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-order-fill-detail" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="endId">Last end Id of last query</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(BitgetProductType type, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, CancellationToken ct = default);
    }
}

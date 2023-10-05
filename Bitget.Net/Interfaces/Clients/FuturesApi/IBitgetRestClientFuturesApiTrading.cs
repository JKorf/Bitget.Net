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

        /// <summary>
        /// Place a new plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#place-plan-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="side">Position side</param>
        /// <param name="type">Position side</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="executePrice">Execute price</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="takeProfitPrice">Preset take profit price</param>
        /// <param name="stopLossPrice">Preset stop loss price</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetFuturesOrderSide side,
                                                                BitgetOrderType type,
                                                                BitgetTriggerType triggerType,
                                                                decimal quantity,
                                                                decimal triggerPrice,
                                                                decimal? executePrice = null,
                                                                bool? reduceOnly = null,
                                                                decimal? takeProfitPrice = null,
                                                                decimal? stopLossPrice = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Edit a plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="orderType">Order type</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="executePrice">Execute price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                decimal triggerPrice,
                                                                BitgetTriggerType triggerType,
                                                                BitgetOrderType orderType,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                decimal? executePrice = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Edit the take profit / stop loss of a plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order-tpsl" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="takeProfitPrice">New take profit price</param>
        /// <param name="stopLossPrice">New stop loss price</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> EditPlanOrderTpSlAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                decimal? takeProfitPrice = null,
                                                                decimal? stopLossPrice = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Place a new stop order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#place-stop-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="planType">Plan type</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="side">Position side</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="executePrice">Execution price</param>
        /// <param name="rangeRate">Only works when planType is "MovingPlan", "1" means 1.0% price correction, two decimal places</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlaceStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                BitgetPositionSide side,
                                                                BitgetTriggerType? triggerType = null,
                                                                decimal? quantity = null,
                                                                decimal? executePrice = null,
                                                                decimal? rangeRate = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Place a new trailling stop order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#place-trailing-stop-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="side">Order side</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="rangeRate">"1" means 1.0% price correction, max 10</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlaceTrailingStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                decimal triggerPrice,
                                                                BitgetFuturesOrderSide side,
                                                                decimal quantity,
                                                                decimal rangeRate,
                                                                BitgetTriggerType? triggerType = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Set stop loss / take profit price for an position. When the position take profit / stop loss are triggered, the full amount of the position will be entrusted at the market price by default
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#place-position-tpsl" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="side">Order side</param>
        /// <param name="triggerType">Trigger type</param>
        /// <param name="planType">Plan type</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> PlacePositionTpSlAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                BitgetTriggerType triggerType,
                                                                BitgetPositionSide side,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Edit an existing stop order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="planType">Plan type</param>
        /// <param name="triggerPrice">Trigger price</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> EditStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Cancel a plan order
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="planType">Plan type</param>
        /// <param name="orderId">Order id, either this or clientOrderId should be provided</param>
        /// <param name="clientOrderId">Client order id, either this or orderId should be provided</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetOrderResult>> CancelPlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default);

        /// <summary>
        /// Get plan order history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-plan-orders-tpsl" /></para>
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        /// <param name="type">Filter by product type</param>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesPlanOrder>>> GetPlanOrderHistoryAsync(
                                                                DateTime startTime,
                                                                DateTime endTime,
                                                                BitgetProductType? type = null,
                                                                string? symbol = null,
                                                                int? pageSize = null,
                                                                CancellationToken ct = default);
    }
}

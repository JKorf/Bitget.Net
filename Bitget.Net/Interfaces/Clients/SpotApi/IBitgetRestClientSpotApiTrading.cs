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
    }
}

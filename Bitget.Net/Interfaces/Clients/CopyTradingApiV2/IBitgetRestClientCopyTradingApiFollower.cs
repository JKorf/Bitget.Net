using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.CopyTradingApiV2
{
    /// <summary>
    /// Bitget copy trading endpoints.
    /// </summary>
    public interface IBitgetRestClientCopyTradingApiFollower
    {
        /// <summary>
        /// Get My Traders
        /// <para><a href="https://www.bitget.com/api-doc/copytrading/future-copytrade/follower/Query-Traders" /></para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="pageNo">Current page number</param>
        /// <param name="pageSize">Number of quiries</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetCopyTradingMyTrader[]>> GetMyTradersAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 20, CancellationToken ct = default);

        /// <summary>
        /// Get Current Tracking Orders
        /// <para><a href="https://www.bitget.com/api-doc/copytrading/future-copytrade/follower/Query-Current-Orders" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="idLessThan">Separate page content before this ID is requested (older data), and the value input should be the end ID of the corresponding interface.</param>
        /// <param name="idGreaterThan">Separate page content after this ID is requested (newer data), and the value input should be the end ID of the corresponding interface.</param>
        /// <param name="startTime">Start timestamp (Copy trade creation time) Milliseconds format of timestamp Unix.</param>
        /// <param name="endTime">End timestamp (Copy trade creation time) Milliseconds format of timestamp Unix</param>
        /// <param name="limit">Number of queries: Default: 20, maximum: 50.</param>
        /// <param name="symbol">Trading pairs, case sensitive</param>
        /// <param name="traderId">Trader ID</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetCopyTradingCurrentOrders>> GetCurrentOrdersAsync(BitgetProductTypeV2 productType, string? idLessThan = null, string? idGreaterThan = null, DateTime? startTime = null, DateTime? endTime = null, int limit = 20, string? symbol = null, string? traderId = null, CancellationToken ct = default);
    }
}

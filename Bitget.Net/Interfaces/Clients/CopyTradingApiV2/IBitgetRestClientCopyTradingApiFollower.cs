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
    }
}

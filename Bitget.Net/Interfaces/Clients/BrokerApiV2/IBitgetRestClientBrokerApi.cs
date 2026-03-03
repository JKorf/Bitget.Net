using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.BrokerApiV2
{
    /// <summary>
    /// Broker API endpoints
    /// </summary>
    public interface IBitgetRestClientBrokerApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Get Agent Direct commissions
        /// <para><a href="https://www.bitget.com/api-doc/classic/affiliate/customerInfo/GetDirectCommissions" /></para>
        /// <para><a href="https://www.bitget.com/zh-CN/api-doc/classic/affiliate/customerInfo/GetDirectCommissions" /></para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="idLessThan">Retrieve data before this ID</param>
        /// <param name="limit">Number of quiries, 100 default, Max 1000</param>
        /// <param name="uid">User Id</param>
        /// <param name="coin">Coin, e.g: BTC</param>
        /// <param name="symbol">Coin, e.g: BGBUSDT_SPBL spot</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetBrokerAgentDirectCommissions>> GetAgentDirectCommissionsAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, string? coin = null, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get agent customers
        /// <para><a href="https://www.bitget.com/api-doc/classic/affiliate/customerInfo/GetCustomerList" /></para>
        /// <para><a href="https://www.bitget.com/zh-CN/api-doc/classic/affiliate/customerInfo/GetCustomerList" /></para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="pageNo">Current page number</param>
        /// <param name="pageSize">Number of quiries, 100 default, Max 1000</param>
        /// <param name="uid">User Id</param>
        /// <param name="referralCode">Referral code</param>
        /// <param name="showSub">Whether to Display Subordinate User Information of Direct Clients</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetBrokerAgentCustomer[]>> GetAgentCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 100, long? uid = null, string? referralCode = null, bool showSub = true, CancellationToken ct = default);
    }
}

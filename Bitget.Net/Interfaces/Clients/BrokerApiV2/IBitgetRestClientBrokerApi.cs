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
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/classic/affiliate/customerInfo/GetDirectCommissions" /><br />
        /// <a href="https://www.bitget.com/zh-CN/api-doc/classic/affiliate/customerInfo/GetDirectCommissions" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/broker/customer-commissions
        /// </para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="idLessThan">Retrieve data before this ID</param>
        /// <param name="limit">Max number of results, 100 default, Max 1000</param>
        /// <param name="uid">User Id</param>
        /// <param name="coin">Coin, e.g: BTC</param>
        /// <param name="symbol">Coin, e.g: BGBUSDT_SPBL spot</param>
        /// <param name="showSub">Whether to Display Subordinate User Information of Direct Clients</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetBrokerAgentDirectCommissions>> GetAgentDirectCommissionsAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, string? coin = null, string? symbol = null, bool? showSub = null, CancellationToken ct = default);

        /// <summary>
        /// Get agent customers
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/classic/affiliate/customerInfo/GetCustomerList" /><br />
        /// <a href="https://www.bitget.com/zh-CN/api-doc/classic/affiliate/customerInfo/GetCustomerList" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/broker/customer-list
        /// </para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="pageNo">Current page number</param>
        /// <param name="pageSize">Max number of results, 100 default, Max 1000</param>
        /// <param name="uid">User Id</param>
        /// <param name="referralCode">Referral code</param>
        /// <param name="showSub">Whether to Display Subordinate User Information of Direct Clients</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetBrokerAgentCustomer[]>> GetAgentCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 100, long? uid = null, string? referralCode = null, bool? showSub = null, CancellationToken ct = default);

        /// <summary>
        /// Get Agent SubCustomer List
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/classic/affiliate/customerInfo/GetSubCustomerList" /><br />
        /// <a href="https://www.bitget.com/zh-CN/api-doc/classic/affiliate/customerInfo/GetSubCustomerList" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/broker/sub-customer-list
        /// </para>
        /// </summary>
        /// <param name="startTime">Start time (The maximum time span supported is three months. The default end time is three months if no value is set for the end time. )</param>
        /// <param name="endTime">End time (The maximum time span supported is three months. The default start time is three months ago if no value is set for the start time. )</param>
        /// <param name="idLessThan">Cursor ID</param>
        /// <param name="limit">Items per page</param>
        /// <param name="uid">UID</param>
        /// <param name="showSub">Whether to Display Subordinate User Information of Direct Clients</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetBrokerAgentCustomerList>> GetAgentSubCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, bool? showSub = null, CancellationToken ct = default);
    }
}

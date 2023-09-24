using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientSpotApiAccount
    {
        /// <summary>
        /// Get account asset balances
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get account assets, only returns assets with balance > 0
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets-lite" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesLiteAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get API key info
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-apikey-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get bills history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-bills" /></para>
        /// </summary>
        /// <param name="assetId">Asset id</param>
        /// <param name="groupType">Transaction group type</param>
        /// <param name="bizType">	Business type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetBill>>> GetBillsAsync(string? assetId = null, BitgetGroupType? groupType = null, BizType? bizType = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get transfer history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-transfer-list" /></para>
        /// </summary>
        /// <param name="assetId">Asset id</param>
        /// <param name="fromType">Filter by account source</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max amount of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetTransfer>>> GetTransferHistoryAsync(string assetId, BitgetAccountType fromType, DateTime startTime, DateTime endTime, string? clientOrderId = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer between account types
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#transfer-v2" /></para>
        /// </summary>
        /// <param name="asset">Asset name</param>
        /// <param name="quantity">Transfer quantity</param>
        /// <param name="fromType">From account type</param>
        /// <param name="toType">To account type</param>
        /// <param name="symbol">Must provide when fromType or toType = IsolatedMargin</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string? symbol = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer between subaccounts or sub and main account
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#sub-transfer" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="quantity">Transfer quantity</param>
        /// <param name="fromType">From account type</param>
        /// <param name="toType">To account type</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="fromUserId">From user id</param>
        /// <param name="toUserId">To user id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SubTransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string clientOrderId, string fromUserId, string toUserId, CancellationToken ct = default);

        /// <summary>
        /// Deposit address
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-address" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="network">Network</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string network, CancellationToken ct = default);

        /// <summary>
        /// Withdraw funds
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#withdraw-v2" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="address">Target address</param>
        /// <param name="network">Network</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="tag">Tag</param>
        /// <param name="remark">Remard</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, string address, string network, decimal quantity, string? tag = null, string? remark = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Withdraw funds internally
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#inner-withdraw-v2" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="toUserId">Target user id</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="toType">'email/mobile/uid', default 'uid'</param>
        /// <param name="areaCode">	Tel area code, This field is mandatory when the toType equals to 'mobile'</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawResult>> InnerWithdrawAsync(string asset, string toUserId, decimal quantity, string? toType = null, string? areaCode = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-withdraw-list" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit history
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-deposit-list" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetDeposit>>> GetDepositHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get user maker / taker fees
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/spot/#get-user-fee-ratio" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="businessType"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserFee>> GetUserFeeRatioAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default);
    }
}

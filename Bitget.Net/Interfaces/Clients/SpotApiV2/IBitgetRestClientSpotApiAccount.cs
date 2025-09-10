using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientSpotApiAccount
    {
        /// <summary>
        /// Get funding balances
        /// <para><a href="https://www.bitget.com/api-doc/common/account/Funding-Assets" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetBalance[]>> GetFundingBalancesAsync(CancellationToken ct = default);
        /// <summary>
        /// Get trading fee for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/common/public/Get-Trade-Rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="businessType">Business type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserFee>> GetTradeFeeAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default);

        /// <summary>
        /// Get asset valuation per account type
        /// <para><a href="https://www.bitget.com/api-doc/common/account/All-Account-Balance" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetAssetValue[]>> GetAssetsValuationAsync(CancellationToken ct = default);

        /// <summary>
        /// Get account info
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get spot account balances
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Assets" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetSpotBalance[]>> GetSpotBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Set the account to receive deposits in for an asset
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Modify-Deposit-Account" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="accountType">The account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetDepositAccountAsync(string asset, Enums.V2.AccountType accountType, CancellationToken ct = default);

        /// <summary>
        /// Get account ledger
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Bills" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="groupType">Filter by group type</param>
        /// <param name="businessType">Filter by business type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetSpotLedgerEntry[]>> GetLedgerAsync(string? asset = null, Enums.V2.GroupType? groupType = null, Enums.V2.BusinessType? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer funds between accounts
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Wallet-Transfer" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="fromAccount">From account</param>
        /// <param name="toAccount">To account</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="symbol">Symbol, required when transferring to or from an account type that is a leveraged position-by-position account.</param>
        /// <param name="clientId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, decimal quantity, string? symbol = null, string? clientId = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of assets that can be transfered between accounts
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Transfer-Coins" /></para>
        /// </summary>
        /// <param name="fromAccount">From account</param>
        /// <param name="toAccount">To account</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<string[]>> GetTransferableAssetsAsync(Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, CancellationToken ct = default);

        /// <summary>
        /// Withdraw asset
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Wallet-Withdrawal" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="transferType">Transfer type</param>
        /// <param name="address">Target address</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="network">Network to use</param>
        /// <param name="innerTargetType">Inner transfer target type</param>
        /// <param name="areaCode">Area code for inner transfer</param>
        /// <param name="tag">Tag</param>
        /// <param name="remark">Remark</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, Enums.V2.TransferType transferType, string address, decimal quantity, string? network = null, string? innerTargetType = null, string? areaCode = null, string? tag = null, string? remark = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get transfer history
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Account-TransferRecords" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="fromAccount">From account</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="page">Page number</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">[Deprecated] Use page instead</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferRecord[]>> GetTransferHistoryAsync(string asset, Enums.V2.TransferAccountType? fromAccount = null, DateTime? startTime = null, DateTime? endTime = null, string? clientOrderId = null, int? page = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Set BGB fee deduction enabled status
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Switch-Deduct" /></para>
        /// </summary>
        /// <param name="enable">Enabled</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetBgbDeductEnabledAsync(bool enable, CancellationToken ct = default);

        /// <summary>
        /// Get BGB deduct status
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Deduct-Info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetBgbDeduct>> GetBgbDeductEnabledAsync(CancellationToken ct = default);

        /// <summary>
        /// Get deposit address
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Deposit-Address" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="network">Network</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string? network = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel a withdrawal
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Cancel-Withdrawal" /></para>
        /// </summary>
        /// <param name="withdrawalOrderId">Withdrawal order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelWithdrawalAsync(string withdrawalOrderId, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history 
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Withdraw-Record" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawalRecord[]>> GetWithdrawalHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit history
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Deposit-Record" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="orderId">Filter by order id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetDepositRecord[]>> GetDepositHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer assets between subaccounts or parent and subaccount
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Sub-Transfer" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="fromAccount">From account</param>
        /// <param name="toAccount">To account</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="symbol">Symbol, required when transferring to or from an account type that is a leveraged position-by-position account.</param>
        /// <param name="clientId">Client order id</param>
        /// <param name="fromUserId">From user id</param>
        /// <param name="toUserId">To user id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferResult>> TransferSubAccountAsync(string asset, Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, decimal quantity, long fromUserId, long toUserId, string? symbol = null, string? clientId = null, CancellationToken ct = default);

        /// <summary>
        /// Get subaccount balances
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Subaccount-Assets" /></para>
        /// </summary>
        /// <param name="idLessThan">Return results with id less than this</param>
        /// <param name="limit">Max number of results, max 50</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetSubAccountBalances[]>> GetSubAccountBalancesAsync(
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get transfer history between master and sub account
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-TransferRecords" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="role">Filter by role</param>
        /// <param name="subAccountId">Filter by sub account id</param>
        /// <param name="clientOrderID">Filter by client id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">Id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetSubAccountTransfer[]>> GetSubAccountTransferHistoryAsync(string? asset = null, string? role = null, long? subAccountId = null, string? clientOrderID = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get sub account deposit address
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-Deposit-Address" /></para>
        /// </summary>
        /// <param name="subAccountId">Sub account id</param>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="network">Filter by network</param>
        /// <param name="lightningNetworkQuantity">Bitcoin Lightning Network withdrawal amount</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetDepositAddress>> GetSubAccountDepositAddressAsync(long subAccountId, string asset, string? network = null, decimal? lightningNetworkQuantity = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit records for a sub account
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-Deposit-Record" /></para>
        /// </summary>
        /// <param name="subAccountId">Sub account id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return ids less than this</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetDepositRecord[]>> GetSubAccountDepositHistoryAsync(long subAccountId, string? asset = null, DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int? limit = null, CancellationToken ct = default);

    }
}

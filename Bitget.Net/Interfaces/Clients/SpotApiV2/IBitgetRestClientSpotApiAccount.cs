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
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/common/account/Funding-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/account/funding-assets
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetBalance[]>> GetFundingBalancesAsync(CancellationToken ct = default);
        /// <summary>
        /// Get trading fee for a symbol
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/common/public/Get-Trade-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/common/trade-rate
        /// </para>
        /// </summary>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="businessType">["<c>businessType</c>"] Business type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserFee>> GetTradeFeeAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default);

        /// <summary>
        /// Get asset valuation per account type
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/common/account/All-Account-Balance" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/account/all-account-balance
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetAssetValue[]>> GetAssetsValuationAsync(CancellationToken ct = default);

        /// <summary>
        /// Get account info
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Info" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/info
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get spot account balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/assets
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetSpotBalance[]>> GetSpotBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Set the account to receive deposits in for an asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Modify-Deposit-Account" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/wallet/modify-deposit-account
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="accountType">["<c>accountType</c>"] The account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetDepositAccountAsync(string asset, Enums.V2.AccountType accountType, CancellationToken ct = default);

        /// <summary>
        /// Get account ledger
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Bills" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/bills
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="groupType">["<c>groupType</c>"] Filter by group type</param>
        /// <param name="businessType">["<c>businessType</c>"] Filter by business type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetSpotLedgerEntry[]>> GetLedgerAsync(string? asset = null, Enums.V2.GroupType? groupType = null, Enums.V2.BusinessType? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer funds between accounts
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Wallet-Transfer" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/wallet/transfer
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="fromAccount">["<c>fromType</c>"] From account</param>
        /// <param name="toAccount">["<c>toType</c>"] To account</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity to transfer</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, required when transferring to or from an account type that is a leveraged position-by-position account.</param>
        /// <param name="clientId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, decimal quantity, string? symbol = null, string? clientId = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of assets that can be transfered between accounts
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Transfer-Coins" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/transfer-coin-info
        /// </para>
        /// </summary>
        /// <param name="fromAccount">["<c>fromType</c>"] From account</param>
        /// <param name="toAccount">["<c>toType</c>"] To account</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<string[]>> GetTransferableAssetsAsync(Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, CancellationToken ct = default);

        /// <summary>
        /// Withdraw asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Wallet-Withdrawal" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/wallet/withdrawal
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="transferType">["<c>transferType</c>"] Transfer type</param>
        /// <param name="address">["<c>address</c>"] Target address</param>
        /// <param name="quantity">["<c>size</c>"] Quantity</param>
        /// <param name="network">["<c>chain</c>"] Network to use</param>
        /// <param name="innerTargetType">["<c>innerToType</c>"] Inner transfer target type</param>
        /// <param name="areaCode">["<c>areaCode</c>"] Area code for inner transfer</param>
        /// <param name="tag">["<c>tag</c>"] Tag</param>
        /// <param name="remark">["<c>remark</c>"] Remark</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, Enums.V2.TransferType transferType, string address, decimal quantity, string? network = null, string? innerTargetType = null, string? areaCode = null, string? tag = null, string? remark = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get transfer history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Account-TransferRecords" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/transferRecords
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="fromAccount">["<c>fromType</c>"] From account</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="page">["<c>pageNum</c>"] Page number</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] [Deprecated] Use page instead</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferRecord[]>> GetTransferHistoryAsync(string asset, Enums.V2.TransferAccountType? fromAccount = null, DateTime? startTime = null, DateTime? endTime = null, string? clientOrderId = null, int? page = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Set BGB fee deduction enabled status
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Switch-Deduct" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/account/switch-deduct
        /// </para>
        /// </summary>
        /// <param name="enable">["<c>deduct</c>"] Enabled</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetBgbDeductEnabledAsync(bool enable, CancellationToken ct = default);

        /// <summary>
        /// Get BGB deduct status
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Deduct-Info" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/deduct-info
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetBgbDeduct>> GetBgbDeductEnabledAsync(CancellationToken ct = default);

        /// <summary>
        /// Get deposit address
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Deposit-Address" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/deposit-address
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="network">["<c>chain</c>"] Network</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string? network = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel a withdrawal
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Cancel-Withdrawal" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/wallet/cancel-withdrawal
        /// </para>
        /// </summary>
        /// <param name="withdrawalOrderId">["<c>orderId</c>"] Withdrawal order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> CancelWithdrawalAsync(string withdrawalOrderId, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Withdraw-Record" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/withdrawal-records
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetWithdrawalRecord[]>> GetWithdrawalHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit history
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Deposit-Record" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/deposit-records
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetDepositRecord[]>> GetDepositHistoryAsync(DateTime startTime, DateTime endTime, string? asset = null, string? orderId = null, int? limit = null, string? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer assets between subaccounts or parent and subaccount
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Sub-Transfer" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/spot/wallet/subaccount-transfer
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Asset, for example `ETH`</param>
        /// <param name="fromAccount">["<c>fromType</c>"] From account</param>
        /// <param name="toAccount">["<c>toType</c>"] To account</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity to transfer</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, required when transferring to or from an account type that is a leveraged position-by-position account.</param>
        /// <param name="clientId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="fromUserId">["<c>fromUserId</c>"] From user id</param>
        /// <param name="toUserId">["<c>toUserId</c>"] To user id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetTransferResult>> TransferSubAccountAsync(string asset, Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, decimal quantity, long fromUserId, long toUserId, string? symbol = null, string? clientId = null, CancellationToken ct = default);

        /// <summary>
        /// Get subaccount balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-Subaccount-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/subaccount-assets
        /// </para>
        /// </summary>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results with id less than this</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 50</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetSubAccountBalances[]>> GetSubAccountBalancesAsync(
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get transfer history between master and sub account
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-TransferRecords" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/account/sub-main-trans-record
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="role">["<c>role</c>"] Filter by role</param>
        /// <param name="subAccountId">["<c>subUid</c>"] Filter by sub account id</param>
        /// <param name="clientOrderID">["<c>clientOid</c>"] Filter by client id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Id less than this</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetSubAccountTransfer[]>> GetSubAccountTransferHistoryAsync(string? asset = null, string? role = null, long? subAccountId = null, string? clientOrderID = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? idLessThan = null, CancellationToken ct = default);

        /// <summary>
        /// Get sub account deposit address
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-Deposit-Address" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/subaccount-deposit-address
        /// </para>
        /// </summary>
        /// <param name="subAccountId">["<c>subUid</c>"] Sub account id</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="network">["<c>chain</c>"] Filter by network</param>
        /// <param name="lightningNetworkQuantity">["<c>size</c>"] Bitcoin Lightning Network withdrawal amount</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetDepositAddress>> GetSubAccountDepositAddressAsync(long subAccountId, string asset, string? network = null, decimal? lightningNetworkQuantity = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit records for a sub account
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/spot/account/Get-SubAccount-Deposit-Record" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/spot/wallet/subaccount-deposit-records
        /// </para>
        /// </summary>
        /// <param name="subAccountId">["<c>subUid</c>"] Sub account id</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return ids less than this</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetDepositRecord[]>> GetSubAccountDepositHistoryAsync(long subAccountId, string? asset = null, DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int? limit = null, CancellationToken ct = default);

    }
}

using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientUnifiedApiAccount
    {
        /// <summary>
        /// Get balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/assets<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaBalances>> GetBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get funding assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account-Funding-Assets" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/funding-assets<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFundingAsset[]>> GetFundingBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get account config
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account-Setting" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/settings<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaAccountConfig>> GetAccountConfigAsync(CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Change-Leverage" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/set-leverage<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="leverage">["<c>leverage</c>"] Leverage</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="positionSide">["<c>posSide</c>"] Position side</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SetLeverageAsync(
            ProductCategory category,
            string symbol,
            decimal leverage,
            string? asset = null,
            PositionSide? positionSide = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set holding mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Change-Position-Mode" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/set-hold-mode<br />
        /// </para>
        /// </summary>
        /// <param name="holdMode">["<c>holdMode</c>"] Holding mode</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SetHoldModeAsync(HoldingMode holdMode, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Financial-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/financial-records<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFinancialRecordPage>> GetFinancialRecordsAsync(
            ProductCategory category,
            string? asset = null,
            string? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get repayable assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Repayable-Coins" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/repayable-coins<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaRepayableAssets>> GetRepayableAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get payment assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Payment-Coins" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/payment-coins<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaPaymentAssets>> GetPaymentAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// Manual repayment
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Repay" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/repay<br />
        /// </para>
        /// </summary>
        /// <param name="repayableAssets">["<c>repayableCoinList</c>"] Repayable asset list</param>
        /// <param name="paymentAssets">["<c>paymentCoinList</c>"] Payment asset list</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaRepayResult>> RepayAsync(
            IEnumerable<string> repayableAssets,
            IEnumerable<string> paymentAssets,
            CancellationToken ct = default);

        /// <summary>
        /// Get convert records
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Convert-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/convert-records<br />
        /// </para>
        /// </summary>
        /// <param name="fromAsset">["<c>fromAsset</c>"] The from asset, for example `ETH`</param>
        /// <param name="toAsset">["<c>toAsset</c>"] The target asset, for example `ETH`</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaConvertRecords>> GetConvertRecordsAsync(
            string fromAsset,
            string toAsset,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Switch deduct mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Switch-Deduct" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/switch-deduct<br />
        /// </para>
        /// </summary>
        /// <param name="deduct">["<c>deduct</c>"] Deduct enabled</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SwitchDeductAsync(bool deduct, CancellationToken ct = default);

        /// <summary>
        /// Set deposit account for an asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Deposit-Account" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/deposit-account<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="accountType">["<c>accountType</c>"] Account type</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SetDepositAccountAsync(
            string asset,
            UtaAccountType accountType,
            CancellationToken ct = default);

        /// <summary>
        /// Get BGB deduct status
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Deduct-Info" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/deduct-info<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaDeductStatus>> GetDeductStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// Get fee rates
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account-Fee-Rate" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/fee-rate<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaFeeRate>> GetFeeAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default);

        /// <summary>
        /// Switch to classic account mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Switch-Account" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/switch<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SwitchToClassicModeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get switch to classic account mode status
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Switch-Status" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/switch-status<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaSwitchStatus>> GetSwitchToClassicStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// Get max transferable quantity for an asset
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Max-Transferable" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/max-transferable<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaMaxTransferable>> GetMaxTransferableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get max open interest
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-OI-Limit" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/open-interest-limit<br />
        /// </para>
        /// </summary>
        /// <param name="category">["<c>category</c>"] Category</param>
        /// <param name="symbol">["<c>symbol</c>"] The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaUserOpenInterestLimit>> GetOpenInterestLimitAsync(
            ProductCategory category,
            string symbol,
            CancellationToken ct = default);

        /// <summary>
        /// Get account info
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account-Info" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/info<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get delta info
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Delta-Info" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/delta-info<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaDeltaInfo>> GetDeltaInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Set account mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Adjust-Account-Mode" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/adjust-account-mode<br />
        /// </para>
        /// </summary>
        /// <param name="mode">["<c>mode</c>"] New mode</param>
        /// <param name="subAccountId">["<c>targetUid</c>"] Sub account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> SetAccountModeAsync(
            AccountLevel mode,
            string? subAccountId = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get transferable assets
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/transfer/Get-Transfer-Coins" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/transferable-coins<br />
        /// </para>
        /// </summary>
        /// <param name="fromType">["<c>fromType</c>"] From type</param>
        /// <param name="toType">["<c>toType</c>"] To type</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<string[]>> GetTransferableAssetsAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            CancellationToken ct = default);

        /// <summary>
        /// Transfer
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/transfer/" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/transfer<br />
        /// </para>
        /// </summary>
        /// <param name="fromType">["<c>fromType</c>"] From type</param>
        /// <param name="toType">["<c>toType</c>"] To type</param>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="quantity">["<c>amount</c>"] Quantity</param>
        /// <param name="symbol">["<c>symbol</c>"] Isolated margin symbol</param>
        /// <param name="allowBorrow">["<c>allowBorrow</c>"] Allow borrowing for transfer</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaTransferId>> TransferAsync(
            Enums.V2.TransferAccountType fromType,
            Enums.V2.TransferAccountType toType,
            string asset,
            decimal quantity,
            string? symbol = null,
            bool? allowBorrow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get deposit address
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/deposit/Get-Deposit-Address" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/deposit-address<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="network">["<c>chain</c>"] Network</param>
        /// <param name="quantity">["<c>size</c>"] Quantity for BTC lightning deposit</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaDepositAddress>> GetDepositAddressAsync(
            string asset,
            string? network = null,
            decimal? quantity = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get deposit records
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/deposit/Get-Deposit-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/deposit-records<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaDeposit[]>> GetDepositRecordsAsync(
            string? asset = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Withdraw
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/withdrawal/" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/withdrawal<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] The asset, for example `ETH`</param>
        /// <param name="transferType">["<c>transferType</c>"] Transfer type</param>
        /// <param name="address">["<c>address</c>"] Target address</param>
        /// <param name="quantity">["<c>size</c>"] Quantity</param>
        /// <param name="network">["<c>chain</c>"] Network</param>
        /// <param name="innerWithdrawType">["<c>innerToType</c>"] Inner withdrawal type</param>
        /// <param name="areaCode">["<c>areaCode</c>"] Area code for mobile</param>
        /// <param name="tag">["<c>tag</c>"] Tag</param>
        /// <param name="remark">["<c>remark</c>"] Remark</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Client order id</param>
        /// <param name="memberCode">["<c>memberCode</c>"] Member code</param>
        /// <param name="identityType">["<c>identityType</c>"] Identity type</param>
        /// <param name="companyName">["<c>companyName</c>"] Company name</param>
        /// <param name="firstName">["<c>firstName</c>"] First name</param>
        /// <param name="lastName">["<c>lastName</c>"] Last name</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaWithdrawResult>> WithdrawAsync(
            string asset,
            Enums.V2.TransferType transferType,
            string address,
            decimal quantity,
            string? network = null,
            string? innerWithdrawType = null,
            string? areaCode = null,
            string? tag = null,
            string? remark = null,
            string? clientOrderId = null,
            string? memberCode = null,
            string? identityType = null,
            string? companyName = null,
            string? firstName = null,
            string? lastName = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal records
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/withdrawal/Get-Withdrawal-Records" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/withdrawal-records<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="orderId">["<c>orderId</c>"] Filter by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Filter by client order id</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 100</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaWithdrawRecord[]>> GetWithdrawalRecordsAsync(
            string? asset = null,
            string? orderId = null,
            string? clientOrderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal address book
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/withdrawal/Get-Withdraw-Address" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/withdraw-address<br />
        /// </para>
        /// </summary>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `ETH`</param>
        /// <param name="type">["<c>type</c>"] Filter by type</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results, max 10</param>
        /// <param name="cursor">["<c>cursor</c>"] Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<BitgetUaAddressBook>> GetWithdrawAddressBookAsync(
            string? asset = null,
            AddressBookType? type = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel a pending withdrawal
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/withdrawal/Cancel-Withdrawal" /><br />
        /// Endpoint:<br />
        /// POST /api/v3/account/cancel-withdrawal<br />
        /// </para>
        /// </summary>
        /// <param name="orderId">["<c>orderId</c>"] Cancel by order id</param>
        /// <param name="clientOrderId">["<c>clientOid</c>"] Cancel by client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult> CancelWithdrawalAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default);

    }
}

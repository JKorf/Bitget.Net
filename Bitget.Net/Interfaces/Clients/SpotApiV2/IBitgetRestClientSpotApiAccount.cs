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
        Task<WebCallResult<IEnumerable<BitgetBalance>>> GetFundingBalancesAsync(CancellationToken ct = default);
        /// <summary>
        /// Get trading fee for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/common/public/Get-Trade-Rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
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
        Task<WebCallResult<IEnumerable<BitgetAssetValue>>> GetAssetsValuationAsync(CancellationToken ct = default);

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
        Task<WebCallResult<IEnumerable<BitgetSpotBalance>>> GetSpotBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Set the account to receive deposits in for an asset
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Modify-Deposit-Account" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="accountType">The account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetDepositAccountAsync(string asset, Enums.V2.AccountType accountType, CancellationToken ct = default);

        /// <summary>
        /// Get account ledger
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Get-Account-Bills" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="groupType">Filter by group type</param>
        /// <param name="businessType">Filter by business type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetSpotLedgerEntry>>> GetLedgerAsync(string? asset = null, Enums.V2.GroupType? groupType = null, Enums.V2.BusinessType? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer funds between accounts
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Wallet-Transfer" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
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
        Task<WebCallResult<IEnumerable<string>>> GetTransferableAssetsAsync(Enums.V2.TransferAccountType fromAccount, Enums.V2.TransferAccountType toAccount, CancellationToken ct = default);

        /// <summary>
        /// Withdraw asset
        /// <para><a href="https://www.bitget.com/api-doc/spot/account/Wallet-Withdrawal" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
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
    }
}

using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Bitget margin endpoints
    /// </summary>
    public interface IBitgetRestClientSpotApiMargin
    {
        /// <summary>
        /// Get margin symbols
        /// <para><a href="https://www.bitget.com/api-doc/margin/common/support-currencies" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<IEnumerable<BitgetMarginSymbol>>> GetMarginSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get cross margin borrow history
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Loan-Records" /></para>
        /// </summary>
        /// <param name="loanId">Filter by loanId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossBorrowHistory>>> GetCrossBorrowHistoryAsync(string? loanId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin repay history
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Repay-History" /></para>
        /// </summary>
        /// <param name="repayId">Filter by repayId</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetRepayHistory>>> GetCrossRepayHistoryAsync(string? repayId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin interest history
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Interest-Records" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossInterest>>> GetCrossInterestHistoryAsync(string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin liquidation history
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Liquidation-Records" /></para>
        /// </summary>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossLiquidation>>> GetCrossLiquidationHistoryAsync(
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null, 
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin financial history
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/record/Get-Cross-Finance-Flow-History" /></para>
        /// </summary>
        /// <param name="marginType">Filter by margin type</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="idLessThan">return results less than this id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMinMaxResult<BitgetCrossFinancial>>> GetCrossFinancialHistoryAsync(
            MarginType? marginType = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? idLessThan = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get cross margin balances
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Assets" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<IEnumerable<BitgetCrossBalance>>> GetCrossBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Cross margin borrow
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Borrow" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to borrow</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossBorrowResult>> CrossBorrowAsync(string asset, decimal quantity, string clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Cross margin repay
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Repay" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity to repay</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossRepayResult>> CrossRepayAsync(string asset, decimal quantity, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin risk rate
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Risk-Rate" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossRiskRate>> GetCrossRiskRateAsync(CancellationToken ct = default);

        /// <summary>
        /// Get cross margin max borrowable amount
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Cross-Max-Borrowable-Amount" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossMaxBorrowable>> GetCrossMaxBorrowableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin max transferable amount
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Max-Transfer-Out-Amount" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetCrossMaxTransferable>> GetCrossMaxTransferableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin interest rates and borrow limits
        /// <para><a href="https://www.bitget.com/api-doc/margin/cross/account/Get-Cross-Margin-Interest-Rate-And-Borrowable" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<IEnumerable<BitgetCrossInterestLimit>>> GetCrossInterestAndLimitAsync(string asset, CancellationToken ct = default);

    }
}

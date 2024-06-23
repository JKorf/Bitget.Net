using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientFuturesApiAccount
    {
        /// <summary>
        /// Get balance
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Get-Single-Account" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesBalance>> GetBalanceAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get balances
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Get-Account-List" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesBalance>>> GetBalancesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Get-Account-List" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="leverage">New leverage</param>
        /// <param name="side">Position side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionLeverage>> SetLeverageAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal leverage, PositionSide? side = null, CancellationToken ct = default);

        /// <summary>
        /// Adjust margin
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Change-Margin" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="quantity">Margin amount, positive means increase, and negative means decrease</param>
        /// <param name="side">Position side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> AdjustMarginAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal quantity, PositionSide? side = null, CancellationToken ct = default);

        /// <summary>
        /// Set margin mode
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Change-Margin-Mode" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="mode">Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionLeverage>> SetMarginModeAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, MarginMode? mode = null, CancellationToken ct = default);

        /// <summary>
        /// Set position mode
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Change-Hold-Mode" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="mode">Position mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionMode>> SetPositionModeAsync(BitgetProductTypeV2 productType, PositionMode mode, CancellationToken ct = default);

        /// <summary>
        /// Get account ledger
        /// <para><a href="https://www.bitget.com/api-doc/contract/account/Get-Account-Bill" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="businessType">Filter by business type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="idLessThan">Return results before this id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesLedger>> GetLedgerAsync(BitgetProductTypeV2 productType, string? asset = null, string? businessType = null, DateTime? startTime = null, DateTime? endTime = null, string? idLessThan = null, int? limit = null, CancellationToken ct = default);

    }
}

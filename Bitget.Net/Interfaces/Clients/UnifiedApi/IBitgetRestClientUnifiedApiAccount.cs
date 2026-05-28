using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
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
        Task<WebCallResult<BitgetUaBalances>> GetBalancesAsync(CancellationToken ct = default);

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
        Task<WebCallResult<BitgetUaFundingAsset[]>> GetFundingBalancesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get account info
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/uta/account/Get-Account-Setting" /><br />
        /// Endpoint:<br />
        /// GET /api/v3/account/settings<br />
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetUaAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default);

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
        Task<WebCallResult> SetLeverageAsync(
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
        Task<WebCallResult> SetHoldModeAsync(HoldingMode holdMode, CancellationToken ct = default);

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
        Task<WebCallResult<BitgetUaFinancialRecordPage>> GetFinancialRecordsAsync(
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
        Task<WebCallResult<BitgetUaRepayableAssets>> GetRepayableAssetsAsync(CancellationToken ct = default);

    }
}

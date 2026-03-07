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
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Get-Single-Account" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/account/account
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesBalance>> GetBalanceAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get balances
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Get-Account-List" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/account/accounts
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesBalance[]>> GetBalancesAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Change-Leverage" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/account/set-leverage
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="leverage">["<c>leverage</c>"] New leverage</param>
        /// <param name="longLeverage">["<c>longLeverage</c>"] New long leverage</param>
        /// <param name="shortLeverage">["<c>shortLeverage</c>"] New short leverage</param>
        /// <param name="side">["<c>holdSide</c>"] Position side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionLeverage>> SetLeverageAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal? leverage = null, PositionSide? side = null, decimal? longLeverage = null, decimal? shortLeverage = null, CancellationToken ct = default);

        /// <summary>
        /// Adjust margin
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Change-Margin" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/account/set-margin
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `USDT`</param>
        /// <param name="quantity">["<c>amount</c>"] Margin amount, positive means increase, and negative means decrease</param>
        /// <param name="side">["<c>holdSide</c>"] Position side</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> AdjustMarginAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, decimal quantity, PositionSide? side = null, CancellationToken ct = default);

        /// <summary>
        /// Set margin mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Change-Margin-Mode" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/account/set-margin-mode
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] Margin asset, for example `ETHT`</param>
        /// <param name="mode">["<c>marginMode</c>"] Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionLeverage>> SetMarginModeAsync(BitgetProductTypeV2 productType, string symbol, string marginAsset, MarginMode? mode = null, CancellationToken ct = default);

        /// <summary>
        /// Set position mode
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Change-Hold-Mode" /><br />
        /// Endpoint:<br />
        /// POST /api/v2/mix/account/set-position-mode
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="mode">["<c>posMode</c>"] Position mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionMode>> SetPositionModeAsync(BitgetProductTypeV2 productType, PositionMode mode, CancellationToken ct = default);

        /// <summary>
        /// Get account ledger
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Get-Account-Bill" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/account/bill
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="asset">["<c>coin</c>"] Filter by asset, for example `USDT`</param>
        /// <param name="businessType">["<c>businessType</c>"] Filter by business type</param>
        /// <param name="startTime">["<c>startTime</c>"] Filter by start time</param>
        /// <param name="endTime">["<c>endTime</c>"] Filter by end time</param>
        /// <param name="idLessThan">["<c>idLessThan</c>"] Return results before this id</param>
        /// <param name="limit">["<c>limit</c>"] Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesLedger>> GetLedgerAsync(BitgetProductTypeV2 productType, string? asset = null, string? businessType = null, DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get Auto deleverage rank
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/position/Get-ADL-Rank" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/position/adlRank
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesAdlRank[]>> GetAdlRankAsync(BitgetProductTypeV2 productType, CancellationToken ct = default);

        /// <summary>
        /// Get liquidation price
        /// <para>
        /// Docs:<br />
        /// <a href="https://www.bitget.com/api-doc/contract/account/Get-Liquidation-Price" /><br />
        /// Endpoint:<br />
        /// GET /api/v2/mix/account/liq-price
        /// </para>
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] The margin asset, for example `USDT`</param>
        /// <param name="side">["<c>posSide</c>"] Position side</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="openQuantity">["<c>openAmount</c>"] Open quantity</param>
        /// <param name="openPrice">["<c>openPrice</c>"] Open price for limit order</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetLiquidationPrice>> GetLiquidationPriceAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            PositionSide side,
            OrderType orderType,
            decimal openQuantity,
            decimal? openPrice = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get max openable quantity
        /// </summary>
        /// <param name="productType">["<c>productType</c>"] Product type</param>
        /// <param name="symbol">["<c>symbol</c>"] Symbol, for example `ETHUSDT`</param>
        /// <param name="marginAsset">["<c>marginCoin</c>"] The margin asset, for example `USDT`</param>
        /// <param name="side">["<c>posSide</c>"] Position side</param>
        /// <param name="orderType">["<c>orderType</c>"] Order type</param>
        /// <param name="openPrice">["<c>openPrice</c>"] Open price for limit order</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BitgetMaxOpenQuantity>> GetOpenableQuantityAsync(
            BitgetProductTypeV2 productType,
            string symbol,
            string marginAsset,
            PositionSide side,
            OrderType orderType,
            decimal? openPrice = null,
            CancellationToken ct = default);
    }
}

using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBitgetRestClientFuturesApiAccount
    {
        /// <summary>
        /// Get account info
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-single-account" /></para>
        /// </summary>
        /// <param name="symbol">Symbol id</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetFuturesAccountInfo>> GetAccountAsync(string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get account list
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-account-list" /></para>
        /// </summary>
        /// <param name="type">The type of product</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetFuturesAccountInfo>>> GetAccountsAsync(BitgetProductType type, CancellationToken ct = default);

        /// <summary>
        /// Get max open positions
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-open-count" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">The margin asset</param>
        /// <param name="openPrice">Open price</param>
        /// <param name="openQuantity">Open quantity</param>
        /// <param name="leverage">Leverage</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetMaxPositions>> GetMaxOpenPositionsAsync(string symbol, string marginAsset, decimal openPrice, decimal openQuantity, decimal? leverage = null, CancellationToken ct = default);

        /// <summary>
        /// Set the leverage
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#change-leverage" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="leverage">Leverage</param>
        /// <param name="positionSide">Position direction (ignore this field if marginMode is crossed）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserLeverage>> SetLeverageAsync(string symbol, string marginAsset, decimal leverage, BitgetPositionSide? positionSide = null, CancellationToken ct = default);

        /// <summary>
        /// Set the margin
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#change-margin" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="margin">Margin amount</param>
        /// <param name="positionSide">Position direction (ignore this field if marginMode is crossed）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetResult>> SetMarginAsync(string symbol, string marginAsset, decimal margin, BitgetPositionSide? positionSide = null, CancellationToken ct = default);

        /// <summary>
        /// Change the margin mode
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#change-margin-mode" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="mode">Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetUserLeverage>> SetMarginModeAsync(string symbol, string marginAsset, BitgetMarginMode mode, CancellationToken ct = default);

        /// <summary>
        /// Set auto margin
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#set-auto-margin" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="side">Position side</param>
        /// <param name="autoMargin">Auto margin on or off</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetResult>> SetAutoMarginAsync(string symbol, string marginAsset, BitgetPositionSide side, bool autoMargin, CancellationToken ct = default);

        /// <summary>
        /// Set position hold mode
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#change-hold-mode" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="mode">New hold mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPositionMode>> SetHoldModeAsync(BitgetProductType type, BitgetHoldMode mode, CancellationToken ct = default);

        /// <summary>
        /// Get symbol position
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-position-v2" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionAsync(string symbol, string marginAsset, CancellationToken ct = default);

        /// <summary>
        /// Get all postions
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-all-position-v2" /></para>
        /// </summary>
        /// <param name="type">Product type</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionsAsync(BitgetProductType type, string? marginAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get history position (max 3 months ago)
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-history-position" /></para>
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        /// <param name="type">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="endId">Last end id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetPositionHistory>>> GetHistoryPositionAsync(DateTime startTime, DateTime endTime, BitgetProductType? type = null, string? symbol = null, int? pageSize = null, string? endId = null, CancellationToken ct = default);

        /// <summary>
        /// Get account bill
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#get-account-bill" /></para>
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        /// <param name="type">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="endId">Last end id</param>
        /// <param name="business">Business</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BitgetPagination<BitgetFuturesBill>>> GetBillsAsync(string marginAsset, DateTime startTime, DateTime endTime, BitgetProductType? type = null, string? symbol = null, int? pageSize = null, string? business = null, string? endId = null, CancellationToken ct = default);
    }
}

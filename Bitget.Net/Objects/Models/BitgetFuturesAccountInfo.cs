using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Account info
    /// </summary>
    public class BitgetFuturesAccountInfo
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Locked amount (margin asset), system will lock when close position
        /// </summary>
        [JsonProperty("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Available balance(margin asset)
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// The maximum available balance for crossed margin mode(margin currency)
        /// </summary>
        [JsonProperty("crossMaxAvailable")]
        public decimal CrossMaxAvailable { get; set; }
        /// <summary>
        /// The maximum available balance for fixed margin mode(margin currency)
        /// </summary>
        [JsonProperty("fixedMaxAvailable")]
        public decimal FixedMaxAvailable { get; set; }
        /// <summary>
        /// Maximum transferable
        /// </summary>
        [JsonProperty("maxTransferOut")]
        public decimal MaxTransferOut { get; set; }
        /// <summary>
        /// Account equity (margin asset), includes uPnL (calculated by mark price)
        /// </summary>
        [JsonProperty("equity")]
        public decimal Equity { get; set; }
        /// <summary>
        /// Account equity convert to USDT
        /// </summary>
        [JsonProperty("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// Account equity convert to BTC
        /// </summary>
        [JsonProperty("btcEquity")]
        public decimal BtcEquity { get; set; }
        /// <summary>
        /// Risk ratio at crossed margin mode
        /// </summary>
        [JsonProperty("crossRiskRate")]
        public decimal CrossRiskRate { get; set; }
        /// <summary>
        /// Leverage level for crossed margin mode
        /// </summary>
        [JsonProperty("crossMarginLeverage")]
        public decimal? CrossMarginLeverage { get; set; }
        /// <summary>
        /// Long leverage with isolated(fixed) margin mode
        /// </summary>
        [JsonProperty("fixedLongLeverage")]
        public decimal? FixedLongLeverage { get; set; }
        /// <summary>
        /// Short leverage with isolated(fixed) margin mode
        /// </summary>
        [JsonProperty("fixedShortLeverage")]
        public decimal? FixedShortLeverage { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("marginMode")]
        public BitgetMarginMode? MarginMode { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode")]
        public BitgetHoldMode? HoldMode { get; set; }
        /// <summary>
        /// Urealized profit and loss at crossed margin mode, unit in USDT
        /// </summary>
        [JsonProperty("unrealizedPL")]
        public decimal? UnrealizedProfitLoss { get; set; }
        /// <summary>
        /// Coupon
        /// </summary>
        [JsonProperty("bonus")]
        public decimal Bonus { get; set; }
    }
}

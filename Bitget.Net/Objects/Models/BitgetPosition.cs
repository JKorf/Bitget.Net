using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BitgetPosition
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Hold side
        /// </summary>
        [JsonProperty("holdSide")]
        public BitgetPositionSide HoldSide { get; set; }
        /// <summary>
        /// Open pending to fill (base currency)
        /// </summary>
        [JsonProperty("openDelegateCount")]
        public decimal? OpenQuantity { get; set; }
        /// <summary>
        /// Margin quantity (margin currency)
        /// </summary>
        [JsonProperty("margin")]
        public decimal? Margin { get; set; }
        /// <summary>
        /// Auto suppliment margin
        /// </summary>
        [JsonProperty("autoMargin")]
        public bool AutoMargin { get; set; }
        /// <summary>
        /// Position available (Quote currency)
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Position locked (Quote currency)
        /// </summary>
        [JsonProperty("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Total position (available + locked)
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonProperty("achievedProfits")]
        public decimal? ProfitAndLoss { get; set; }
        /// <summary>
        /// Average opening price
        /// </summary>
        [JsonProperty("averageOpenPrice")]
        public decimal? AverageOpenPrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("marginMode")]
        public BitgetMarginMode MarginMode { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode")]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("unrealizedPL")]
        public decimal? UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Estimated liquidation price
        /// </summary>
        [JsonProperty("liquidationPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// Keep margin rate
        /// </summary>
        [JsonProperty("keepMarginRate")]
        public decimal? KeepMarginRate { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("marketPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonProperty("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
    }
}

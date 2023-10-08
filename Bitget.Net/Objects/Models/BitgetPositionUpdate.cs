using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BitgetPositionUpdate
    {
        /// <summary>
        /// Position id
        /// </summary>
        [JsonProperty("posId")]
        public string PositionId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("instId")]
        public string SymbolId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("instName")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Hold side
        /// </summary>
        [JsonProperty("holdSide"), JsonConverter(typeof(EnumConverter))]
        public BitgetPositionSide HoldSide { get; set; }
        /// <summary>
        /// Margin quantity (margin currency)
        /// </summary>
        [JsonProperty("margin")]
        public decimal? Margin { get; set; }
        /// <summary>
        /// Auto suppliment margin
        /// </summary>
        [JsonProperty("autoMargin"), JsonConverter(typeof(BoolConverter))]
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
        [JsonProperty("marginMode"), JsonConverter(typeof(EnumConverter))]
        public BitgetMarginMode MarginMode { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode"), JsonConverter(typeof(EnumConverter))]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("upl")]
        public decimal? UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Unrealized profit and loss ratio
        /// </summary>
        [JsonProperty("uplRate")]
        public decimal? UnrealizedProfitAndLossRatio { get; set; }
        /// <summary>
        /// Estimated liquidation price
        /// </summary>
        [JsonProperty("liqPx")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// Keep margin rate
        /// </summary>
        [JsonProperty("keepMarginRate")]
        public decimal? KeepMarginRate { get; set; }
        /// <summary>
        /// Fixed margin rate
        /// </summary>
        [JsonProperty("fixedMarginRate")]
        public decimal? FixedMarginRate { get; set; }
        /// <summary>
        /// Risk rate
        /// </summary>
        [JsonProperty("marginRate")]
        public decimal? RiskRate { get; set; }
        /// <summary>
        /// Create time
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

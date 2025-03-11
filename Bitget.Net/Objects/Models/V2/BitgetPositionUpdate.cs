using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position update
    /// </summary>
    [SerializationModel]
    public record BitgetPositionUpdate
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position id
        /// </summary>
        [JsonPropertyName("posId")]
        public string PositionId { get; set; } = string.Empty;
        /// <summary>
        /// Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide PositionSide { get; set; }
        /// <summary>
        /// Margin quantity
        /// </summary>
        [JsonPropertyName("marginSize")]
        public decimal MarginQuantity { get; set; }
        /// <summary>
        /// Available quantity for positions
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Frozen quantity in the position
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Total quantity of all positions
        /// </summary>
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Realized pnl
        /// </summary>
        [JsonPropertyName("achievedProfits")]
        public decimal RealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Average open price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// Unrealized pnl
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Unrealized ROI
        /// </summary>
        [JsonPropertyName("unrealizedPLR")]
        public decimal UnrealizedRoi { get; set; }
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonPropertyName("liquidationPrice")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>
        /// Maintenance margin rate
        /// </summary>
        [JsonPropertyName("keepMarginRate")]
        public decimal MaintenanceMarginRate { get; set; }
        /// <summary>
        /// Margin rate
        /// </summary>
        [JsonPropertyName("marginRate")]
        public decimal MarginRate { get; set; }
        /// <summary>
        /// Break even price
        /// </summary>
        [JsonPropertyName("breakEvenPrice")]
        public decimal BreakEvenPrice { get; set; }
        /// <summary>
        /// Funding fee, the accumulated value of funding fee during the position
        /// </summary>
        [JsonPropertyName("totalFee")]
        public decimal? TotalFee { get; set; }
        /// <summary>
        /// Deducted transaction fees: transaction fees deducted during the position
        /// </summary>
        [JsonPropertyName("deductedFee")]
        public decimal DeductedFee { get; set; }
        /// <summary>
        /// Margin ratio
        /// </summary>
        [JsonPropertyName("marginRatio")]
        public decimal MarginRatio { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Auto margin
        /// </summary>
        [JsonPropertyName("autoMargin")]
        public bool AutoMargin { get; set; }
    }
}

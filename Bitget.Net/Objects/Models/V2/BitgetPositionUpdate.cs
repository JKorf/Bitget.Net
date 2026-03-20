using CryptoExchange.Net.Converters.SystemTextJson;
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
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>instId</c>"] Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>posId</c>"] Position id
        /// </summary>
        [JsonPropertyName("posId")]
        public string PositionId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>holdSide</c>"] Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide PositionSide { get; set; }
        /// <summary>
        /// ["<c>marginSize</c>"] Margin quantity
        /// </summary>
        [JsonPropertyName("marginSize")]
        public decimal MarginQuantity { get; set; }
        /// <summary>
        /// ["<c>available</c>"] Available quantity for positions
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>frozen</c>"] Frozen quantity in the position
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// ["<c>total</c>"] Total quantity of all positions
        /// </summary>
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>achievedProfits</c>"] Realized pnl
        /// </summary>
        [JsonPropertyName("achievedProfits")]
        public decimal RealizedProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>openPriceAvg</c>"] Average open price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// ["<c>unrealizedPL</c>"] Unrealized pnl
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>unrealizedPLR</c>"] Unrealized ROI
        /// </summary>
        [JsonPropertyName("unrealizedPLR")]
        public decimal UnrealizedRoi { get; set; }
        /// <summary>
        /// ["<c>liquidationPrice</c>"] Liquidation price
        /// </summary>
        [JsonPropertyName("liquidationPrice")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>
        /// ["<c>keepMarginRate</c>"] Maintenance margin rate
        /// </summary>
        [JsonPropertyName("keepMarginRate")]
        public decimal MaintenanceMarginRate { get; set; }
        /// <summary>
        /// ["<c>marginRate</c>"] Margin rate
        /// </summary>
        [JsonPropertyName("marginRate")]
        public decimal MarginRate { get; set; }
        /// <summary>
        /// ["<c>breakEvenPrice</c>"] Break even price
        /// </summary>
        [JsonPropertyName("breakEvenPrice")]
        public decimal BreakEvenPrice { get; set; }
        /// <summary>
        /// ["<c>totalFee</c>"] Funding fee, the accumulated value of funding fee during the position
        /// </summary>
        [JsonPropertyName("totalFee")]
        public decimal? TotalFee { get; set; }
        /// <summary>
        /// ["<c>deductedFee</c>"] Deducted transaction fees: transaction fees deducted during the position
        /// </summary>
        [JsonPropertyName("deductedFee")]
        public decimal DeductedFee { get; set; }
        /// <summary>
        /// ["<c>marginRatio</c>"] Margin ratio
        /// </summary>
        [JsonPropertyName("marginRatio")]
        public decimal MarginRatio { get; set; }
        /// <summary>
        /// ["<c>markPrice</c>"] Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// ["<c>autoMargin</c>"] Auto margin
        /// </summary>
        [JsonPropertyName("autoMargin")]
        public bool AutoMargin { get; set; }
    }
}

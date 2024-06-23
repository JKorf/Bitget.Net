using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position history entry
    /// </summary>
    public record BitgetPositionHistoryUpdate
    {
        /// <summary>
        /// Position id
        /// </summary>
        [JsonPropertyName("posId")]
        public string PositionId { get; set; } = string.Empty;
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
        /// Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide Side { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// Average open price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// Average close price
        /// </summary>
        [JsonPropertyName("closePriceAvg")]
        public decimal AverageClosePrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Open quantity
        /// </summary>
        [JsonPropertyName("openSize")]
        public decimal OpenQuantity { get; set; }
        /// <summary>
        /// Close quantity
        /// </summary>
        [JsonPropertyName("closeSize")]
        public decimal CloseQuantity { get; set; }
        /// <summary>
        /// Profit and loss
        /// </summary>
        [JsonPropertyName("achievedProfits")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// Settle fee
        /// </summary>
        [JsonPropertyName("settleFee")]
        public decimal SettleFee { get; set; }
        /// <summary>
        /// Open fee
        /// </summary>
        [JsonPropertyName("openFee")]
        public decimal OpenFee { get; set; }
        /// <summary>
        /// Close fee
        /// </summary>
        [JsonPropertyName("closeFee")]
        public decimal CloseFee { get; set; }
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
    }
}

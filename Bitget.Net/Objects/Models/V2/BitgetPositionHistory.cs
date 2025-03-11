using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position history
    /// </summary>
    [SerializationModel]
    public record BitgetPositionHistory
    {
        /// <summary>
        /// End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// Entries
        /// </summary>
        [JsonPropertyName("list")]
        public BitgetPositionHistoryEntry[] Entries { get; set; } = Array.Empty<BitgetPositionHistoryEntry>();
    }

    /// <summary>
    /// Position history entry
    /// </summary>
    [SerializationModel]
    public record BitgetPositionHistoryEntry
    {
        /// <summary>
        /// Position id
        /// </summary>
        [JsonPropertyName("positionId")]
        public string PositionId { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide Side { get; set; }
        /// <summary>
        /// Average open price
        /// </summary>
        [JsonPropertyName("openAvgPrice")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// Average close price
        /// </summary>
        [JsonPropertyName("closeAvgPrice")]
        public decimal AverageClosePrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Total long positions
        /// </summary>
        [JsonPropertyName("openTotalPos")]
        public decimal OpenTotalPosition { get; set; }
        /// <summary>
        /// Total short positions
        /// </summary>
        [JsonPropertyName("closeTotalPos")]
        public decimal CloseTotalPosition { get; set; }
        /// <summary>
        /// Profit and loss
        /// </summary>
        [JsonPropertyName("pnl")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// Net profit
        /// </summary>
        [JsonPropertyName("netProfit")]
        public decimal NetProfit { get; set; }
        /// <summary>
        /// Total funding costs
        /// </summary>
        [JsonPropertyName("totalFunding")]
        public decimal TotalFunding { get; set; }
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
        [JsonPropertyName("ctime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("utime")]
        public DateTime UpdateTime { get; set; }
    }
}

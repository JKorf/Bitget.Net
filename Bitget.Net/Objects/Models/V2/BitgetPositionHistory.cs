using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
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
        /// ["<c>endId</c>"] End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>list</c>"] Entries
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
        /// ["<c>positionId</c>"] Position id
        /// </summary>
        [JsonPropertyName("positionId")]
        public string PositionId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>holdSide</c>"] Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide Side { get; set; }
        /// <summary>
        /// ["<c>openAvgPrice</c>"] Average open price
        /// </summary>
        [JsonPropertyName("openAvgPrice")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// ["<c>closeAvgPrice</c>"] Average close price
        /// </summary>
        [JsonPropertyName("closeAvgPrice")]
        public decimal AverageClosePrice { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// ["<c>openTotalPos</c>"] Total long positions
        /// </summary>
        [JsonPropertyName("openTotalPos")]
        public decimal OpenTotalPosition { get; set; }
        /// <summary>
        /// ["<c>closeTotalPos</c>"] Total short positions
        /// </summary>
        [JsonPropertyName("closeTotalPos")]
        public decimal CloseTotalPosition { get; set; }
        /// <summary>
        /// ["<c>pnl</c>"] Profit and loss
        /// </summary>
        [JsonPropertyName("pnl")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>netProfit</c>"] Net profit
        /// </summary>
        [JsonPropertyName("netProfit")]
        public decimal NetProfit { get; set; }
        /// <summary>
        /// ["<c>totalFunding</c>"] Total funding costs
        /// </summary>
        [JsonPropertyName("totalFunding")]
        public decimal TotalFunding { get; set; }
        /// <summary>
        /// ["<c>openFee</c>"] Open fee
        /// </summary>
        [JsonPropertyName("openFee")]
        public decimal OpenFee { get; set; }
        /// <summary>
        /// ["<c>closeFee</c>"] Close fee
        /// </summary>
        [JsonPropertyName("closeFee")]
        public decimal CloseFee { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// ["<c>ctime</c>"] Create time
        /// </summary>
        [JsonPropertyName("ctime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>utime</c>"] Update time
        /// </summary>
        [JsonPropertyName("utime")]
        public DateTime UpdateTime { get; set; }
    }
}

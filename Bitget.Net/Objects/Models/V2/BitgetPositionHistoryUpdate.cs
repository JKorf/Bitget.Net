using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position history entry
    /// </summary>
    [SerializationModel]
    public record BitgetPositionHistoryUpdate
    {
        /// <summary>
        /// ["<c>posId</c>"] Position id
        /// </summary>
        [JsonPropertyName("posId")]
        public string PositionId { get; set; } = string.Empty;
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
        /// ["<c>holdSide</c>"] Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide Side { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// ["<c>openPriceAvg</c>"] Average open price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// ["<c>closePriceAvg</c>"] Average close price
        /// </summary>
        [JsonPropertyName("closePriceAvg")]
        public decimal AverageClosePrice { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// ["<c>openSize</c>"] Open quantity
        /// </summary>
        [JsonPropertyName("openSize")]
        public decimal OpenQuantity { get; set; }
        /// <summary>
        /// ["<c>closeSize</c>"] Close quantity
        /// </summary>
        [JsonPropertyName("closeSize")]
        public decimal CloseQuantity { get; set; }
        /// <summary>
        /// ["<c>achievedProfits</c>"] Profit and loss
        /// </summary>
        [JsonPropertyName("achievedProfits")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>settleFee</c>"] Settle fee
        /// </summary>
        [JsonPropertyName("settleFee")]
        public decimal SettleFee { get; set; }
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
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }
}

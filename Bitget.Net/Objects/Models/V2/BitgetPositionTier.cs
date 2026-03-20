using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position tier
    /// </summary>
    [SerializationModel]
    public record BitgetPositionTier
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol 
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>level</c>"] Level 
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>startUnit</c>"] Start  unit
        /// </summary>
        [JsonPropertyName("startUnit")]
        public decimal StartUnit { get; set; }
        /// <summary>
        /// ["<c>endUnit</c>"] End unit 
        /// </summary>
        [JsonPropertyName("endUnit")]
        public decimal EndUnit { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>keepMarginRate</c>"] Maintenance margin rate
        /// </summary>
        [JsonPropertyName("keepMarginRate")]
        public decimal MaintenanceMarginRate { get; set; }
    }
}

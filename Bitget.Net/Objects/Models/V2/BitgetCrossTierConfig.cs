using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Cross tier configuration
    /// </summary>
    [SerializationModel]
    public record BitgetCrossTierConfig
    {
        /// <summary>
        /// ["<c>tier</c>"] Tier
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>maxBorrowableAmount</c>"] Max borrowable quantity
        /// </summary>
        [JsonPropertyName("maxBorrowableAmount")]
        public decimal MaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>maintainMarginRate</c>"] Maintain margin rate
        /// </summary>
        [JsonPropertyName("maintainMarginRate")]
        public decimal MaintainMarginRate { get; set; }
    }


}

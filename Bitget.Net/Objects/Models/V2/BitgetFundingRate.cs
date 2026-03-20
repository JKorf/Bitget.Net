using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Funding rate
    /// </summary>
    [SerializationModel]
    public record BitgetFundingRate
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fundingRate</c>"] Current funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// ["<c>fundingTime</c>"] Funding time
        /// </summary>
        [JsonPropertyName("fundingTime")]
        public DateTime? FundingTime { get; set; }
    }
}

using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Funding time info
    /// </summary>
    [SerializationModel]
    public record BitgetFundingTime
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>nextFundingTime</c>"] Next funding time
        /// </summary>
        [JsonPropertyName("nextFundingTime")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// ["<c>ratePeriod</c>"] Rate settlement cycle in hours
        /// </summary>
        [JsonPropertyName("ratePeriod"), JsonConverter(typeof(IntConverter))]
        public int? RatePeriod { get; set; }
    }
}

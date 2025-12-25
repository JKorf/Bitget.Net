using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// OI contract limit
    /// </summary>
    public record BitgetOiLimit
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Individual user position notional value
        /// </summary>
        [JsonPropertyName("notionalValue")]
        public decimal NotionalValue { get; set; }
        /// <summary>
        /// Sub-account and Main-account position notional value
        /// </summary>
        [JsonPropertyName("totalNotionalValue")]
        public decimal TotalNotionalValue { get; set; }
    }
}

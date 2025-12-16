using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// BGB deduct status
    /// </summary>
    [SerializationModel]
    public record BitgetBgbDeduct
    {
        /// <summary>
        /// Deduct enabled
        /// </summary>
        [JsonPropertyName("deduct")]
        public bool Enabled { get; set; }
    }
}

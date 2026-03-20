using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order list
    /// </summary>
    [SerializationModel]
    public record BitgetOrderList
    {
        /// <summary>
        /// ["<c>nextFlag</c>"] Next flag
        /// </summary>
        [JsonPropertyName("nextFlag")]
        public bool NextFlag { get; set; }
        /// <summary>
        /// ["<c>idLessThan</c>"] Id for pagination
        /// </summary>
        [JsonPropertyName("idLessThan")]
        public string IdLessThan { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderList</c>"] Orders
        /// </summary>
        [JsonPropertyName("orderList")]
        public BitgetTriggerOrder[] Orders { get; set; } = Array.Empty<BitgetTriggerOrder>();
    }
}

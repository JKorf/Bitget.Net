using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Deposit address
    /// </summary>
    [SerializationModel]
    public record BitgetDepositAddress
    {
        /// <summary>
        /// ["<c>address</c>"] Address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>chain</c>"] Network
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tag</c>"] Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
        /// <summary>
        /// ["<c>url</c>"] Deposit address url
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}

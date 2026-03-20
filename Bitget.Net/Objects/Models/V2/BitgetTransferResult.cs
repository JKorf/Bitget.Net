using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Transfer result
    /// </summary>
    [SerializationModel]
    public record BitgetTransferResult
    {
        /// <summary>
        /// ["<c>transferId</c>"] Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
    }
}

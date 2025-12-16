using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Order result
    /// </summary>
    public record BitgetOrderResult
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string? OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        [JsonPropertyName("clientOid")]
        internal string? IntClientOrderId { get => ClientOrderId; set => ClientOrderId = value; }
    }
}
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Order result
    /// </summary>
    public record BitgetOrderResult
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string? OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOrderId</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        [JsonPropertyName("clientOid")]
        internal string? IntClientOrderId { get => ClientOrderId; set => ClientOrderId = value; }
    }
}

using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Withdrawal record
    /// </summary>
    [SerializationModel]
    public record BitgetWithdrawalRecord
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tradeId</c>"] Transaction id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>dest</c>"] Destination
        /// </summary>
        [JsonPropertyName("dest")]
        public string Destination { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>tag</c>"] Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>fee</c>"] Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// ["<c>toAddress</c>"] Target address
        /// </summary>
        [JsonPropertyName("toAddress")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fromAddress</c>"] From address
        /// </summary>
        [JsonPropertyName("fromAddress")]
        public string FromAddress { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>confirm</c>"] Number of confirmed blocks
        /// </summary>
        [JsonPropertyName("confirm"), JsonConverter(typeof(IntConverter))]
        public int? Confirmations { get; set; }
        /// <summary>
        /// ["<c>chain</c>"] Network
        /// </summary>
        [JsonPropertyName("chain")]
        public string? Network { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Creation time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }
}

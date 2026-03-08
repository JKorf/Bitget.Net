using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Deposit record
    /// </summary>
    [SerializationModel]
    public record BitgetDepositRecord
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
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
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

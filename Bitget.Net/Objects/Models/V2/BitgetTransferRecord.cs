using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Transfer record
    /// </summary>
    [SerializationModel]
    public record BitgetTransferRecord
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// ["<c>toType</c>"] To account
        /// </summary>
        [JsonPropertyName("toType")]
        public TransferAccountType ToAccount { get; set; }
        /// <summary>
        /// ["<c>fromType</c>"] From account
        /// </summary>
        [JsonPropertyName("fromType")]
        public TransferAccountType FromAccount { get; set; }
        /// <summary>
        /// ["<c>toSymbol</c>"] To symbol
        /// </summary>
        [JsonPropertyName("toSymbol")]
        public string? ToSymbol { get; set; }
        /// <summary>
        /// ["<c>fromSymbol</c>"] From symbol
        /// </summary>
        [JsonPropertyName("fromSymbol")]
        public string? FromSymbol { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>transferId</c>"] Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>ts</c>"] Transfer time
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }
}

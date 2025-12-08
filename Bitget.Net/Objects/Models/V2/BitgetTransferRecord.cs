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
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// To account
        /// </summary>
        [JsonPropertyName("toType")]
        public TransferAccountType ToAccount { get; set; }
        /// <summary>
        /// From account
        /// </summary>
        [JsonPropertyName("fromType")]
        public TransferAccountType FromAccount { get; set; }
        /// <summary>
        /// To symbol
        /// </summary>
        [JsonPropertyName("toSymbol")]
        public string? ToSymbol { get; set; }
        /// <summary>
        /// From symbol
        /// </summary>
        [JsonPropertyName("fromSymbol")]
        public string? FromSymbol { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// Transfer time
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }
}

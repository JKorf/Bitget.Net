using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// 
    /// </summary>
    [SerializationModel]
    public record BitgetSubAccountTransfer
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
        /// To account type
        /// </summary>
        [JsonPropertyName("toType")]
        public AccountType ToType { get; set; }
        /// <summary>
        /// From account type
        /// </summary>
        [JsonPropertyName("fromType")]
        public AccountType FromType { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOid { get; set; }
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// From user id
        /// </summary>
        [JsonPropertyName("fromUserId")]
        public long FromUserId { get; set; }
        /// <summary>
        /// To user id
        /// </summary>
        [JsonPropertyName("toUserId")]
        public long ToUserId { get; set; }
    }
}

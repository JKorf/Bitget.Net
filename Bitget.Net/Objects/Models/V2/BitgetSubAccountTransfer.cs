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
        /// ["<c>toType</c>"] To account type
        /// </summary>
        [JsonPropertyName("toType")]
        public AccountType ToType { get; set; }
        /// <summary>
        /// ["<c>fromType</c>"] From account type
        /// </summary>
        [JsonPropertyName("fromType")]
        public AccountType FromType { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>ts</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>clientOid</c>"] Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOid { get; set; }
        /// <summary>
        /// ["<c>transferId</c>"] Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fromUserId</c>"] From user id
        /// </summary>
        [JsonPropertyName("fromUserId")]
        public long FromUserId { get; set; }
        /// <summary>
        /// ["<c>toUserId</c>"] To user id
        /// </summary>
        [JsonPropertyName("toUserId")]
        public long ToUserId { get; set; }
    }
}

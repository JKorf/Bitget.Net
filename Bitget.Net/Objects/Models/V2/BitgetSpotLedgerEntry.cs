using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ledger entry
    /// </summary>
    [SerializationModel]
    public record BitgetSpotLedgerEntry
    {
        /// <summary>
        /// ["<c>cTime</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>groupType</c>"] Group type
        /// </summary>
        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }
        /// <summary>
        /// ["<c>businessType</c>"] Business type
        /// </summary>
        [JsonPropertyName("businessType")]
        public BusinessType BusinessType { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>balance</c>"] Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// ["<c>fees</c>"] Fees
        /// </summary>
        [JsonPropertyName("fees")]
        public decimal Fees { get; set; }
        /// <summary>
        /// ["<c>billId</c>"] Id
        /// </summary>
        [JsonPropertyName("billId")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>bizOrderId</c>"] Business order id
        /// </summary>
        [JsonPropertyName("bizOrderId")]
        public string BusinessOrderId { get; set; } = string.Empty;
    }
}

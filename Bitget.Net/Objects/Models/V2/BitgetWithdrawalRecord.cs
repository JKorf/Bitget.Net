using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Converters;
using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Destination
        /// </summary>
        [JsonPropertyName("dest")]
        public string Destination { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public TransferStatus Status { get; set; }
        /// <summary>
        /// Target address
        /// </summary>
        [JsonPropertyName("toAddress")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// From address
        /// </summary>
        [JsonPropertyName("fromAddress")]
        public string FromAddress { get; set; } = string.Empty;
        /// <summary>
        /// Number of confirmed blocks
        /// </summary>
        [JsonPropertyName("confirm"), JsonConverter(typeof(IntConverter))]
        public int? Confirmations { get; set; }
        /// <summary>
        /// Network
        /// </summary>
        [JsonPropertyName("chain")]
        public string? Network { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }
}

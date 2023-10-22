using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Deposit info
    /// </summary>
    public class BitgetDeposit
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("txId")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Withdrawal status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// To address
        /// </summary>
        [JsonProperty("toAddress")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Confirmations
        /// </summary>
        [JsonProperty("confirm")]
        public int Confirm { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        [JsonProperty("tag")]
        public string? Tag { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime")]
        public DateTime UpdateTime { get; set; }
    }
}

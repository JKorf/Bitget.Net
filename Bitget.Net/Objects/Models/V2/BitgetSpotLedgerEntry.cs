using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ledger entry
    /// </summary>
    public record BitgetSpotLedgerEntry
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Group type
        /// </summary>
        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }
        /// <summary>
        /// Business type
        /// </summary>
        [JsonPropertyName("businessType")]
        public BusinessType BusinessType { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonPropertyName("fees")]
        public decimal Fees { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("billId")]
        public string Id { get; set; } = string.Empty;
    }
}

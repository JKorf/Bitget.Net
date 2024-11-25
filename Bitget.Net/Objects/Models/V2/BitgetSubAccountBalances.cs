using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Sub account balances
    /// </summary>
    public record BitgetSubAccountBalances
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// Assets
        /// </summary>
        [JsonPropertyName("assetsList")]
        public IEnumerable<BitgetSubAccountBalance> Assets { get; set; } = Array.Empty<BitgetSubAccountBalance>();
    }

    /// <summary>
    /// Sub account balance
    /// </summary>
    public record BitgetSubAccountBalance
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Restricted availability, for spot copy trading
        /// </summary>
        [JsonPropertyName("limitAvailable")]
        public decimal LimitAvailable { get; set; }
        /// <summary>
        /// Frozen
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Locked
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }


}

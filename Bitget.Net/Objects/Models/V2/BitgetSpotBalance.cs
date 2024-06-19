using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Spot balance
    /// </summary>
    public record BitgetSpotBalance
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available quantity
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Frozen quantity
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Locked quantity
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Restricted availability, for spot copy trading
        /// </summary>
        [JsonPropertyName("limitAvailable")]
        public decimal? RetrictedAvailable { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }
}

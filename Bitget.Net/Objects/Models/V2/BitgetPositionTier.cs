using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position tier
    /// </summary>
    public record BitgetPositionTier
    {
        /// <summary>
        /// Symbol 
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Level 
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; } = string.Empty;
        /// <summary>
        /// Start  unit
        /// </summary>
        [JsonPropertyName("startUnit")]
        public decimal StartUnit { get; set; }
        /// <summary>
        /// End unit 
        /// </summary>
        [JsonPropertyName("endUnit")]
        public decimal EndUnit { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Maintenance margin rate
        /// </summary>
        [JsonPropertyName("keepMarginRate")]
        public decimal MaintenanceMarginRate { get; set; }
    }
}

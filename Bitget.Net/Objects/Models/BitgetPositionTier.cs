using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position tier
    /// </summary>
    public class BitgetPositionTier
    {
        /// <summary>
        /// Tier
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
        /// <summary>
        /// Start value
        /// </summary>
        [JsonProperty("startUnit")]
        public int StartUnit { get; set; }
        /// <summary>
        /// End value
        /// </summary>
        [JsonProperty("endUnit")]
        public int EndUnit { get; set; }
        /// <summary>
        /// Leverage multiple
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Margin Rate, The value corresponding to the position, when the margin rate of the position is less than the maintenance margin rate, forced decreased or liquidation will be triggered
        /// </summary>
        [JsonProperty("keepMarginRate")]
        public decimal KeepMarginRate { get; set; }
    }
}

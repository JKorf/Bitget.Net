using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position mode
    /// </summary>
    public class BitgetPositionMode
    {
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// True: DoubleHold, false: SingleHold
        /// </summary>
        [JsonProperty("dualSidePosition")]
        public bool DualSidePosition { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Max positions info
    /// </summary>
    public class BitgetMaxPositions
    {
        /// <summary>
        /// Max open positions
        /// </summary>
        [JsonProperty("openCount")]
        public int OpenCount { get; set; }
    }
}

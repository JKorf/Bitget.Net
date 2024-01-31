using Newtonsoft.Json;

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

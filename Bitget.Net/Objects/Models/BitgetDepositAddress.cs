using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Deposit address
    /// </summary>
    public class BitgetDepositAddress
    {
        /// <summary>
        /// Deposit address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Tag
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}

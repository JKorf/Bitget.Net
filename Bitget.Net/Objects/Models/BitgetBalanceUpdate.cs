using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Balance update
    /// </summary>
    public class BitgetBalanceUpdate
    {
        /// <summary>
        /// Asset id
        /// </summary>
        [JsonProperty("coinId")]
        public string AssetId { get; set; } = string.Empty;
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coinName")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available quantity
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }
    }
}

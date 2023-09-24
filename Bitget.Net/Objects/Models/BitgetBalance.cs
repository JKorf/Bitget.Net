using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Balance info
    /// </summary>
    public class BitgetBalance
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
        public string AssetName { get; set; } = string.Empty;
        /// <summary>
        /// Available balance
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Frozen balance
        /// </summary>
        [JsonProperty("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Locked balance
        /// </summary>
        [JsonProperty("lock")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonProperty("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
    }
}

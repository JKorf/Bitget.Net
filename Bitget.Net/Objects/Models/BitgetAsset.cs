using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Asset info
    /// </summary>
    public class BitgetAsset
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
        /// Transferable
        /// </summary>
        [JsonProperty("transfer")]
        public bool Transferable { get; set; }
        [JsonProperty("chains")]
        public IEnumerable<BitgetNetwork> Networks { get; set; } = Array.Empty<BitgetNetwork>();
    }
}

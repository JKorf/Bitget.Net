using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Result
    /// </summary>
    public class BitgetResult
    {
        /// <summary>
        /// Is successful
        /// </summary>
        [JsonProperty("result")]
        public bool Success { get; set; }
    }
}

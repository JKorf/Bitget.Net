using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position risk
    /// </summary>
    public class BitgetPositionRisk
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbolName")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position limit
        /// </summary>
        [JsonProperty("ratio")]
        public decimal PositionLimit { get; set; }
    }
}

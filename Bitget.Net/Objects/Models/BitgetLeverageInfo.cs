using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Leverage info
    /// </summary>
    public class BitgetLeverageInfo
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Min leverage
        /// </summary>
        [JsonProperty("minLeverage")]
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        [JsonProperty("maxLeverage")]
        public decimal MaxLeverage { get; set; }
    }
}

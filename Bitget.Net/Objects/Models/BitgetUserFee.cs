using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// User fee info
    /// </summary>
    public class BitgetUserFee
    {
        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonProperty("makerRate")]
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerRate { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonProperty("takerRate")]
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerRate { get; set; }
    }
}

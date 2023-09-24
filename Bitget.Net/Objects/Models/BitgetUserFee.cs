using Newtonsoft.Json;

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
        public decimal MakerRate { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonProperty("takerRate")]
        public decimal TakerRate { get; set; }
    }
}

using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Kline info
    /// </summary>
    public class BitgetKline
    {
        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("open")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonProperty("high")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("low")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("close")]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("quoteVol")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonProperty("baseVol")]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Usdt volume
        /// </summary>
        [JsonProperty("usdtVol")]
        public decimal UsdtVolume { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
    }
}

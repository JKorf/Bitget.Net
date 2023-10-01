using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// User leverage info
    /// </summary>
    public class BitgetUserLeverage
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Long leverage
        /// </summary>
        [JsonProperty("longLeverage")]
        public decimal LongLeverage { get; set; }
        /// <summary>
        /// Short leverage
        /// </summary>
        [JsonProperty("shortLeverage")]
        public decimal ShortLeverage { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("marginMode"), JsonConverter(typeof(EnumConverter))]
        public BitgetMarginMode MarginMode { get; set; }
    }
}

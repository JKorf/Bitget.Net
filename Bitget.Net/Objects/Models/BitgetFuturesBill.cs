using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bill info
    /// </summary>
    public class BitgetFuturesBill
    {
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("ctime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Transaction type
        /// </summary>
        [JsonProperty("business")]
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonProperty("feeByCoupon")]
        public decimal? FeeDeduct { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Bill id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
    }
}

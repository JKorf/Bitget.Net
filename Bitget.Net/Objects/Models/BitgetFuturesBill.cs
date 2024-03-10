using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bills page
    /// </summary>
    public class BitgetFuturesBills : BitgetPaginationBase
    {
        /// <summary>
        /// Bills list
        /// </summary>
        [JsonProperty("bills")]
        public IEnumerable<BitgetFuturesBill> Bills { get; set; } = Array.Empty<BitgetFuturesBill>();
    }

    /// <summary>
    /// Bill info
    /// </summary>
    public class BitgetFuturesBill : BitgetPaginationBase
    {
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("coin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Transaction type
        /// </summary>
        [JsonProperty("businessType")]
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
        public string? FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Bill id
        /// </summary>
        [JsonProperty("billId")]
        public string Id { get; set; } = string.Empty;
    }
}

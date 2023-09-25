using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BitgetUserTrade
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("fillId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("fillPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonProperty("fillQuantity")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Filled value
        /// </summary>
        [JsonProperty("fillTotalAmount")]
        public decimal Value { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("feeCcy")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("fees")]
        public decimal Fee { get; set; }
    }
}

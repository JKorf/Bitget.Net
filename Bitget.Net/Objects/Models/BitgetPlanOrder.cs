using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Plan order
    /// </summary>
    public class BitgetPlanOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Execution price
        /// </summary>
        [JsonProperty("executePrice")]
        public decimal? ExecutePrice { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice")]
        public decimal TriggerPrice { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        public BitgetPlanOrderStatus Status { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType")]
        public BitgetOrderType Type { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// 	Order trigger type
        /// </summary>
        [JsonProperty("triggerType")]
        public BitgetTriggerType TriggerType { get; set; }
        /// <summary>
        /// 	Order trigger type
        /// </summary>
        [JsonProperty("enterPointSource")]
        public BitgetOrderPlacementSource Source { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Place type
        /// </summary>
        [JsonProperty("placeType")]
        public string? PlaceType { get; set; }
    }
}

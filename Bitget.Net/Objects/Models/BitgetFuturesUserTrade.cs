using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Futures user trade
    /// </summary>
    public class BitgetFuturesUserTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("sizeQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("side")]
        public BitgetTradeSide Side { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tradeSide")]
        public string TradeSide { get; set; } = string.Empty;
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("fillAmount")]
        public decimal QuantityFilled { get; set; }

        /// <summary>
        /// Profit
        /// </summary>
        [JsonProperty("profit")]
        public decimal Profit { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("enterPointSource")]
        public BitgetOrderPlacementSource PlaceSource { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode")]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("takerMakerFlag")]
        public BitgetExecutionType ExecutionType { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ctime")]
        public DateTime Timestamp { get; set; }
    }
}

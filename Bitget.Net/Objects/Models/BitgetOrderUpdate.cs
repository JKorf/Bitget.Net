using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Order update info
    /// </summary>
    public class BitgetOrderUpdate
    {
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("instId")]
        public string SymbolId { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("ordId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("clOrdId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("px")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Order original quantity
        /// </summary>
        [JsonProperty("sz")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// The purchase amount, which will be returned when the market price is purchased
        /// </summary>
        [JsonProperty("notional")]
        public decimal? Notional { get; set; }
        /// <summary>
        /// The order type
        /// </summary>
        [JsonProperty("ordType")]
        public BitgetOrderType? OrderType { get; set; }
        /// <summary>
        /// The order type
        /// </summary>
        [JsonProperty("force")]
        public BitgetOrderForce? Force { get; set; }

        /// <summary>
        /// The order side
        /// </summary>
        [JsonProperty("side")]
        public BitgetOrderSide? OrderSide { get; set; }
        /// <summary>
        /// Fill price
        /// </summary>
        [JsonProperty("fillPx")]
        public decimal? FillPrice { get; set; }
        /// <summary>
        /// Fill quantity
        /// </summary>
        [JsonProperty("fillSz")]
        public decimal? FillQuantity { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("tradeId")]
        public string? TradeId { get; set; }
        /// <summary>
        /// Fill fee
        /// </summary>
        [JsonProperty("fillFee")]
        public decimal? FillFee { get; set; }
        /// <summary>
        /// Fill fee asset
        /// </summary>
        [JsonProperty("fillFeeCcy")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// Fill time
        /// </summary>
        [JsonProperty("fillTime")]
        public DateTime? FillTime { get; set; }
        /// <summary>
        /// Fill type
        /// </summary>
        [JsonProperty("execType")]
        public BitgetExecutionType? ExecutionType { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("accFillSz")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Average trade price
        /// </summary>
        [JsonProperty("avgPx")]
        public decimal AverageTradePrice { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        public BitgetOrderStatus Status { get; set; }
        /// <summary>
        /// Order source
        /// </summary>
        [JsonProperty("eps")]
        public BitgetOrderPlacementSource Source { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Fee info
        /// </summary>
        [JsonProperty("orderFee")]
        public IEnumerable<BitgetOrderFeeQuantity> OrderFees { get; set; } = Array.Empty<BitgetOrderFeeQuantity>();
    }

    /// <summary>
    /// Fee info
    /// </summary>
    public class BitgetOrderFeeQuantity
    {
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("feeCcy")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
    }
}

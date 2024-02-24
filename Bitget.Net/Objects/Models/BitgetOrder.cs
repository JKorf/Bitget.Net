using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bitget order
    /// </summary>
    public class BitgetOrder
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; } = string.Empty;
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
        /// Client order id
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Order quantity (base asset when orderType=limit; quote asset when orderType=market)
        /// </summary>
        [JsonProperty("quantity")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType")]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        public BitgetOrderStatus Status { get; set; }
        /// <summary>
        /// Transaction price
        /// </summary>
        [JsonProperty("fillPrice")]
        public decimal FillPrice { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("fillQuantity")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("fillTotalAmount")]
        public decimal ValueFilled { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("enterPointSource")]
        public BitgetOrderPlacementSource PlaceSource { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Order source
        /// </summary>
        [JsonProperty("orderSource")]
        public string OrderSource { get; set; } = string.Empty;
        [JsonProperty("feeDetail")]
        internal string FeeDetailsInt { get; set; } = string.Empty;

        /// <summary>
        /// Fee details
        /// </summary>
        public Dictionary<string, BitgetOrderFee>? FeeDetails => string.IsNullOrEmpty(FeeDetailsInt) ? null : JsonConvert.DeserializeObject<Dictionary<string, BitgetOrderFee>>(FeeDetailsInt);
    }

    /// <summary>
    /// Order fee
    /// </summary>
    public class BitgetOrderFee
    {
        /// <summary>
        /// Deduction
        /// </summary>
        [JsonProperty("deduction")]
        public bool Deduction { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("feeCoinCode")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Total deduction fee
        /// </summary>
        [JsonProperty("totalDeductionFee")]
        public decimal DeductionFee { get; set; }
        /// <summary>
        /// Total fee
        /// </summary>
        [JsonProperty("totalFee")]
        public decimal TotalFee { get; set; }
    }
}

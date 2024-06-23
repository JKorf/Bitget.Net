using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// User trade update
    /// </summary>
    public record BitgetUserTradeUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role Role { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public IEnumerable<BitgetUserTradeFee> Fees { get; set; } = null!;
    }

    /// <summary>
    /// Trade fee
    /// </summary>
    public record BitgetUserTradeFee
    {
        /// <summary>
        /// Deduction
        /// </summary>
        [JsonPropertyName("deduction")]
        public bool Deduction { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Total deduction fee
        /// </summary>
        [JsonPropertyName("totalDeductionFee")]
        public decimal? TotalDeductionFee { get; set; }
        /// <summary>
        /// Total fee
        /// </summary>
        [JsonPropertyName("totalFee")]
        public decimal TotalFee { get; set; }
    }
}

using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// User trade info
    /// </summary>
    [SerializationModel]
    public record BitgetUserTrade
    {
        /// <summary>
        /// ["<c>userId</c>"] User id
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tradeId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>amount</c>"] Quote quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ["<c>tradeScope</c>"] Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role Role { get; set; }
        /// <summary>
        /// ["<c>feeDetail</c>"] Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetTradeFee Fees { get; set; } = null!;
    }

    /// <summary>
    /// Trade fee
    /// </summary>
    [SerializationModel]
    public record BitgetTradeFee
    {
        /// <summary>
        /// ["<c>deduction</c>"] Deduction
        /// </summary>
        [JsonPropertyName("deduction")]
        public bool Deduction { get; set; }
        /// <summary>
        /// ["<c>feeCoin</c>"] Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>totalDeductionFee</c>"] Total deduction fee
        /// </summary>
        [JsonPropertyName("totalDeductionFee")]
        public decimal? TotalDeductionFee { get; set; }
        /// <summary>
        /// ["<c>totalFee</c>"] Total fee
        /// </summary>
        [JsonPropertyName("totalFee")]
        public decimal TotalFee { get; set; }
    }
}

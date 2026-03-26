using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Converters;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order info
    /// </summary>
    [SerializationModel]
    public record BitgetOrder
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
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string? BaseAsset { get; set; }
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string? QuoteAsset { get; set; }
        /// <summary>
        /// ["<c>cancelReason</c>"] Cancel reason
        /// </summary>
        [JsonPropertyName("cancelReason")]
        public string? CancelReason { get; set; }
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }

        // When requesting open orders:
        //   BasePrice = Avg Fill Price
        //   PriceAvg = Order price
        // Else
        //   PriceAvg = Avg Fill Price
        //   Price = Order price

        /// <summary>
        /// Order price
        /// </summary>
        public decimal? Price => PriceInt ?? AveragePriceInt;
        /// <summary>
        /// Average fill price
        /// </summary>
        public decimal? AveragePrice => BasePrice ?? AveragePriceInt;

        [JsonInclude, JsonPropertyName("price")]
        internal decimal? PriceInt { get; set; }
        [JsonInclude, JsonPropertyName("priceAvg")]
        internal decimal? AveragePriceInt { get; set; }

        /// <summary>
        /// ["<c>basePrice</c>"] Base price
        /// </summary>
        [JsonInclude, JsonPropertyName("basePrice")]
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// ["<c>triggerPrice</c>"] Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
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
        /// ["<c>status</c>"] Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// ["<c>tpslType</c>"] Take profit / stop loss type
        /// </summary>
        [JsonPropertyName("tpslType")]
        public TakeProfitStopLossType? TpslType { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Base volume
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>quoteVolume</c>"] Quote quantity volume
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderSource</c>"] Order source
        /// </summary>
        [JsonPropertyName("orderSource")]
        public string? OrderSource { get; set; }
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
        /// ["<c>feeDetail</c>"] Fee info
        /// </summary>
        [JsonPropertyName("feeDetail")]
        [JsonConverter(typeof(OrderFeeConverter))]
        public BitgetOrderFees? Fees { get; set; }
    }

    /// <summary>
    /// Order fees
    /// </summary>
    [SerializationModel]
    public record BitgetOrderFees
    {
        /// <summary>
        /// ["<c>newFees</c>"] New fee info
        /// </summary>
        [JsonPropertyName("newFees")]
        public BitgetOrderNewFees? NewFees { get; set; }
    }

    /// <summary>
    /// Order fee info
    /// </summary>
    [SerializationModel]
    public record BitgetOrderNewFees
    {
        /// <summary>
        /// ["<c>c</c>"] Amount deducted by coupons, unit：currency obtained from the transaction.
        /// </summary>
        [JsonPropertyName("c")]
        public decimal CouponDeduction { get; set; }
        /// <summary>
        /// ["<c>d</c>"] Amount deducted in BGB (Bitget Coin), unit：BGB
        /// </summary>
        [JsonPropertyName("d")]
        public decimal BgbDeduction { get; set; }
        /// <summary>
        /// ["<c>r</c>"] If the BGB balance is insufficient to cover the fees, the remaining amount is deducted from the currency obtained from the transaction.
        /// </summary>
        [JsonPropertyName("r")]
        public decimal RemainingFeeDeduction { get; set; }
        /// <summary>
        /// ["<c>t</c>"] The total fee amount to be paid
        /// </summary>
        [JsonPropertyName("t")]
        public decimal TotalFee { get; set; }
    }
}

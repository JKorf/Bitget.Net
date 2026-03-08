using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Liquidation order info
    /// </summary>
    [SerializationModel]
    public record BitgetCrossLiquidationOrder
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide? OrderSide { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Price average
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? PriceAverage { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>fillSize</c>"] Fill quantity
        /// </summary>
        [JsonPropertyName("fillSize")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Order quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// ["<c>amount</c>"] Quantity filled in quote asset
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fromCoin</c>"] From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string? FromAsset { get; set; }
        /// <summary>
        /// ["<c>toCoin</c>"] To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string? ToAsset { get; set; }
        /// <summary>
        /// ["<c>fromSize</c>"] From quantity
        /// </summary>
        [JsonPropertyName("fromSize")]
        public string? FromQuantity { get; set; }
        /// <summary>
        /// ["<c>toSize</c>"] To quantity
        /// </summary>
        [JsonPropertyName("toSize")]
        public string? ToQuantity { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

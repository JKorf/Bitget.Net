using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType? OrderType { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide? OrderSide { get; set; }
        /// <summary>
        /// Price average
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? PriceAverage { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Fill quantity
        /// </summary>
        [JsonPropertyName("fillSize")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Quantity filled in quote asset
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string? FromAsset { get; set; }
        /// <summary>
        /// To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string? ToAsset { get; set; }
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonPropertyName("fromSize")]
        public string? FromQuantity { get; set; }
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonPropertyName("toSize")]
        public string? ToQuantity { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

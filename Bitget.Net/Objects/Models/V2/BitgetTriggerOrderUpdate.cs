using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Trigger order update
    /// </summary>
    [SerializationModel]
    public record BitgetTriggerOrderUpdate
    {
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
        /// <summary>
        /// ["<c>instId</c>"] Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>triggerPrice</c>"] Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal TriggerPrice { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>actualSize</c>"] Actual quantity
        /// </summary>
        [JsonPropertyName("actualSize")]
        public decimal ActualQuantity { get; set; }
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
        /// ["<c>executePrice</c>"] Order price
        /// </summary>
        [JsonPropertyName("executePrice")]
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// ["<c>planType</c>"] Quantity type
        /// </summary>
        [JsonPropertyName("planType")]
        public QuantityType? QuantityType { get; set; }
        /// <summary>
        /// ["<c>triggerType</c>"] Trigger price type
        /// </summary>
        [JsonPropertyName("triggerType")]
        public TriggerPriceType TriggerPriceType { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Trigger order status
        /// </summary>
        [JsonPropertyName("status")]
        public TriggerOrderStatus Status { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
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
    }
}

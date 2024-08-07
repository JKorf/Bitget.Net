using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order update
    /// </summary>
    public record BitgetOrderUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order amount. When Side = Buy, it represents the amount of quote asset; When Side = Sell, it represents the amount of base asset.
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("newSize")]
        public decimal? OrderQuantity { get; set; }
        /// <summary>
        /// Buy value for market order
        /// </summary>
        [JsonPropertyName("notional")]
        public decimal? Notional { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        [JsonPropertyName("ordType")]
        internal OrderType OrderTypeInt { set => OrderType = value; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal? LastTradePrice { get; set; }
        /// <summary>
        /// Number of latest filled orders
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? BaseVolume { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string? TradeId { get; set; }
        /// <summary>
        /// Last trade time
        /// </summary>
        [JsonPropertyName("fillTime")]
        public DateTime? LastTradeTime { get; set; }
        /// <summary>
        /// Last trade fee
        /// </summary>
        [JsonPropertyName("fillFee")]
        public decimal? LastTradeFee { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("fillFeeCoin")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// Last trade role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role? LastTradeRole { get; set; }
        /// <summary>
        /// Total quantity filled
        /// </summary>
        [JsonPropertyName("accBaseVolume")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Average trade price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public IEnumerable<BitgetOrderUpdateFee> Fees { get; set; } = Array.Empty<BitgetOrderUpdateFee>();
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

    /// <summary>
    /// Trade fee
    /// </summary>
    public record BitgetOrderUpdateFee
    {
        /// <summary>
        /// Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
    }
}

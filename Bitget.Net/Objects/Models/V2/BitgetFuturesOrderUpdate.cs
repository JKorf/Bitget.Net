using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures order update
    /// </summary>
    public record BitgetFuturesOrderUpdate
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
        [JsonPropertyName("clientOId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Last trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string? LastTradeId { get; set; }
        /// <summary>
        /// Quantity filled of last trade
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? LastTradeQuantity { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role? LastTradeRole { get; set; }
        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonPropertyName("posSide")]
        public PositionSide PositionSide { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// Estimated USD value of orders
        /// </summary>
        [JsonPropertyName("notionalUsd")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Profit and loss
        /// </summary>
        [JsonPropertyName("pnl")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide? TradeSide { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode? PositionMode { get; set; }

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
        /// Total filled quantity
        /// </summary>
        [JsonPropertyName("accBaseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Last trade fee
        /// </summary>
        [JsonPropertyName("fillFee")]
        public decimal LastTradeFee { get; set; }
        /// <summary>
        /// Last trade fee asset
        /// </summary>
        [JsonPropertyName("fillFeeCoin")]
        public string LastTradeFeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Last trade usd value
        /// </summary>
        [JsonPropertyName("fillNotionalUsd")]
        public decimal LastTradeUsdValue { get; set; }
        /// <summary>
        /// Last trade fill price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal? LastTradeFillPrice { get; set; }
        /// <summary>
        /// Last trade fill time
        /// </summary>
        [JsonPropertyName("fillTime")]
        public DateTime? LastTradeFillTime { get; set; }
        /// <summary>
        /// Total filled quantity
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public IEnumerable<BitgetOrderFeeQuantity> Fees { get; set; } = Array.Empty<BitgetOrderFeeQuantity>();
    }
}

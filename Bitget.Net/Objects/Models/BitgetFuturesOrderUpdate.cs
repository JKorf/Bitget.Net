using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bitget futures order update
    /// </summary>
    public class BitgetFuturesOrderUpdate
    {
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
        /// Symbol
        /// </summary>
        [JsonProperty("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order quantity (base asset when orderType=limit; quote asset when orderType=market)
        /// </summary>
        [JsonProperty("sz")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("accFillSz")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; } // TODO
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("px")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Average price
        /// </summary>
        [JsonProperty("avgPx")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// Total profits
        /// </summary>
        [JsonProperty("pnl")]
        public decimal? ProfitAndLoss { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonProperty("posSide"), JsonConverter(typeof(EnumConverter))]
        public BitgetPositionSide PositionSide { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("tdMode"), JsonConverter(typeof(EnumConverter))]
        public BitgetMarginMode MarginMode { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("tgtCcy")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tS")]
        public string TradeSide { get; set; } = string.Empty;
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonProperty("lever")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonProperty("low")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("hM"), JsonConverter(typeof(EnumConverter))]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("ordType"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderStatus Status { get; set; }
        /// <summary>
        /// Estimated national value in USD of order
        /// </summary>
        [JsonProperty("notionalUsd")]
        public decimal NotionalValue { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("eps"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderPlacementSource PlaceSource { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("force"), JsonConverter(typeof(EnumConverter))]
        public BitgetTimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Last filled price
        /// </summary>
        [JsonProperty("fillPx")]
        public decimal? LastFillPrice { get; set; }

        /// <summary>
        /// Last filled quantity
        /// </summary>
        [JsonProperty("fillSz")]
        public decimal? LastFillQuantity { get; set; }

        /// <summary>
        /// Last filled fee
        /// </summary>
        [JsonProperty("fillFee")]
        public decimal? LastFillFee { get; set; }
        /// <summary>
        /// Last filled time
        /// </summary>
        [JsonProperty("fillTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LastFillTime { get; set; }
        /// <summary>
        /// Last traded id
        /// </summary>
        [JsonProperty("tradeId")]
        public string LastTradeId { get; set; } = string.Empty;
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("execType"), JsonConverter(typeof(EnumConverter))]
        public BitgetExecutionType ExecutionType { get; set; }

        /// <summary>
        /// Filled notional value in USD of order
        /// </summary>
        [JsonProperty("fillNotionalUsd")]
        public decimal? NotionalValueFilled { get; set; }
        /// <summary>
        /// Paid order fees
        /// </summary>
        [JsonProperty("orderFee")]
        public IEnumerable<BitgetOrderFeeQuantity> Fees { get; set; } = Array.Empty<BitgetOrderFeeQuantity>();
    }
}

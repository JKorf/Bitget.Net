using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Margin Symbol
    /// </summary>
    public record BitgetMarginSymbol
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Max crossed leverage
        /// </summary>
        [JsonPropertyName("maxCrossedLeverage")]
        public decimal MaxCrossedLeverage { get; set; }
        /// <summary>
        /// Max isolated leverage
        /// </summary>
        [JsonPropertyName("maxIsolatedLeverage")]
        public decimal MaxIsolatedLeverage { get; set; }
        /// <summary>
        /// Warning risk ratio
        /// </summary>
        [JsonPropertyName("warningRiskRatio")]
        public decimal WarningRiskRatio { get; set; }
        /// <summary>
        /// Liquidation risk ratio
        /// </summary>
        [JsonPropertyName("liquidationRiskRatio")]
        public decimal LiquidationRiskRatio { get; set; }
        /// <summary>
        /// Min trade quantity
        /// </summary>
        [JsonPropertyName("minTradeAmount")]
        public decimal MinTradeQuantity { get; set; }
        /// <summary>
        /// Max trade quantity
        /// </summary>
        [JsonPropertyName("maxTradeAmount")]
        public decimal MaxTradeQuantity { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// Price precision
        /// </summary>
        [JsonPropertyName("pricePrecision")]
        public decimal PricePrecision { get; set; }
        /// <summary>
        /// Quantity precision
        /// </summary>
        [JsonPropertyName("quantityPrecision")]
        public decimal QuantityPrecision { get; set; }
        /// <summary>
        /// Min trade USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinTradeUSDT { get; set; }
        /// <summary>
        /// User min borrow
        /// </summary>
        [JsonPropertyName("userMinBorrow")]
        public decimal UserMinBorrow { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public MarginSymbolStatus? Status { get; set; }
        /// <summary>
        /// Is isolated base borrowable
        /// </summary>
        [JsonPropertyName("isIsolatedBaseBorrowable")]
        public bool IsIsolatedBaseBorrowable { get; set; }
        /// <summary>
        /// Is isolated quote borrowable
        /// </summary>
        [JsonPropertyName("isIsolatedQuoteBorrowable")]
        public bool IsIsolatedQuoteBorrowable { get; set; }
        /// <summary>
        /// Is cross borrowable
        /// </summary>
        [JsonPropertyName("isCrossBorrowable")]
        public bool IsCrossBorrowable { get; set; }
    }


}

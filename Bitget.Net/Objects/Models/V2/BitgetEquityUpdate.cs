using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Equity update
    /// </summary>
    public record BitgetEquityUpdate
    {
        /// <summary>
        /// BTC equity
        /// </summary>
        [JsonPropertyName("btcEquity")]
        public decimal BtcEquity { get; set; }
        /// <summary>
        /// USDT equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// Total multi-asset margin
        /// </summary>
        [JsonPropertyName("unionTotalMargin")]
        public decimal UnionTotalMargin { get; set; }
        /// <summary>
        /// Available balance under multi-asset margin mode
        /// </summary>
        [JsonPropertyName("unionAvailable")]
        public decimal UnionAvailable { get; set; }
        /// <summary>
        /// Maintenance margin under multi-asset margin mode
        /// </summary>
        [JsonPropertyName("unionMm")]
        public decimal UnionMaintenanceMargin { get; set; }
    }
}

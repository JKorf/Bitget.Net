using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures balance
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesBalanceUpdate
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity locked
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Quantity available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Maximum available balance to open positions
        /// </summary>
        [JsonPropertyName("maxOpenPosAvailable")]
        public decimal MaxOpenPosAvailable { get; set; }
        /// <summary>
        /// Max transferable quantity
        /// </summary>
        [JsonPropertyName("maxTransferOut")]
        public decimal MaxTransferable { get; set; }
        /// <summary>
        /// Account equity
        /// </summary>
        [JsonPropertyName("equity")]
        public decimal Equity { get; set; }
        /// <summary>
        /// Usdt equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// Risk ratio in cross margin
        /// </summary>
        [JsonPropertyName("crossedRiskRate")]
        public decimal CrossRiskRate { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedPnl { get; set; }
    }
}

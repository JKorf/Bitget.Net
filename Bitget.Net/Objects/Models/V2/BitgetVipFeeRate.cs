using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// VIP fee rate
    /// </summary>
    public record BitgetVipFeeRate
    {
        /// <summary>
        /// VIP level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// Trading volume for reaching this level
        /// </summary>
        [JsonPropertyName("dealAmount")]
        public decimal TradingVolume { get; set; }
        /// <summary>
        /// Asset value for reaching this level
        /// </summary>
        [JsonPropertyName("assetAmount")]
        public decimal AssetValue { get; set; }
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
        /// BTC max withdrawal quantity per 24 hours
        /// </summary>
        [JsonPropertyName("btcWithdrawAmount")]
        public decimal BtcWithdrawQuantity { get; set; }
        /// <summary>
        /// USDT max withdrawal quantity per 24 hours
        /// </summary>
        [JsonPropertyName("usdtWithdrawAmount")]
        public decimal UsdtWithdrawQuantity { get; set; }
    }
}

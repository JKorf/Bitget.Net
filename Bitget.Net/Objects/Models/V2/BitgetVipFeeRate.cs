using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// VIP fee rate
    /// </summary>
    [SerializationModel]
    public record BitgetVipFeeRate
    {
        /// <summary>
        /// ["<c>level</c>"] VIP level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// ["<c>dealAmount</c>"] Trading volume for reaching this level
        /// </summary>
        [JsonPropertyName("dealAmount")]
        public decimal TradingVolume { get; set; }
        /// <summary>
        /// ["<c>assetAmount</c>"] Asset value for reaching this level
        /// </summary>
        [JsonPropertyName("assetAmount")]
        public decimal AssetValue { get; set; }
        /// <summary>
        /// ["<c>takerFeeRate</c>"] Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>btcWithdrawAmount</c>"] BTC max withdrawal quantity per 24 hours
        /// </summary>
        [JsonPropertyName("btcWithdrawAmount")]
        public decimal BtcWithdrawQuantity { get; set; }
        /// <summary>
        /// ["<c>usdtWithdrawAmount</c>"] USDT max withdrawal quantity per 24 hours
        /// </summary>
        [JsonPropertyName("usdtWithdrawAmount")]
        public decimal UsdtWithdrawQuantity { get; set; }
    }
}

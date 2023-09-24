using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Fee info
    /// </summary>
    public class BitgetFeeLevel
    {
        /// <summary>
        /// VIP level
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
        /// <summary>
        /// 30 day USDT transaction volume
        /// </summary>
        [JsonProperty("dealAmount")]
        public decimal TransactionVolume { get; set; }
        /// <summary>
        /// Asset quantity USDT
        /// </summary>
        [JsonProperty("assetAmount")]
        public decimal AssetQuantity { get; set; }
        /// <summary>
        /// Taker fee rate, actual fee rate please refer to official announcement when '0'
        /// </summary>
        [JsonProperty("takerFeeRate")]
        public decimal? TakerFeeRate { get; set; }
        /// <summary>
        /// Maker fee rate, actual fee rate please refer to official announcement when '0'
        /// </summary>
        [JsonProperty("makerFeeRate")]
        public decimal? MakerFeeRate { get; set; }
        /// <summary>
        /// 24 hours withdraw amount (BTC)
        /// </summary>
        [JsonProperty("withdrawAmount")]
        public decimal WithdrawQuantity { get; set; }
        /// <summary>
        /// 24 hours withdraw amount (USDT)
        /// </summary>
        [JsonProperty("withdrawAmountUSDT")]
        public decimal WithdrawQuantityUsdt { get; set; }
    }
}

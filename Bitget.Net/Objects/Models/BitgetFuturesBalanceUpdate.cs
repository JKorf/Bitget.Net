using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Balance update
    /// </summary>
    public class BitgetFuturesBalanceUpdate
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Locked quantity
        /// </summary>
        [JsonProperty("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// Available quantity
        /// </summary>
        [JsonProperty("available")]
        public decimal? Available { get; set; }
        /// <summary>
        /// Max available to open position
        /// </summary>
        [JsonProperty("maxOpenPosAvailable")]
        public decimal? MaxOpenPosAvailable { get; set; }
        /// <summary>
        /// Max available to transfer out
        /// </summary>
        [JsonProperty("maxTransferOut")]
        public decimal? MaxTransferOut { get; set; }
        /// <summary>
        /// Equity of the currency
        /// </summary>
        [JsonProperty("equity")]
        public decimal? Equity { get; set; }
        /// <summary>
        /// Equity of the currency USD
        /// </summary>
        [JsonProperty("usdtEquity")]
        public decimal? EquityUsdt { get; set; }
    }
}

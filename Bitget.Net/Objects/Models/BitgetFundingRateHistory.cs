using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Historical funding rate
    /// </summary>
    public class BitgetFundingRateHistory
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonProperty("fundingRate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Settle time
        /// </summary>
        [JsonProperty("settleTime")]
        public DateTime SettleTime { get; set; }
    }
}

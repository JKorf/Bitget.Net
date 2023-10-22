using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Next funding time info
    /// </summary>
    public class BitgetFundingTime
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Funding time
        /// </summary>
        [JsonProperty("fundingTime")]
        public DateTime FundingTime { get; set; }
    }
}

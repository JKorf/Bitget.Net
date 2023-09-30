using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        [JsonProperty("settleTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime SettleTime { get; set; }
    }
}

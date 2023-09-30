using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Funding rate
    /// </summary>
    public class BitgetFundingRate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Current funding rate
        /// </summary>
        [JsonProperty("fundingRate")]
        public decimal FundingRate { get; set; }
    }
}

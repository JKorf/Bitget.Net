using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Funding rate
    /// </summary>
    public record BitgetFundingRate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Current funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Funding time
        /// </summary>
        [JsonPropertyName("fundingTime")]
        public DateTime? FundingTime { get; set; }
    }
}

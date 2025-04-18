using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Funding time info
    /// </summary>
    [SerializationModel]
    public record BitgetFundingTime
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonPropertyName("nextFundingTime")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Rate settlement cycle in hours
        /// </summary>
        [JsonPropertyName("ratePeriod"), JsonConverter(typeof(IntConverter))]
        public int? RatePeriod { get; set; }
    }
}

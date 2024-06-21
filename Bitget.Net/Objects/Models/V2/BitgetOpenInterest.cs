using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    internal record BitgetOpenInterestResult
    {
        [JsonPropertyName("openInterestList")]
        public IEnumerable<BitgetOpenInterest> OpenInterest { get; set; } = Array.Empty<BitgetOpenInterest>();
    }

    /// <summary>
    /// Open interest
    /// </summary>
    public record BitgetOpenInterest
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Open interest quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
    }
}

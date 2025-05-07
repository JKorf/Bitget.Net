using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repayment result
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedFlashRepayResult
    {
        /// <summary>
        /// Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Result
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;
    }


}

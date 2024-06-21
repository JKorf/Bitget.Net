using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Multiple orders result
    /// </summary>
    public record BitgetOrderMultipleResult
    {
        /// <summary>
        /// Successful orders
        /// </summary>
        [JsonPropertyName("successList")]
        public IEnumerable<BitgetOrderId> Success { get; set; } = Array.Empty<BitgetOrderId>();
        /// <summary>
        /// Failed orders
        /// </summary>
        [JsonPropertyName("failureList")]
        public IEnumerable<BitgetPlaceFailure> Failed { get; set; } = Array.Empty<BitgetPlaceFailure>();
    }

    /// <summary>
    /// Place order failure info
    /// </summary>
    public record BitgetPlaceFailure
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("errorMsg")]
        public string Error { get; set; } = string.Empty;
    }
}

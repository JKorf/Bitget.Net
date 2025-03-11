using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order id
    /// </summary>
    [SerializationModel]
    public record BitgetOrderId
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
    }

    /// <summary>
    /// Order id
    /// </summary>
    [SerializationModel]
    public record BitgetOrderIdResult: BitgetOrderId
    {
        /// <summary>
        /// Is success
        /// </summary>
        [JsonIgnore]
        public bool Success => Status == "success";

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("success")]
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("msg")]
        public string? ErrorMessage { get; set; }
    }
}

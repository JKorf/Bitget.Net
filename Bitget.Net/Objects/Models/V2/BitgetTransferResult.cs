using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Transfer result
    /// </summary>
    public record BitgetTransferResult
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
    }
}

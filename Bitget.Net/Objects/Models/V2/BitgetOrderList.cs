using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order list
    /// </summary>
    public record BitgetOrderList
    {
        /// <summary>
        /// Next flag
        /// </summary>
        [JsonPropertyName("nextFlag")]
        public bool NextFlag { get; set; }
        /// <summary>
        /// Id for pagination
        /// </summary>
        [JsonPropertyName("idLessThan")]
        public string IdLessThan { get; set; } = string.Empty;
        /// <summary>
        /// Orders
        /// </summary>
        [JsonPropertyName("orderList")]
        public IEnumerable<BitgetTriggerOrder> Orders { get; set; } = Array.Empty<BitgetTriggerOrder>();
    }
}

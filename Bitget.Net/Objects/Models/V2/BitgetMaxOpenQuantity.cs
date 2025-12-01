using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max openable quantity
    /// </summary>
    public record BitgetMaxOpenQuantity
    {
        /// <summary>
        /// Max quantity that can be opened
        /// </summary>
        [JsonPropertyName("maxOpen")]
        public decimal MaxOpenableQuantity { get; set; }
    }
}

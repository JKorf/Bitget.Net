using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// BGB deduct status
    /// </summary>
    public record BitgetBgbDeduct
    {
        /// <summary>
        /// Deduct enabled
        /// </summary>
        [JsonPropertyName("deduct")]
        public bool Enabled { get; set; }
    }
}

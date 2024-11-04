using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max borrowable
    /// </summary>
    public record BitgetCrossMaxBorrowable
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Max borrowable quantity
        /// </summary>
        [JsonPropertyName("maxBorrowableAmount")]
        public decimal MaxBorrowableQuantity { get; set; }
    }


}

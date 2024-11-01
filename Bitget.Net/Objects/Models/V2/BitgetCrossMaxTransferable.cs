using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max transferable
    /// </summary>
    public record BitgetCrossMaxTransferable
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Max transfer out quantity
        /// </summary>
        [JsonPropertyName("maxTransferOutAmount")]
        public decimal MaxTransferOutQuantity { get; set; }
    }


}

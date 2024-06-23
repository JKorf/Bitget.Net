using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Asset valudation
    /// </summary>
    public record BitgetAssetValue
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;
        /// <summary>
        /// Usdt value
        /// </summary>
        [JsonPropertyName("usdtBalance")]
        public decimal UsdtBalance { get; set; }
    }
}

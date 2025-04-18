using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Balance info
    /// </summary>
    [SerializationModel]
    public record BitgetBalance
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available quantity
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Frozen quantity
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal? Frozen { get; set; }
        /// <summary>
        /// Usdt value
        /// </summary>
        [JsonPropertyName("usdtValue")]
        public decimal UsdtValue { get; set; }
    }
}

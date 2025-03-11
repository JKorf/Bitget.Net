using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// BGB deduct status
    /// </summary>
    [SerializationModel]
    public record BitgetBgbDeduct
    {
        /// <summary>
        /// Deduct enabled
        /// </summary>
        [JsonPropertyName("deduct")]
        public bool Enabled { get; set; }
    }
}

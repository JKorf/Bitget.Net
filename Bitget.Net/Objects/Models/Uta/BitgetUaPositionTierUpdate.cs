using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Tier update
    /// </summary>
    public class BitgetUaPositionTierUpdate
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } =string.Empty;
        /// <summary>
        /// ["<c>list</c>"] List
        /// </summary>
        [JsonPropertyName("list")]
        public BitgetUaPositionTier[] List { get; set; } = [];
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order book update
    /// </summary>
    public record BitgetOrderBookUpdate
    {
        /// <summary>
        /// Asks
        /// </summary>
        [JsonPropertyName("asks")]
        public IEnumerable<BitgetOrderBookEntry> Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Bids
        /// </summary>
        [JsonPropertyName("bids")]
        public IEnumerable<BitgetOrderBookEntry> Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Checksum
        /// </summary>
        [JsonPropertyName("checksum")]
        public long Checksum { get; set; }
    }
}

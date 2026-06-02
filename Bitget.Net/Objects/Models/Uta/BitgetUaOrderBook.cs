using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Order book snapshot
/// </summary>
public record BitgetUaOrderBook
{
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// ["<c>a</c>"] Asks
    /// </summary>
    [JsonPropertyName("a")]
    public BitgetOrderBookEntry[] Asks { get; set; } = [];
    /// <summary>
    /// ["<c>b</c>"] Bids
    /// </summary>
    [JsonPropertyName("b")]
    public BitgetOrderBookEntry[] Bids { get; set; } = [];
}


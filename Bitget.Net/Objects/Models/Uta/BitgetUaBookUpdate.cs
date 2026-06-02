using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Order book update
/// </summary>
public record BitgetUaBookUpdate
{
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
    /// <summary>
    /// ["<c>seq</c>"] Sequence
    /// </summary>
    [JsonPropertyName("seq")]
    public long Sequence { get; set; }
    /// <summary>
    /// ["<c>pseq</c>"] Previous sequence
    /// </summary>
    [JsonPropertyName("pseq")]
    public long PreviousSequence { get; set; }
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}


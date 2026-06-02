using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Kline/candlestick
/// </summary>
public record BitgetUaKlineUpdate
{
    /// <summary>
    /// Open timestamp
    /// </summary>
    [JsonPropertyName("start")]
    public DateTime OpenTime { get; set; }
    /// <summary>
    /// Open price
    /// </summary>
    [JsonPropertyName("open")]
    public decimal OpenPrice { get; set; }
    /// <summary>
    /// Highest price
    /// </summary>
    [JsonPropertyName("high")]
    public decimal HighPrice { get; set; }
    /// <summary>
    /// Lowest price
    /// </summary>
    [JsonPropertyName("low")]
    public decimal LowPrice { get; set; }
    /// <summary>
    /// Close price
    /// </summary>
    [JsonPropertyName("close")]
    public decimal ClosePrice { get; set; }
    /// <summary>
    /// Volume in base asset
    /// </summary>
    [JsonPropertyName("volume")]
    public decimal Volume { get; set; }
    /// <summary>
    /// Volume in quote asset
    /// </summary>
    [JsonPropertyName("turnover")]
    public decimal QuoteVolume { get; set; }
}


using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Kline/candlestick
/// </summary>
[JsonConverter(typeof(ArrayConverter<BitgetUaKline>))]
public record BitgetUaKline
{
    /// <summary>
    /// Open timestamp
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }
    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }
    /// <summary>
    /// Highest price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }
    /// <summary>
    /// Lowest price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }
    /// <summary>
    /// Close price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
    /// <summary>
    /// Volume in base asset
    /// </summary>
    [ArrayProperty(5)]
    public decimal Volume { get; set; }
    /// <summary>
    /// Volume in quote asset
    /// </summary>
    [ArrayProperty(6)]
    public decimal QuoteVolume { get; set; }
}


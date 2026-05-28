using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// 
/// </summary>
[JsonConverter(typeof(EnumConverter<KlineInterval>))]
public enum KlineInterval
{
    /// <summary>
    /// ["<c>1m</c>"] 1 minute
    /// </summary>
    [Map("1m")]
    OneMinute = 60,
    /// <summary>
    /// ["<c>3m</c>"] 3 minutes
    /// </summary>
    [Map("3m")]
    ThreeMinutes = 60 * 3,
    /// <summary>
    /// ["<c>5m</c>"] 5 minutes
    /// </summary>
    [Map("5m")]
    FiveMinutes = 60 * 5,
    /// <summary>
    /// ["<c>15m</c>"] 15 minutes
    /// </summary>
    [Map("15m")]
    FifteenMinutes = 60 * 15,
    /// <summary>
    /// ["<c>30m</c>"] 30 minutes
    /// </summary>
    [Map("30m")]
    ThirtyMinutes = 60 * 30,
    /// <summary>
    /// ["<c>1H</c>"] 1 hour
    /// </summary>
    [Map("1H")]
    OneHour = 60 * 60,
    /// <summary>
    /// ["<c>4H</c>"] 4 hours
    /// </summary>
    [Map("4H")]
    FourHours = 60 * 60 * 4,
    /// <summary>
    /// ["<c>6H</c>"] 6 hours
    /// </summary>
    [Map("6H")]
    SixHours = 60 * 60 * 6,
    /// <summary>
    /// ["<c>12H</c>"] 12 hours
    /// </summary>
    [Map("12H")]
    TwelveHours = 60 * 60 * 12,
    /// <summary>
    /// ["<c>1D</c>"] 1 day
    /// </summary>
    [Map("1D")]
    OneDay = 60 * 60 * 24,
}

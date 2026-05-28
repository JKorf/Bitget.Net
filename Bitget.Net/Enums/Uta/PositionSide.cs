using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Position side
/// </summary>
[JsonConverter(typeof(EnumConverter<PositionSide>))]
public enum PositionSide
{
    /// <summary>
    /// ["<c>long</c>"] Long
    /// </summary>
    [Map("long")]
    Long,
    /// <summary>
    /// ["<c>short</c>"] Short
    /// </summary>
    [Map("short")]
    Short,
}

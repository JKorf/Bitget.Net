using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// TP/SL mode
/// </summary>
[JsonConverter(typeof(EnumConverter<TpslMode>))]
public enum TpslMode
{
    /// <summary>
    /// ["<c>full</c>"] Full
    /// </summary>
    [Map("full")]
    Full,
    /// <summary>
    /// ["<c>partial</c>"] Partial take profit / stop loss order
    /// </summary>
    [Map("partial")]
    Partial
}

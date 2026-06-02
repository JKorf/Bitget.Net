using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Kline type
/// </summary>
[JsonConverter(typeof(EnumConverter<KlineType>))]
public enum KlineType
{
    /// <summary>
    /// ["<c>market</c>"] Market
    /// </summary>
    [Map("market")]
    Market,
    /// <summary>
    /// ["<c>mark</c>"] Mark
    /// </summary>
    [Map("mark")]
    Mark,
    /// <summary>
    /// ["<c>index</c>"] Index
    /// </summary>
    [Map("index")]
    Index,
    /// <summary>
    /// ["<c>premium</c>"] Premium
    /// </summary>
    [Map("premium")]
    Premium,
}

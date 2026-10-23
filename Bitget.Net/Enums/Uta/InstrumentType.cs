using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Instrument type
/// </summary>
[JsonConverter(typeof(EnumConverter<InstrumentType>))]
public enum InstrumentType
{
    /// <summary>
    /// ["<c>metal</c>"] Metal
    /// </summary>
    [Map("metal")]
    Metal,
    /// <summary>
    /// ["<c>energy</c>"] Energy
    /// </summary>
    [Map("energy")]
    Energy,
    /// <summary>
    /// ["<c>stock</c>"] Stock
    /// </summary>
    [Map("stock")]
    Stock,
    /// <summary>
    /// ["<c>etf</c>"] ETF
    /// </summary>
    [Map("etf")]
    Etf,
    /// <summary>
    /// ["<c>crypto</c>"] Crypto
    /// </summary>
    [Map("crypto")]
    Crypto,
}

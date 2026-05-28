using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Symbol type
/// </summary>
[JsonConverter(typeof(EnumConverter<SymbolType>))]
public enum SymbolType
{
    /// <summary>
    /// ["<c>crypto</c>"] Crypto
    /// </summary>
    [Map("crypto")]
    Crypto,
    /// <summary>
    /// ["<c>metal</c>"] Metal
    /// </summary>
    [Map("metal")]
    Metal,
    /// <summary>
    /// ["<c>stock</c>"] Stock
    /// </summary>
    [Map("stock")]
    Stock,
    /// <summary>
    /// ["<c>commodity</c>"] Commodity
    /// </summary>
    [Map("commodity")]
    Commodity,
}

using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Account mode
/// </summary>
[JsonConverter(typeof(EnumConverter<AccountMode>))]
public enum AccountMode
{
    /// <summary>
    /// ["<c>hybrid</c>"] Hybrid mode
    /// </summary>
    [Map("hybrid")]
    Hybrid,
    /// <summary>
    /// ["<c>unified</c>"] Unified mode
    /// </summary>
    [Map("unified")]
    Unified,
    /// <summary>
    /// ["<c>upgrading</c>"] Unified upgrading
    /// </summary>
    [Map("upgrading")]
    Upgrading,
    /// <summary>
    /// ["<c>switching</c>"] Class switching
    /// </summary>
    [Map("switching")]
    Switching,
}

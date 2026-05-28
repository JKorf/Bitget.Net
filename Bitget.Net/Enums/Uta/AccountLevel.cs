using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Account level
/// </summary>
[JsonConverter(typeof(EnumConverter<AccountLevel>))]
public enum AccountLevel
{
    /// <summary>
    /// ["<c>advanced</c>"] Advanced mode
    /// </summary>
    [Map("advanced")]
    Advanced,
    /// <summary>
    /// ["<c>basic</c>"] Basic mode
    /// </summary>
    [Map("basic")]
    Basic,
    /// <summary>
    /// ["<c>isolated</c>"] Isolated margin mode
    /// </summary>
    [Map("isolated")]
    IsolatedMargin,
    /// <summary>
    /// ["<c>delta</c>"] Delta-neutral mode
    /// </summary>
    [Map("delta")]
    Delta,
}

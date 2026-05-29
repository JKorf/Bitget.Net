using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums;

/// <summary>
/// Account type
/// </summary>
[JsonConverter(typeof(EnumConverter<UtaAccountType>))]
public enum UtaAccountType
{
    /// <summary>
    /// ["<c>funding</c>"] Funding account
    /// </summary>
    [Map("funding")]
    Funding,
    /// <summary>
    /// ["<c>unified</c>"] Unified account
    /// </summary>
    [Map("unified")]
    Unified,
    /// <summary>
    /// ["<c>otc</c>"] OTC account
    /// </summary>
    [Map("otc")]
    Otc,
}

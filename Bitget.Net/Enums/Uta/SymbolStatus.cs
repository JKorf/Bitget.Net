using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Symbol status
/// </summary>
[JsonConverter(typeof(EnumConverter<InstrumentStatus>))]
public enum InstrumentStatus
{
    /// <summary>
    /// ["<c>online</c>"] Online
    /// </summary>
    [Map("online")]
    Online,
    /// <summary>
    /// ["<c>listed</c>"] Listed but not yet online
    /// </summary>
    [Map("listed")]
    Listed,
    /// <summary>
    /// ["<c>limit_open</c>"] Restrict opening positions
    /// </summary>
    [Map("limit_open")]
    LimitOpen,
    /// <summary>
    /// ["<c>limit_close</c>"] Restrict closing positions
    /// </summary>
    [Map("limit_close")]
    LimitClose,
    /// <summary>
    /// ["<c>offline</c>"] Offline
    /// </summary>
    [Map("offline")]
    Offline,
    /// <summary>
    /// ["<c>restrictedAPI</c>"] API restricted
    /// </summary>
    [Map("restrictedAPI")]
    ApiRestricted,
}

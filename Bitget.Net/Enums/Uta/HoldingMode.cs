using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Holding mode
/// </summary>
[JsonConverter(typeof(EnumConverter<HoldingMode>))]
public enum HoldingMode
{
    /// <summary>
    /// ["<c>one_way_mode</c>"] One way mode
    /// </summary>
    [Map("one_way_mode")]
    OneWayMode,
    /// <summary>
    /// ["<c>hedge_mode</c>"] Hedge mode
    /// </summary>
    [Map("hedge_mode")]
    HedgeMode,
}

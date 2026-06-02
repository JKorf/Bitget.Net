using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Strategy type
/// </summary>
[JsonConverter(typeof(EnumConverter<StrategyType>))]
public enum StrategyType
{
    /// <summary>
    /// ["<c>tpsl</c>"] Take profit / Stop loss order
    /// </summary>
    [Map("tpsl")]
    TpSl,
    /// <summary>
    /// ["<c>trigger</c>"] Trigger order
    /// </summary>
    [Map("trigger")]
    Trigger
}

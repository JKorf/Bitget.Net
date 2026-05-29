using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Trigger price type
/// </summary>
[JsonConverter(typeof(EnumConverter<PriceTriggerType>))]
public enum PriceTriggerType
{
    /// <summary>
    /// ["<c>market</c>"] Market price
    /// </summary>
    [Map("market")]
    Market,
    /// <summary>
    /// ["<c>mark</c>"] Mark price
    /// </summary>
    [Map("mark")]
    Mark,
}

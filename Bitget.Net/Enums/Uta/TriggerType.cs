using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Trigger type
/// </summary>
[JsonConverter(typeof(EnumConverter<TriggerType>))]
public enum TriggerType
{
    /// <summary>
    /// ["<c>takeProfit</c>"] Take profit
    /// </summary>
    [Map("takeProfit")]
    TakeProfit,
    /// <summary>
    /// ["<c>stopLoss</c>"] Stop loss
    /// </summary>
    [Map("stopLoss")]
    StopLoss
}

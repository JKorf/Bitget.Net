using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Delivery period
/// </summary>
[JsonConverter(typeof(EnumConverter<DeliveryPeriod>))]
public enum DeliveryPeriod
{
    /// <summary>
    /// ["<c>this_quarter</c>"] This quarter
    /// </summary>
    [Map("this_quarter")]
    ThisQuarter,
    /// <summary>
    /// ["<c>next_quarter</c>"] Next quarter
    /// </summary>
    [Map("next_quarter")]
    NextQuarter,
}

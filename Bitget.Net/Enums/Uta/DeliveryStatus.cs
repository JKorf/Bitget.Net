using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Delivery status
/// </summary>
[JsonConverter(typeof(EnumConverter<DeliveryStatus>))]
public enum DeliveryStatus
{
    /// <summary>
    /// ["<c>delivery_config_period</c>"] New pair configuration
    /// </summary>
    [Map("delivery_config_period")]
    New,
    /// <summary>
    /// ["<c>delivery_normal</c>"] Trading
    /// </summary>
    [Map("delivery_normal")]
    Trading,
    /// <summary>
    /// ["<c>delivery_before</c>"] 10 minutes before delivery, no new orders
    /// </summary>
    [Map("delivery_before")]
    CloseToDelivery,
    /// <summary>
    /// ["<c>delivery_period</c>"] In delivery
    /// </summary>
    [Map("delivery_period")]
    Delivering,
}

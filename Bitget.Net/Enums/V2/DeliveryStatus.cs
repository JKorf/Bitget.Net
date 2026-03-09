using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Delivery status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DeliveryStatus>))]
    public enum DeliveryStatus
    {
        /// <summary>
        /// ["<c>delivery_normal</c>"] Trading normally
        /// </summary>
        [Map("delivery_normal")]
        Normal,
        /// <summary>
        /// ["<c>delivery_before</c>"] 10 minutes before delivery, opening positions are prohibited
        /// </summary>
        [Map("delivery_before")]
        DeliveryBefore,
        /// <summary>
        /// ["<c>delivery_period</c>"] Delivery, opening, closing, and canceling orders are prohibited
        /// </summary>
        [Map("delivery_period")]
        DeliveryPeriod
    }
}

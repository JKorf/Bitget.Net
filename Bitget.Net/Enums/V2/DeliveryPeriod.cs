using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Delivery period
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DeliveryPeriod>))]
    public enum DeliveryPeriod
    {
        /// <summary>
        /// This quarter
        /// </summary>
        [Map("this_quarter")]
        ThisQuarter,
        /// <summary>
        /// Next quarter
        /// </summary>
        [Map("next_quarter")]
        NextQuarter
    }
}

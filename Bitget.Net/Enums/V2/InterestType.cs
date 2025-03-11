using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Interest type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<InterestType>))]
    public enum InterestType
    {
        /// <summary>
        /// Interest on initial borrowing
        /// </summary>
        [Map("first")]
        First,
        /// <summary>
        /// Scheduled
        /// </summary>
        [Map("scheduled")]
        Scheduled
    }
}

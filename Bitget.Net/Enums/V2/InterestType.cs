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
        /// ["<c>first</c>"] Interest on initial borrowing
        /// </summary>
        [Map("first")]
        First,
        /// <summary>
        /// ["<c>scheduled</c>"] Scheduled
        /// </summary>
        [Map("scheduled")]
        Scheduled
    }
}

using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Role
    /// </summary>
    [JsonConverter(typeof(EnumConverter<Role>))]
    public enum Role
    {
        /// <summary>
        /// Taker
        /// </summary>
        [Map("taker", "T")]
        Taker,
        /// <summary>
        /// Maker
        /// </summary>
        [Map("maker", "M")]
        Maker
    }
}

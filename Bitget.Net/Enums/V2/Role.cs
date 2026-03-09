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
        /// ["<c>taker</c>"] Taker
        /// </summary>
        [Map("taker", "T")]
        Taker,
        /// <summary>
        /// ["<c>maker</c>"] Maker
        /// </summary>
        [Map("maker", "M")]
        Maker
    }
}

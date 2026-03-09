using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Business type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetBusinessType>))]
    public enum BitgetBusinessType
    {
        /// <summary>
        /// ["<c>mix</c>"] Mix
        /// </summary>
        [Map("mix")]
        Mix,
        /// <summary>
        /// ["<c>spot</c>"] Spot
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// ["<c>margin</c>"] Spot margin
        /// </summary>
        [Map("margin")]
        SpotMargin
    }
}

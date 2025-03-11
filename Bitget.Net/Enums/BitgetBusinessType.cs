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
        /// Mix
        /// </summary>
        [Map("mix")]
        Mix,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// Spot margin
        /// </summary>
        [Map("margin")]
        SpotMargin
    }
}

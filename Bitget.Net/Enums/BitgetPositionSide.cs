using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Position side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetPositionSide>))]
    public enum BitgetPositionSide
    {
        /// <summary>
        /// Long position
        /// </summary>
        [Map("long")]
        Long,
        /// <summary>
        /// Short position
        /// </summary>
        [Map("short")]
        Short,
        /// <summary>
        /// Net
        /// </summary>
        [Map("net")]
        Net
    }
}

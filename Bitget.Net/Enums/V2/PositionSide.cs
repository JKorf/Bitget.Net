using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Position side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PositionSide>))]
    public enum PositionSide
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
        /// One way position
        /// </summary>
        [Map("net")]
        Oneway
    }
}

using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Position mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PositionMode>))]
    public enum PositionMode
    {
        /// <summary>
        /// One way mode
        /// </summary>
        [Map("one_way_mode")]
        OneWay,
        /// <summary>
        /// Hedge mode
        /// </summary>
        [Map("hedge_mode")]
        Hedge
    }
}

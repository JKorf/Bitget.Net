using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Status of a symbol
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetSymbolStatus>))]
    public enum BitgetSymbolStatus
    {
        /// <summary>
        /// Offline
        /// </summary>
        [Map("offline")]
        Offline,
        /// <summary>
        /// Gray
        /// </summary>
        [Map("gray")]
        Gray,
        /// <summary>
        /// Online
        /// </summary>
        [Map("online")]
        Online,

        /// <summary>
        /// Halt
        /// </summary>
        [Map("halt")]
        Halt
    }
}

using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SymbolStatus>))]
    public enum SymbolStatus
    {
        /// <summary>
        /// Maintenance/offline
        /// </summary>
        [Map("offline")]
        Maintenance,
        /// <summary>
        /// Gray scale
        /// </summary>
        [Map("gray")]
        Gray,
        /// <summary>
        /// Halted
        /// </summary>
        [Map("halt")]
        Halt,
        /// <summary>
        /// Online
        /// </summary>
        [Map("online")]
        Online
    }
}

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
        /// ["<c>offline</c>"] Maintenance/offline
        /// </summary>
        [Map("offline")]
        Maintenance,
        /// <summary>
        /// ["<c>gray</c>"] Gray scale
        /// </summary>
        [Map("gray")]
        Gray,
        /// <summary>
        /// ["<c>halt</c>"] Halted
        /// </summary>
        [Map("halt")]
        Halt,
        /// <summary>
        /// ["<c>online</c>"] Online
        /// </summary>
        [Map("online")]
        Online
    }
}

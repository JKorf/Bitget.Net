using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetFuturesSymbolStatus>))]
    public enum BitgetFuturesSymbolStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Maintenance
        /// </summary>
        [Map("maintain")]
        Maintainance,
        /// <summary>
        /// Offline
        /// </summary>
        [Map("off")]
        Offline,
        /// <summary>
        /// Restricted API
        /// </summary>
        [Map("restrictedAPI")]
        Restricted,
        /// <summary>
        /// No new openings
        /// </summary>
        [Map("limit_open")]
        NoNewOrders
    }
}

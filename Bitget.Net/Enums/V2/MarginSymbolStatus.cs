using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MarginSymbolStatus>))]
    public enum MarginSymbolStatus
    {
        /// <summary>
        /// Tradable
        /// </summary>
        [Map("1")]
        Tradable,
        /// <summary>
        /// Under maintenance
        /// </summary>
        [Map("2")]
        Maintenance
    }
}

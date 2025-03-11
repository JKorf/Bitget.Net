using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetFuturesSymbolType>))]
    public enum BitgetFuturesSymbolType
    {
        /// <summary>
        /// Perpetual contract
        /// </summary>
        [Map("perpetual", "1")]
        Perpetual,
        /// <summary>
        /// Delivery contract
        /// </summary>
        [Map("delivery", "2")]
        Delivery
    }
}

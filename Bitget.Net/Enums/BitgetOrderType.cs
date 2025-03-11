using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetOrderType>))]
    public enum BitgetOrderType
    {
        /// <summary>
        /// Limit
        /// </summary>
        [Map("limit")]
        Limit,
        /// <summary>
        /// Market
        /// </summary>
        [Map("market")]
        Market
    }
}

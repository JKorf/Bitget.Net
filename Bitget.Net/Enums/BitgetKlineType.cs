using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetKlineType>))]
    public enum BitgetKlineType
    {
        /// <summary>
        /// Market price
        /// </summary>
        [Map("market")]
        Market,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("amrk")]
        Mark,
        /// <summary>
        /// Index price
        /// </summary>
        [Map("market")]
        Index
    }
}

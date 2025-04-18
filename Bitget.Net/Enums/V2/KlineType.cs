using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Kline type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<KlineType>))]
    public enum KlineType
    {
        /// <summary>
        /// Market price
        /// </summary>
        [Map("MARKET")]
        Market,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("MARK")]
        Mark,
        /// <summary>
        /// Index price
        /// </summary>
        [Map("INDEX")]
        Index
    }
}

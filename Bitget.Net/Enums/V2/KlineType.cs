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
        /// ["<c>MARKET</c>"] Market price
        /// </summary>
        [Map("MARKET")]
        Market,
        /// <summary>
        /// ["<c>MARK</c>"] Mark price
        /// </summary>
        [Map("MARK")]
        Mark,
        /// <summary>
        /// ["<c>INDEX</c>"] Index price
        /// </summary>
        [Map("INDEX")]
        Index
    }
}

using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Trigger type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetTriggerType>))]
    public enum BitgetTriggerType
    {
        /// <summary>
        /// Fill price
        /// </summary>
        [Map("fill_price", "last")]
        FillPrice,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("market_price", "mark")]
        MarkPrice
    }
}

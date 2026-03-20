using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order price type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerPriceType>))]
    public enum TriggerPriceType
    {
        /// <summary>
        /// ["<c>fill_price</c>"] Last fill price
        /// </summary>
        [Map("fill_price")]
        LastPrice,
        /// <summary>
        /// ["<c>mark_price</c>"] Mark price
        /// </summary>
        [Map("mark_price")]
        MarkPrice
    }
}

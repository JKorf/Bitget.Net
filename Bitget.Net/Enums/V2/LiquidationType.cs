using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Liquidation type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LiquidationType>))]
    public enum LiquidationType
    {
        /// <summary>
        /// ["<c>place_order</c>"] Place order
        /// </summary>
        [Map("place_order")]
        PlaceOrder,
        /// <summary>
        /// ["<c>swap</c>"] Swap
        /// </summary>
        [Map("swap")]
        Swap
    }
}

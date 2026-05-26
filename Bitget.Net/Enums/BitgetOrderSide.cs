using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetOrderSide>))]
    public enum BitgetOrderSide
    {
        /// <summary>
        /// ["<c>buy</c>"] Buy
        /// </summary>
        [Map("buy", "Buy")]
        Buy,
        /// <summary>
        /// ["<c>sell</c>"] Sell
        /// </summary>
        [Map("sell", "Sell")]
        Sell
    }
}

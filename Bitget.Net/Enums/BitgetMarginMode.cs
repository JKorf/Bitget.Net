using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Margin mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetMarginMode>))]
    public enum BitgetMarginMode
    {
        /// <summary>
        /// Isolated margin
        /// </summary>
        [Map("fixed")]
        IsolatedMargin,
        /// <summary>
        /// Cross margin
        /// </summary>
        [Map("crossed", "cross")]
        CrossMargin
    }
}

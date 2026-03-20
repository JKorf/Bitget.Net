using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Margin mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MarginMode>))]
    public enum MarginMode
    {
        /// <summary>
        /// ["<c>crossed</c>"] Cross margin
        /// </summary>
        [Map("crossed", "cross")]
        CrossMargin,
        /// <summary>
        /// ["<c>isolated</c>"] Isolated margin
        /// </summary>
        [Map("isolated", "fixed")]
        IsolatedMargin
    }
}

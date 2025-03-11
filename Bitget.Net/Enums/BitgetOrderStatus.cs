using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetOrderStatus>))]
    public enum BitgetOrderStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// New
        /// </summary>
        [Map("new")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("partial_fill", "partial-fill", "partially_filled")]
        PartiallyFilled,
        /// <summary>
        /// Filled
        /// </summary>
        [Map("full_fill", "full-fill", "filled")]
        Filled,
        /// <summary>
        /// Cancelled
        /// </summary>
        [Map("cancelled", "canceled")]
        Cancelled
    }
}

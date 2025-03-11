using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OrderStatus>))]
    public enum OrderStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// Pending match
        /// </summary>
        [Map("live")]
        Live,
        /// <summary>
        /// Unfilled, waiting for match
        /// </summary>
        [Map("new")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("partially_filled")]
        PartiallyFilled,
        /// <summary>
        /// Filled
        /// </summary>
        [Map("filled")]
        Filled,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled,
        /// <summary>
        /// Reject
        /// </summary>
        [Map("reject")]
        Rejected
    }
}

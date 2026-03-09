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
        /// ["<c>init</c>"] Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// ["<c>live</c>"] Pending match
        /// </summary>
        [Map("live")]
        Live,
        /// <summary>
        /// ["<c>new</c>"] Unfilled, waiting for match
        /// </summary>
        [Map("new")]
        New,
        /// <summary>
        /// ["<c>partially_filled</c>"] Partially filled
        /// </summary>
        [Map("partially_filled")]
        PartiallyFilled,
        /// <summary>
        /// ["<c>filled</c>"] Filled
        /// </summary>
        [Map("filled")]
        Filled,
        /// <summary>
        /// ["<c>cancelled</c>"] Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled,
        /// <summary>
        /// ["<c>reject</c>"] Reject
        /// </summary>
        [Map("reject")]
        Rejected
    }
}

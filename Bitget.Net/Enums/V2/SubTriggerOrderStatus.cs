using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Tirgger sub order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SubTriggerOrderStatus>))]
    public enum SubTriggerOrderStatus
    {
        /// <summary>
        /// ["<c>success</c>"] Trigger success
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// ["<c>fail</c>"] Trigger failed
        /// </summary>
        [Map("fail")]
        Fail,
        /// <summary>
        /// ["<c>cancelled</c>"] Cancelled
        /// </summary>
        [Map("cancelled")]
        Cancelled,
        /// <summary>
        /// ["<c>in_progress</c>"] Placing order
        /// </summary>
        [Map("in_progress")]
        InProgress,
        /// <summary>
        /// ["<c>in_progress_tracking</c>"] Tracking in progress
        /// </summary>
        [Map("in_progress_tracking")]
        InProgressTracking
    }
}

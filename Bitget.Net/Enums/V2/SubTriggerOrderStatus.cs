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
        /// Trigger success
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// Trigger failed
        /// </summary>
        [Map("fail")]
        Fail,
        /// <summary>
        /// Cancelled
        /// </summary>
        [Map("cancelled")]
        Cancelled,
        /// <summary>
        /// Placing order
        /// </summary>
        [Map("in_progress")]
        InProgress,
        /// <summary>
        /// Tracking in progress
        /// </summary>
        [Map("in_progress_tracking")]
        InProgressTracking
    }
}

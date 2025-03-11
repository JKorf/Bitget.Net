using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetPlanOrderStatus>))]
    public enum BitgetPlanOrderStatus
    {
        /// <summary>
        /// Not triggered
        /// </summary>
        [Map("not_trigger")]
        NotTriggered,
        /// <summary>
        /// Triggered
        /// </summary>
        [Map("triggered")]
        Triggered,
        /// <summary>
        /// Failed trigger
        /// </summary>
        [Map("fail_trigger")]
        FailTrigger,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancel")]
        Cancel
    }
}

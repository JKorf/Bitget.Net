using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerOrderStatus>))]
    public enum TriggerOrderStatus
    {
        /// <summary>
        /// Not triggered yet
        /// </summary>
        [Map("live", "not_trigger")]
        Live,
        /// <summary>
        /// Order executing
        /// </summary>
        [Map("executing")]
        Executing,
        /// <summary>
        /// Order executed
        /// </summary>
        [Map("executed")]
        Executed,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled,
        /// <summary>
        /// Failed to execute
        /// </summary>
        [Map("fail_execute")]
        FailedExecute
    }
}

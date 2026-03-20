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
        /// ["<c>live</c>"] Not triggered yet
        /// </summary>
        [Map("live", "not_trigger")]
        Live,
        /// <summary>
        /// ["<c>executing</c>"] Order executing
        /// </summary>
        [Map("executing")]
        Executing,
        /// <summary>
        /// ["<c>executed</c>"] Order executed
        /// </summary>
        [Map("executed")]
        Executed,
        /// <summary>
        /// ["<c>cancelled</c>"] Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled,
        /// <summary>
        /// ["<c>fail_execute</c>"] Failed to execute
        /// </summary>
        [Map("fail_execute")]
        FailedExecute
    }
}

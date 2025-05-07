using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Closed plan status filter
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ClosedPlanFilter>))]
    public enum ClosedPlanFilter
    {
        /// <summary>
        /// Executed
        /// </summary>
        [Map("executed")]
        Executed,
        /// <summary>
        /// Trigger failed
        /// </summary>
        [Map("fail_trigger")]
        Failed,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled
    }
}

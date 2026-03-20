using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerPlanType>))]
    public enum TriggerPlanType
    {
        /// <summary>
        /// ["<c>normal_plan</c>"] Normal trigger order
        /// </summary>
        [Map("normal_plan")]
        Normal,
        /// <summary>
        /// ["<c>track_plan</c>"] Trailing stop
        /// </summary>
        [Map("track_plan")]
        TrailingStop
    }
}

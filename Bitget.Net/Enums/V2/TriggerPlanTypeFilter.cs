using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerPlanTypeFilter>))]
    public enum TriggerPlanTypeFilter
    {
        /// <summary>
        /// Trigger order
        /// </summary>
        [Map("normal_plan")]
        Trigger,
        /// <summary>
        /// Trailing stop order
        /// </summary>
        [Map("track_plan")]
        TrailingStop,
        /// <summary>
        /// Take profit and stop loss orders
        /// </summary>
        [Map("profit_loss")]
        ProfitLoss
    }
}

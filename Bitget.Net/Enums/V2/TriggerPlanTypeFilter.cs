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
        /// ["<c>normal_plan</c>"] Trigger order
        /// </summary>
        [Map("normal_plan")]
        Trigger,
        /// <summary>
        /// ["<c>track_plan</c>"] Trailing stop order
        /// </summary>
        [Map("track_plan")]
        TrailingStop,
        /// <summary>
        /// ["<c>profit_loss</c>"] Take profit and stop loss orders
        /// </summary>
        [Map("profit_loss")]
        ProfitLoss
    }
}

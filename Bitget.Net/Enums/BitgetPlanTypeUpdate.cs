using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan type 
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetPlanOrderEvent>))]
    public enum BitgetPlanOrderEvent
    {
        /// <summary>
        /// Whenever a plan order is created/cancelled/modified/triggered
        /// </summary>
        [Map("pl")]
        PlanOrderEvent,
        /// <summary>
        /// When a take profit order(partial position) is created/cancelled/modified/triggered
        /// </summary>
        [Map("tp")]
        TakeProfitEvent,
        /// <summary>
        /// When a stop loss order(partial position) is created/cancelled/modified/triggered
        /// </summary>
        [Map("sl")]
        StopLossEvent,
        /// <summary>
        /// When a position take profit order(whole position) is created/cancelled/modified/triggered
        /// </summary>
        [Map("ptp")]
        PositionTakeProfitEvent,
        /// <summary>
        /// When a position stop loss order(whole position) is created/cancelled/modified/triggered
        /// </summary>
        [Map("psl")]
        PositionStopLossEvent
    }
}

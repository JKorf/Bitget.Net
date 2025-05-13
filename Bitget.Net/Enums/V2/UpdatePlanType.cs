using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Update plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<UpdatePlanType>))]
    public enum UpdatePlanType
    {
        /// <summary>
        /// Trigger order
        /// </summary>
        [Map("pl")]
        TriggerOrder,
        /// <summary>
        /// Partial take profit
        /// </summary>
        [Map("tp")]
        PartialTakeProfit,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        [Map("sl")]
        PartialStopLoss,
        /// <summary>
        /// Position take profit
        /// </summary>
        [Map("ptp")]
        PositionTakeProfit,
        /// <summary>
        /// Position stop loss 
        /// </summary>
        [Map("psl")]
        PositionStopLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("track")]
        TrailingStop,
        /// <summary>
        /// Trailing TP/SL
        /// </summary>
        [Map("mtpsl")]
        TrailingTpSl
    }
}

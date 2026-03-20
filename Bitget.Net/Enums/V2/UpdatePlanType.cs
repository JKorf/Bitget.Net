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
        /// ["<c>pl</c>"] Trigger order
        /// </summary>
        [Map("pl")]
        TriggerOrder,
        /// <summary>
        /// ["<c>tp</c>"] Partial take profit
        /// </summary>
        [Map("tp")]
        PartialTakeProfit,
        /// <summary>
        /// ["<c>sl</c>"] Partial stop loss
        /// </summary>
        [Map("sl")]
        PartialStopLoss,
        /// <summary>
        /// ["<c>ptp</c>"] Position take profit
        /// </summary>
        [Map("ptp")]
        PositionTakeProfit,
        /// <summary>
        /// ["<c>psl</c>"] Position stop loss 
        /// </summary>
        [Map("psl")]
        PositionStopLoss,
        /// <summary>
        /// ["<c>track</c>"] Trailing stop
        /// </summary>
        [Map("track")]
        TrailingStop,
        /// <summary>
        /// ["<c>mtpsl</c>"] Trailing TP/SL
        /// </summary>
        [Map("mtpsl")]
        TrailingTpSl
    }
}

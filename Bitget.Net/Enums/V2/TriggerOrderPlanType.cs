using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerOrderPlanType>))]
    public enum TriggerOrderPlanType
    {
        /// <summary>
        /// Normal trigger order
        /// </summary>
        [Map("normal_plan")]
        Normal,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("track_plan", "moving_plan")]
        TrailingStop,
        /// <summary>
        /// Position profit
        /// </summary>
        [Map("pos_profit")]
        PosProfit,
        /// <summary>
        /// Position loss
        /// </summary>
        [Map("pos_loss")]
        PosLoss,
        /// <summary>
        /// Partial profit
        /// </summary>
        [Map("profit_plan")]
        PartialProfit,
        /// <summary>
        /// Partial loss
        /// </summary>
        [Map("loss_plan")]
        PartialLoss
    }
}

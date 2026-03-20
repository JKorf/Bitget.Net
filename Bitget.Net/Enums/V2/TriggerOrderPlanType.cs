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
        /// ["<c>normal_plan</c>"] Normal trigger order
        /// </summary>
        [Map("normal_plan")]
        Normal,
        /// <summary>
        /// ["<c>track_plan</c>"] Trailing stop
        /// </summary>
        [Map("track_plan", "moving_plan")]
        TrailingStop,
        /// <summary>
        /// ["<c>pos_profit</c>"] Position profit
        /// </summary>
        [Map("pos_profit")]
        PosProfit,
        /// <summary>
        /// ["<c>pos_loss</c>"] Position loss
        /// </summary>
        [Map("pos_loss")]
        PosLoss,
        /// <summary>
        /// ["<c>profit_plan</c>"] Partial profit
        /// </summary>
        [Map("profit_plan")]
        PartialProfit,
        /// <summary>
        /// ["<c>loss_plan</c>"] Partial loss
        /// </summary>
        [Map("loss_plan")]
        PartialLoss
    }
}

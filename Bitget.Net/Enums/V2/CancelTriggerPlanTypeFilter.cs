using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<CancelTriggerPlanTypeFilter>))]
    public enum CancelTriggerPlanTypeFilter
    {
        /// <summary>
        /// ["<c>normal_plan</c>"] Trigger order
        /// </summary>
        [Map("normal_plan")]
        Trigger,
        /// <summary>
        /// ["<c>profit_plan</c>"] Take profit
        /// </summary>
        [Map("profit_plan")]
        TakeProfit,
        /// <summary>
        /// ["<c>loss_plan</c>"] Stop loss
        /// </summary>
        [Map("loss_plan")]
        StopLoss,
        /// <summary>
        /// ["<c>pos_profit</c>"] Position take profit
        /// </summary>
        [Map("pos_profit")]
        PositionTakeProfit,
        /// <summary>
        /// ["<c>pos_loss</c>"] Position stop loss
        /// </summary>
        [Map("pos_loss")]
        PositionStopLoss,
        /// <summary>
        /// ["<c>moving_plan</c>"] Trailing order
        /// </summary>
        [Map("moving_plan")]
        Trailing
    }
}

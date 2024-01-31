using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan type
    /// </summary>
    public enum BitgetPlanType
    {
        /// <summary>
        /// Profit plan
        /// </summary>
        [Map("profit_plan")]
        Profit,
        /// <summary>
        /// Loss plan
        /// </summary>
        [Map("loss_plan")]
        Loss,
        /// <summary>
        /// Moving plan
        /// </summary>
        [Map("moving_plan")]
        Moving,
        /// <summary>
        /// Position profit
        /// </summary>
        [Map("pos_profit")]
        PositionProfit,
        /// <summary>
        /// Position loss
        /// </summary>
        [Map("pos_loss")]
        PositionLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("track_plan")]
        TrailingStop,
        /// <summary>
        /// Plan order
        /// </summary>
        [Map("normal_plan")]
        NormalPlan,
    }
}

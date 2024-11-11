using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    public enum CancelTriggerPlanTypeFilter
    {
        /// <summary>
        /// Trigger order
        /// </summary>
        [Map("normal_plan")]
        Trigger,
        /// <summary>
        /// Take profit
        /// </summary>
        [Map("profit_plan")]
        TakeProfit,
        /// <summary>
        /// Stop loss
        /// </summary>
        [Map("loss_plan")]
        StopLoss,
        /// <summary>
        /// Position take profit
        /// </summary>
        [Map("pos_profit")]
        PositionTakeProfit,
        /// <summary>
        /// Position stop loss
        /// </summary>
        [Map("pos_loss")]
        PositionStopLoss,
        /// <summary>
        /// Trailing order
        /// </summary>
        [Map("moving_plan")]
        Trailing
    }
}

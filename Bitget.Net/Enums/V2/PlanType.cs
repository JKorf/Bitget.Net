using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Plan type
    /// </summary>
    public enum PlanType
    {
        /// <summary>
        /// Trigger order
        /// </summary>
        [Map("pl")]
        TriggerOrder,
        /// <summary>
        /// Take profit
        /// </summary>
        [Map("profit_plan", "tp")]
        TakeProfit,
        /// <summary>
        /// Stop loss
        /// </summary>
        [Map("loss_plan", "sl")]
        StopLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("moving_plan", "track")]
        TailingStop,
        /// <summary>
        /// Trailing TP/SL
        /// </summary>
        [Map("mtpsl")]
        TailingTpSl,
        /// <summary>
        /// Position take profit
        /// </summary>
        [Map("pos_profit", "ptp")]
        PositionTakeProfit,
        /// <summary>
        /// Position stop loss
        /// </summary>
        [Map("pos_loss", "psl")]
        PositionStopLoss
    }
}

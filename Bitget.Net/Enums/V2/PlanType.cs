﻿using CryptoExchange.Net.Attributes;
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
        /// Trailing stop
        /// </summary>
        [Map("moving_plan")]
        TailingStop,
        /// <summary>
        /// Position take profit
        /// </summary>
        [Map("pos_profit")]
        PositionTakeProfit,
        /// <summary>
        /// Position stop loss
        /// </summary>
        [Map("pos_loss")]
        PositionStopLoss
    }
}

using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order plan type
    /// </summary>
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
        [Map("track_plan")]
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
        PosLoss
    }
}

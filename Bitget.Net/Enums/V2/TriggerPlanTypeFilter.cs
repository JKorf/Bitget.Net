using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    public enum TriggerPlanTypeFilter
    {
        /// <summary>
        /// Trigger order
        /// </summary>
        [Map("normal_plan")]
        Trigger,
        /// <summary>
        /// Trailing stop order
        /// </summary>
        [Map("track_plan")]
        TrailingStop,
        /// <summary>
        /// Take profit and stop loss orders
        /// </summary>
        [Map("profit_loss")]
        ProfitLoss
    }
}

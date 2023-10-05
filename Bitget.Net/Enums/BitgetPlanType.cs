using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

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
        Moving
    }
}

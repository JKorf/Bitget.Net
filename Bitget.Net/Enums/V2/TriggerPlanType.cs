using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    public enum TriggerPlanType
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
        TrailingStop
    }
}

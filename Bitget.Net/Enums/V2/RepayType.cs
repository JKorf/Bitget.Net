using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Repay type
    /// </summary>
    public enum RepayType
    {
        /// <summary>
        /// Auto repayment
        /// </summary>
        [Map("auto_repay")]
        AutoRepay,
        /// <summary>
        /// Manual repayment
        /// </summary>
        [Map("manual_repay")]
        ManualRepay,
        /// <summary>
        /// Liquidation repayment
        /// </summary>
        [Map("liq_repay")]
        LiquidationRepay,
        /// <summary>
        /// Forced repayment
        /// </summary>
        [Map("force_repay")]
        ForcedRepay,
    }
}

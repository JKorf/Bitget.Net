using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Loan type
    /// </summary>
    public enum LoanType
    {
        /// <summary>
        /// Normal order
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Auto borrow
        /// </summary>
        [Map("autoLoan")]
        AutoLoan,
        /// <summary>
        /// Auto repay
        /// </summary>
        [Map("autoRepay")]
        AutoRepay,
        /// <summary>
        /// Auto borrow and repay
        /// </summary>
        [Map("autoLoanAndRepay")]
        AutoLoanAndRepay
    }
}

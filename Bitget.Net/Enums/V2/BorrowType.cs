using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Type of borrowing
    /// </summary>
    public enum BorrowType
    {
        /// <summary>
        /// Auto loan
        /// </summary>
        [Map("auto_loan")]
        AutoLoan,
        /// <summary>
        /// Manual loan
        /// </summary>
        [Map("manual_loan")]
        ManualLoan
    }
}

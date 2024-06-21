using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Transfer status 
    /// </summary>
    public enum TransferStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Successful", "success")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Failed", "fail")]
        Failed,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("Processing", "pending")]
        Processing
    }
}

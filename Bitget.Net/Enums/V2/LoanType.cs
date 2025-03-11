using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Loan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LoanType>))]
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

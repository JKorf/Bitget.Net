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
        /// ["<c>normal</c>"] Normal order
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// ["<c>autoLoan</c>"] Auto borrow
        /// </summary>
        [Map("autoLoan")]
        AutoLoan,
        /// <summary>
        /// ["<c>autoRepay</c>"] Auto repay
        /// </summary>
        [Map("autoRepay")]
        AutoRepay,
        /// <summary>
        /// ["<c>autoLoanAndRepay</c>"] Auto borrow and repay
        /// </summary>
        [Map("autoLoanAndRepay")]
        AutoLoanAndRepay
    }
}

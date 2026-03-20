using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Type of borrowing
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BorrowType>))]
    public enum BorrowType
    {
        /// <summary>
        /// ["<c>auto_loan</c>"] Auto loan
        /// </summary>
        [Map("auto_loan")]
        AutoLoan,
        /// <summary>
        /// ["<c>manual_loan</c>"] Manual loan
        /// </summary>
        [Map("manual_loan")]
        ManualLoan
    }
}

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

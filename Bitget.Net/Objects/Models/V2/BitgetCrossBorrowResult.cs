using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Borrow result
    /// </summary>
    [SerializationModel]
    public record BitgetCrossBorrowResult
    {
        /// <summary>
        /// ["<c>loanId</c>"] Loan id
        /// </summary>
        [JsonPropertyName("loanId")]
        public string LoanId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>borrowAmount</c>"] Borrow quantity
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowQuantity { get; set; }
    }


}

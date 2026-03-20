using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Borrow history
    /// </summary>
    [SerializationModel]
    public record BitgetCrossBorrowHistory
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
        /// <summary>
        /// ["<c>borrowType</c>"] Borrow type
        /// </summary>
        [JsonPropertyName("borrowType")]
        public BorrowType BorrowType { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

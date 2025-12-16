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
        /// Loan id
        /// </summary>
        [JsonPropertyName("loanId")]
        public string LoanId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Borrow quantity
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal BorrowQuantity { get; set; }
        /// <summary>
        /// Borrow type
        /// </summary>
        [JsonPropertyName("borrowType")]
        public BorrowType BorrowType { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

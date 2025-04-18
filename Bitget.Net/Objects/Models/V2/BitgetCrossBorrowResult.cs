using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
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
    }


}

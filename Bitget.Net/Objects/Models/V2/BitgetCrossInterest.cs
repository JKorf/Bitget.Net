using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Interest
    /// </summary>
    [SerializationModel]
    public record BitgetCrossInterest
    {
        /// <summary>
        /// ["<c>interestId</c>"] Interest id
        /// </summary>
        [JsonPropertyName("interestId")]
        public string InterestId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>loanCoin</c>"] Loan asset
        /// </summary>
        [JsonPropertyName("loanCoin")]
        public string LoanAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>interestCoin</c>"] Interest asset
        /// </summary>
        [JsonPropertyName("interestCoin")]
        public string InterestAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>dailyInterestRate</c>"] Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>interestAmount</c>"] Interest quantity
        /// </summary>
        [JsonPropertyName("interestAmount")]
        public decimal InterestQuantity { get; set; }
        /// <summary>
        /// ["<c>interstType</c>"] Interest type
        /// </summary>
        [JsonPropertyName("interstType")]
        public InterestType InterestType { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
    }


}

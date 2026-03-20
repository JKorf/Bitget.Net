using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Interest rate info
    /// </summary>
    public record BitgetInterestRate
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>dailyInterestRate</c>"] Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>annualInterestRate</c>"] Annual interest rate
        /// </summary>
        [JsonPropertyName("annualInterestRate")]
        public decimal AnnualInterestRate { get; set; }
        /// <summary>
        /// ["<c>updatedTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("updatedTime")]
        public DateTime UpdateTime { get; set; }
    }
}

using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Interest limit
    /// </summary>
    [SerializationModel]
    public record BitgetCrossInterestLimit
    {
        /// <summary>
        /// Transferable
        /// </summary>
        [JsonPropertyName("transferable")]
        public bool Transferable { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Borrowable
        /// </summary>
        [JsonPropertyName("borrowable")]
        public bool Borrowable { get; set; }
        /// <summary>
        /// Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// Annual interest rate
        /// </summary>
        [JsonPropertyName("annualInterestRate")]
        public decimal AnnualInterestRate { get; set; }
        /// <summary>
        /// Max borrowable quantity
        /// </summary>
        [JsonPropertyName("maxBorrowableAmount")]
        public decimal MaxBorrowableQuantity { get; set; }
        /// <summary>
        /// Vip list
        /// </summary>
        [JsonPropertyName("vipList")]
        public BitgetCrossInterestLimitVip[] VipList { get; set; } = Array.Empty<BitgetCrossInterestLimitVip>();
    }

    /// <summary>
    /// Vip limits
    /// </summary>
    [SerializationModel]
    public record BitgetCrossInterestLimitVip
    {
        /// <summary>
        /// Level
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; } = string.Empty;
        /// <summary>
        /// Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
        /// <summary>
        /// Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// Annual interest rate
        /// </summary>
        [JsonPropertyName("annualInterestRate")]
        public decimal AnnualInterestRate { get; set; }
        /// <summary>
        /// Discount rate
        /// </summary>
        [JsonPropertyName("discountRate")]
        public decimal DiscountRate { get; set; }
    }


}

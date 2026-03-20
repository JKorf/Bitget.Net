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
        /// ["<c>transferable</c>"] Transferable
        /// </summary>
        [JsonPropertyName("transferable")]
        public bool Transferable { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>borrowable</c>"] Borrowable
        /// </summary>
        [JsonPropertyName("borrowable")]
        public bool Borrowable { get; set; }
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
        /// ["<c>maxBorrowableAmount</c>"] Max borrowable quantity
        /// </summary>
        [JsonPropertyName("maxBorrowableAmount")]
        public decimal MaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>vipList</c>"] Vip list
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
        /// ["<c>level</c>"] Level
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>limit</c>"] Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
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
        /// ["<c>discountRate</c>"] Discount rate
        /// </summary>
        [JsonPropertyName("discountRate")]
        public decimal DiscountRate { get; set; }
    }


}

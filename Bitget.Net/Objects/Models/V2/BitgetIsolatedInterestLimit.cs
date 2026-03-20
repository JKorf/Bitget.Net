using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// 
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedInterestLimit
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseTransferable</c>"] Base asset transferable
        /// </summary>
        [JsonPropertyName("baseTransferable")]
        public bool BaseTransferable { get; set; }
        /// <summary>
        /// ["<c>baseBorrowable</c>"] Base asset borrowable
        /// </summary>
        [JsonPropertyName("baseBorrowable")]
        public bool BaseBorrowable { get; set; }
        /// <summary>
        /// ["<c>baseDailyInterestRate</c>"] Base asset daily interest rate
        /// </summary>
        [JsonPropertyName("baseDailyInterestRate")]
        public decimal BaseDailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>baseAnnuallyInterestRate</c>"] Base asset annually interest rate
        /// </summary>
        [JsonPropertyName("baseAnnuallyInterestRate")]
        public decimal BaseAnnuallyInterestRate { get; set; }
        /// <summary>
        /// ["<c>baseMaxBorrowableAmount</c>"] Base asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("baseMaxBorrowableAmount")]
        public decimal BaseMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>baseVipList</c>"] Base vip list
        /// </summary>
        [JsonPropertyName("baseVipList")]
        public BitgetIsolatedInterestLimitVip[] BaseVipList { get; set; } = Array.Empty<BitgetIsolatedInterestLimitVip>();
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>quoteTransferable</c>"] Quote asset transferable
        /// </summary>
        [JsonPropertyName("quoteTransferable")]
        public bool QuoteTransferable { get; set; }
        /// <summary>
        /// ["<c>quoteBorrowable</c>"] Quote asset borrowable
        /// </summary>
        [JsonPropertyName("quoteBorrowable")]
        public bool QuoteBorrowable { get; set; }
        /// <summary>
        /// ["<c>quoteDailyInterestRate</c>"] Quote asset daily interest rate
        /// </summary>
        [JsonPropertyName("quoteDailyInterestRate")]
        public decimal QuoteDailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>quoteAnnuallyInterestRate</c>"] Quote asset annually interest rate
        /// </summary>
        [JsonPropertyName("quoteAnnuallyInterestRate")]
        public decimal QuoteAnnuallyInterestRate { get; set; }
        /// <summary>
        /// ["<c>quoteMaxBorrowableAmount</c>"] Quote asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("quoteMaxBorrowableAmount")]
        public decimal QuoteMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>quoteList</c>"] Quote list
        /// </summary>
        [JsonPropertyName("quoteList")]
        public BitgetIsolatedInterestLimitQuote[] QuoteList { get; set; } = Array.Empty<BitgetIsolatedInterestLimitQuote>();
    }

    /// <summary>
    /// VIP level
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedInterestLimitVip
    {
        /// <summary>
        /// ["<c>level</c>"] Level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// ["<c>dailyInterestRate</c>"] Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>limit</c>"] Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
        /// <summary>
        /// ["<c>annuallyInterestRate</c>"] Annually interest rate
        /// </summary>
        [JsonPropertyName("annuallyInterestRate")]
        public decimal AnnuallyInterestRate { get; set; }
        /// <summary>
        /// ["<c>discountRate</c>"] Discount rate
        /// </summary>
        [JsonPropertyName("discountRate")]
        public decimal DiscountRate { get; set; }
    }

    /// <summary>
    /// Quote level
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedInterestLimitQuote
    {
        /// <summary>
        /// ["<c>level</c>"] Level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// ["<c>dailyInterestRate</c>"] Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// ["<c>limit</c>"] Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
        /// <summary>
        /// ["<c>annuallyInterestRate</c>"] Annually interest rate
        /// </summary>
        [JsonPropertyName("annuallyInterestRate")]
        public decimal AnnuallyInterestRate { get; set; }
        /// <summary>
        /// ["<c>discountRate</c>"] Discount rate
        /// </summary>
        [JsonPropertyName("discountRate")]
        public decimal DiscountRate { get; set; }
    }


}

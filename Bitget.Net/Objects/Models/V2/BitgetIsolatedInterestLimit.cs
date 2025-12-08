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
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Base asset transferable
        /// </summary>
        [JsonPropertyName("baseTransferable")]
        public bool BaseTransferable { get; set; }
        /// <summary>
        /// Base asset borrowable
        /// </summary>
        [JsonPropertyName("baseBorrowable")]
        public bool BaseBorrowable { get; set; }
        /// <summary>
        /// Base asset daily interest rate
        /// </summary>
        [JsonPropertyName("baseDailyInterestRate")]
        public decimal BaseDailyInterestRate { get; set; }
        /// <summary>
        /// Base asset annually interest rate
        /// </summary>
        [JsonPropertyName("baseAnnuallyInterestRate")]
        public decimal BaseAnnuallyInterestRate { get; set; }
        /// <summary>
        /// Base asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("baseMaxBorrowableAmount")]
        public decimal BaseMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// Base vip list
        /// </summary>
        [JsonPropertyName("baseVipList")]
        public BitgetIsolatedInterestLimitVip[] BaseVipList { get; set; } = Array.Empty<BitgetIsolatedInterestLimitVip>();
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset transferable
        /// </summary>
        [JsonPropertyName("quoteTransferable")]
        public bool QuoteTransferable { get; set; }
        /// <summary>
        /// Quote asset borrowable
        /// </summary>
        [JsonPropertyName("quoteBorrowable")]
        public bool QuoteBorrowable { get; set; }
        /// <summary>
        /// Quote asset daily interest rate
        /// </summary>
        [JsonPropertyName("quoteDailyInterestRate")]
        public decimal QuoteDailyInterestRate { get; set; }
        /// <summary>
        /// Quote asset annually interest rate
        /// </summary>
        [JsonPropertyName("quoteAnnuallyInterestRate")]
        public decimal QuoteAnnuallyInterestRate { get; set; }
        /// <summary>
        /// Quote asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("quoteMaxBorrowableAmount")]
        public decimal QuoteMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// Quote list
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
        /// Level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
        /// <summary>
        /// Annually interest rate
        /// </summary>
        [JsonPropertyName("annuallyInterestRate")]
        public decimal AnnuallyInterestRate { get; set; }
        /// <summary>
        /// Discount rate
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
        /// Level
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
        /// <summary>
        /// Daily interest rate
        /// </summary>
        [JsonPropertyName("dailyInterestRate")]
        public decimal DailyInterestRate { get; set; }
        /// <summary>
        /// Limit
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal Limit { get; set; }
        /// <summary>
        /// Annually interest rate
        /// </summary>
        [JsonPropertyName("annuallyInterestRate")]
        public decimal AnnuallyInterestRate { get; set; }
        /// <summary>
        /// Discount rate
        /// </summary>
        [JsonPropertyName("discountRate")]
        public decimal DiscountRate { get; set; }
    }


}

using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// My trader
    /// </summary>
    [SerializationModel]
    public record BitgetCopyTradingMyTrader
    {
        /// <summary>
        /// Certification type
        /// </summary>
        [JsonPropertyName("certificationType")]
        public CertificationType CertificationType { get; set; }

        /// <summary>
        /// Trader ID
        /// </summary>
        [JsonPropertyName("traderId")]
        public string TraderId { get; set; } = string.Empty;

        /// <summary>
        /// Trader alias
        /// </summary>
        [JsonPropertyName("traderName")]
        public string TraderName { get; set; } = string.Empty;

        /// <summary>
        /// Maximum number of elite traders to follow
        /// </summary>
        [JsonPropertyName("maxFollowLimit")]
        public int MaxFollowLimit { get; set; }

        /// <summary>
        /// Number of elite traders that you have followed
        /// </summary>
        [JsonPropertyName("followCount")]
        public int FollowCount { get; set; }

        /// <summary>
        /// Total opening margin
        /// </summary>
        [JsonPropertyName("traceTotalMarginAmount")]
        public decimal TraceTotalMarginAmount { get; set; }

        /// <summary>
        /// Total net profit
        /// </summary>
        [JsonPropertyName("traceTotalNetProfit")]
        public decimal TraceTotalNetProfit { get; set; }

        /// <summary>
        /// Total profit
        /// </summary>
        [JsonPropertyName("traceTotalProfit")]
        public decimal TraceTotalProfit { get; set; }

        /// <summary>
        /// Current underlying assets for copy trading
        /// </summary>
        [JsonPropertyName("currentTradingPairs")]
        public string[] CurrentTradingPairs { get; set; } = [];

        /// <summary>
        /// Following date (take the first following date)
        /// </summary>
        [JsonPropertyName("followerTime")]
        public DateTime FollowerTime { get; set; }

        /// <summary>
        /// Maximum number of elite traders to follow granted by BGB holdings
        /// </summary>
        [JsonPropertyName("bgbMaxFollowLimit")]
        public int BgbMaxFollowLimit { get; set; }

        /// <summary>
        /// Number of elite traders that you have followed granted by BGB holdings
        /// </summary>
        [JsonPropertyName("bgbFollowCount")]
        public int BgbFollowCount { get; set; }
    }
}

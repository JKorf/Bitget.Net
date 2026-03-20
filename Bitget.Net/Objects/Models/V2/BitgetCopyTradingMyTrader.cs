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
        /// ["<c>certificationType</c>"] Certification type
        /// </summary>
        [JsonPropertyName("certificationType")]
        public CertificationType CertificationType { get; set; }

        /// <summary>
        /// ["<c>traderId</c>"] Trader ID
        /// </summary>
        [JsonPropertyName("traderId")]
        public string TraderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>traderName</c>"] Trader alias
        /// </summary>
        [JsonPropertyName("traderName")]
        public string TraderName { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>maxFollowLimit</c>"] Maximum number of elite traders to follow
        /// </summary>
        [JsonPropertyName("maxFollowLimit")]
        public int MaxFollowLimit { get; set; }

        /// <summary>
        /// ["<c>followCount</c>"] Number of elite traders that you have followed
        /// </summary>
        [JsonPropertyName("followCount")]
        public int FollowCount { get; set; }

        /// <summary>
        /// ["<c>traceTotalMarginAmount</c>"] Total opening margin
        /// </summary>
        [JsonPropertyName("traceTotalMarginAmount")]
        public decimal TraceTotalMarginAmount { get; set; }

        /// <summary>
        /// ["<c>traceTotalNetProfit</c>"] Total net profit
        /// </summary>
        [JsonPropertyName("traceTotalNetProfit")]
        public decimal TraceTotalNetProfit { get; set; }

        /// <summary>
        /// ["<c>traceTotalProfit</c>"] Total profit
        /// </summary>
        [JsonPropertyName("traceTotalProfit")]
        public decimal TraceTotalProfit { get; set; }

        /// <summary>
        /// ["<c>currentTradingPairs</c>"] Current underlying assets for copy trading
        /// </summary>
        [JsonPropertyName("currentTradingPairs")]
        public string[] CurrentTradingPairs { get; set; } = [];

        /// <summary>
        /// ["<c>followerTime</c>"] Following date (take the first following date)
        /// </summary>
        [JsonPropertyName("followerTime")]
        public DateTime FollowerTime { get; set; }

        /// <summary>
        /// ["<c>bgbMaxFollowLimit</c>"] Maximum number of elite traders to follow granted by BGB holdings
        /// </summary>
        [JsonPropertyName("bgbMaxFollowLimit")]
        public int BgbMaxFollowLimit { get; set; }

        /// <summary>
        /// ["<c>bgbFollowCount</c>"] Number of elite traders that you have followed granted by BGB holdings
        /// </summary>
        [JsonPropertyName("bgbFollowCount")]
        public int BgbFollowCount { get; set; }
    }
}

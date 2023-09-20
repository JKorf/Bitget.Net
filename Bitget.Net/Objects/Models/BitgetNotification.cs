using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Notification
    /// </summary>
    public class BitgetNotification
    {
        /// <summary>
        /// Id of the notice
        /// </summary>
        public string NoticeId { get; set; } = string.Empty;
        /// <summary>
        /// Title
        /// </summary>
        public string NoticeTitle { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("noticeDesc")]
        public string NoticeDescription { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        public string LanguageType { get; set; } = string.Empty;
        /// <summary>
        /// Notice url
        /// </summary>
        public string NoticeUrl { get; set; } = string.Empty;
    }
}

using Bitget.Net.Enums;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Announcement
    /// </summary>
    public record BitgetAnnouncement
    {
        /// <summary>
        /// Announcement id
        /// </summary>
        [JsonPropertyName("annId")]
        public string AnnouncementId { get; set; } = string.Empty;
        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("annTitle")]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("annDesc")]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;
        /// <summary>
        /// Url
        /// </summary>
        [JsonPropertyName("annUrl")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Announcement type
        /// </summary>
        [JsonPropertyName("annType")]
        public AnnouncementType Type { get; set; }
        /// <summary>
        /// Sub type
        /// </summary>
        [JsonPropertyName("annSubType")]
        public string? SubType { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }
    }
}

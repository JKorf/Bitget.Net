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
        /// ["<c>annId</c>"] Announcement id
        /// </summary>
        [JsonPropertyName("annId")]
        public string AnnouncementId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>annTitle</c>"] Title
        /// </summary>
        [JsonPropertyName("annTitle")]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>annDesc</c>"] Description
        /// </summary>
        [JsonPropertyName("annDesc")]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>language</c>"] Language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>annUrl</c>"] Url
        /// </summary>
        [JsonPropertyName("annUrl")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>annType</c>"] Announcement type
        /// </summary>
        [JsonPropertyName("annType")]
        public AnnouncementType Type { get; set; }
        /// <summary>
        /// ["<c>annSubType</c>"] Sub type
        /// </summary>
        [JsonPropertyName("annSubType")]
        public string? SubType { get; set; }

        /// <summary>
        /// ["<c>cTime</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }
    }
}

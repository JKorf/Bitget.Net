using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Account information
    /// </summary>
    [SerializationModel]
    public record BitgetAccountInfo
    {
        /// <summary>
        /// ["<c>userId</c>"] User id
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>inviterId</c>"] User id of the user who invited
        /// </summary>
        [JsonPropertyName("inviterId")]
        public string? InviterId { get; set; }
        /// <summary>
        /// ["<c>ips</c>"] IP whitelist
        /// </summary>
        [JsonPropertyName("ips")]
        public string? IpWhitelist { get; set; }
        /// <summary>
        /// ["<c>authorities</c>"] Premissions list
        /// </summary>
        [JsonPropertyName("authorities")]
        public string[] Permissions { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>parentId</c>"] Main account id
        /// </summary>
        [JsonPropertyName("parentId")]
        public long ParentId { get; set; }
        /// <summary>
        /// ["<c>traderType</c>"] Account type
        /// </summary>
        [JsonPropertyName("traderType")]
        public string TraderType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>channelCode</c>"] Affiliate referral code
        /// </summary>
        [JsonPropertyName("channelCode")]
        public string ReferralCode { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>channel</c>"] Affiliate
        /// </summary>
        [JsonPropertyName("channel")]
        public string Affiliate { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>regisTime</c>"] Registration time
        /// </summary>
        [JsonPropertyName("regisTime")]
        public DateTime RegistrationTime { get; set; }
    }
}

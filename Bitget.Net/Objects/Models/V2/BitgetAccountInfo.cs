using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// User id
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// User id of the user who invited
        /// </summary>
        [JsonPropertyName("inviterId")]
        public string? InviterId { get; set; }
        /// <summary>
        /// IP whitelist
        /// </summary>
        [JsonPropertyName("ips")]
        public string? IpWhitelist { get; set; }
        /// <summary>
        /// Premissions list
        /// </summary>
        [JsonPropertyName("authorities")]
        public string[] Permissions { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Main account id
        /// </summary>
        [JsonPropertyName("parentId")]
        public long ParentId { get; set; }
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("traderType")]
        public string TraderType { get; set; } = string.Empty;
        /// <summary>
        /// Affiliate referral code
        /// </summary>
        [JsonPropertyName("channelCode")]
        public string ReferralCode { get; set; } = string.Empty;
        /// <summary>
        /// Affiliate
        /// </summary>
        [JsonPropertyName("channel")]
        public string Affiliate { get; set; } = string.Empty;
        /// <summary>
        /// Registration time
        /// </summary>
        [JsonPropertyName("regisTime")]
        public DateTime RegistrationTime { get; set; }
    }
}

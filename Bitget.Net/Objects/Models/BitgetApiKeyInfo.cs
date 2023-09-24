using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Api key info
    /// </summary>
    public class BitgetApiKeyInfo
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// Inviter id
        /// </summary>
        [JsonProperty("inviter_id")]
        public string? InviterId { get; set; }
        /// <summary>
        /// Agent inviter code
        /// </summary>
        [JsonProperty("agent_inviter_code")]
        public string? AgentInviterId { get; set; }
        /// <summary>
        /// Channel
        /// </summary>
        [JsonProperty("channel")]
        public string? Channel { get; set; }
        /// <summary>
        /// Whitelist ips
        /// </summary>
        [JsonProperty("ips")]
        public string? Ips { get; set; }
        /// <summary>
        /// Parent uid
        /// </summary>
        [JsonProperty("parentId")]
        public long? ParentId { get; set; }
        /// <summary>
        /// True if trade
        /// </summary>
        [JsonProperty("trader")]
        public bool Trader { get; set; }
        /// <summary>
        /// True if spot trader
        /// </summary>
        [JsonProperty("isSpotTrader")]
        public bool IsSpotTrader { get; set; }
        /// <summary>
        /// List of permissions
        /// </summary>
        [JsonProperty("authorities")]
        public IEnumerable<string> Permissions { get; set; } = Array.Empty<string>();
    }
}

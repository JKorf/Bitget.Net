using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Unified account upgrade status
    /// </summary>
    public record BitgetUpgradeStatus
    {
        /// <summary>
        /// ["<c>status</c>"] Status of the upgrade; can be "process", "success", or "fail"
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>reason</c>"] Failure reason, if the upgrade failed
        /// </summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}

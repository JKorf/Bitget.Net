using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repay history
    /// </summary>
    public record BitgetCrossRepayHistory
    {
        /// <summary>
        /// Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Repay quantity
        /// </summary>
        [JsonPropertyName("repayAmount")]
        public decimal RepayQuantity { get; set; }
        /// <summary>
        /// Repay type
        /// </summary>
        [JsonPropertyName("repayType")]
        public RepayType RepayType { get; set; }
        /// <summary>
        /// Repay interest
        /// </summary>
        [JsonPropertyName("repayInterest")]
        public decimal RepayInterest { get; set; }
        /// <summary>
        /// Repay principal
        /// </summary>
        [JsonPropertyName("repayPrincipal")]
        public decimal RepayPrincipal { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

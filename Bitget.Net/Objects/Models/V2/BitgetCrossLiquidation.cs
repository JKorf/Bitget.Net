using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Liquidation info
    /// </summary>
    public record BitgetCrossLiquidation
    {
        /// <summary>
        /// Liquidation id
        /// </summary>
        [JsonPropertyName("liqId")]
        public string LiquidationId { get; set; } = string.Empty;
        /// <summary>
        /// Liquidation start time
        /// </summary>
        [JsonPropertyName("liqStartTime")]
        public DateTime LiquidationStartTime { get; set; }
        /// <summary>
        /// Liquidation end time
        /// </summary>
        [JsonPropertyName("liqEndTime")]
        public DateTime LiquidationEndTime { get; set; }
        /// <summary>
        /// Liquidation risk ratio
        /// </summary>
        [JsonPropertyName("liqRiskRatio")]
        public decimal LiquidationRiskRatio { get; set; }
        /// <summary>
        /// Total assets
        /// </summary>
        [JsonPropertyName("totalAssets")]
        public decimal TotalAssets { get; set; }
        /// <summary>
        /// Total debt
        /// </summary>
        [JsonPropertyName("totalDebt")]
        public decimal TotalDebt { get; set; }
        /// <summary>
        /// Liquidation fee
        /// </summary>
        [JsonPropertyName("liqFee")]
        public decimal LiquidationFee { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
    }


}

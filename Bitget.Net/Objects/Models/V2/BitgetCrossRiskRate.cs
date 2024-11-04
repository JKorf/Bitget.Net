using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Risk rate
    /// </summary>
    public record BitgetCrossRiskRate
    {
        /// <summary>
        /// Risk rate ratio
        /// </summary>
        [JsonPropertyName("riskRateRatio")]
        public decimal RiskRateRatio { get; set; }
    }


}

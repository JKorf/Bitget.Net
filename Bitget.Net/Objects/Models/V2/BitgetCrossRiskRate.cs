using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Risk rate
    /// </summary>
    [SerializationModel]
    public record BitgetCrossRiskRate
    {
        /// <summary>
        /// Risk rate ratio
        /// </summary>
        [JsonPropertyName("riskRateRatio")]
        public decimal RiskRateRatio { get; set; }
    }


}

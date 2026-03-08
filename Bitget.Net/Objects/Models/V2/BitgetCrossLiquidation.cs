using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Liquidation info
    /// </summary>
    [SerializationModel]
    public record BitgetCrossLiquidation
    {
        /// <summary>
        /// ["<c>liqId</c>"] Liquidation id
        /// </summary>
        [JsonPropertyName("liqId")]
        public string LiquidationId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>liqStartTime</c>"] Liquidation start time
        /// </summary>
        [JsonPropertyName("liqStartTime")]
        public DateTime LiquidationStartTime { get; set; }
        /// <summary>
        /// ["<c>liqEndTime</c>"] Liquidation end time
        /// </summary>
        [JsonPropertyName("liqEndTime")]
        public DateTime LiquidationEndTime { get; set; }
        /// <summary>
        /// ["<c>liqRiskRatio</c>"] Liquidation risk ratio
        /// </summary>
        [JsonPropertyName("liqRiskRatio")]
        public decimal LiquidationRiskRatio { get; set; }
        /// <summary>
        /// ["<c>totalAssets</c>"] Total assets
        /// </summary>
        [JsonPropertyName("totalAssets")]
        public decimal TotalAssets { get; set; }
        /// <summary>
        /// ["<c>totalDebt</c>"] Total debt
        /// </summary>
        [JsonPropertyName("totalDebt")]
        public decimal TotalDebt { get; set; }
        /// <summary>
        /// ["<c>liqFee</c>"] Liquidation fee
        /// </summary>
        [JsonPropertyName("liqFee")]
        public decimal LiquidationFee { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
    }


}

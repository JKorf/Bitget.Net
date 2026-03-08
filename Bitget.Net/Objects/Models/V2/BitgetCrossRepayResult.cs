using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repayment result
    /// </summary>
    [SerializationModel]
    public record BitgetCrossRepayResult
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>repayId</c>"] Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>remainDebtAmount</c>"] Remain debt quantity
        /// </summary>
        [JsonPropertyName("remainDebtAmount")]
        public decimal RemainDebtQuantity { get; set; }
        /// <summary>
        /// ["<c>repayAmount</c>"] Repay quantity
        /// </summary>
        [JsonPropertyName("repayAmount")]
        public decimal RepayQuantity { get; set; }
    }


}

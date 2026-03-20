using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repay history
    /// </summary>
    [SerializationModel]
    public record BitgetCrossRepayHistory
    {
        /// <summary>
        /// ["<c>repayId</c>"] Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>repayAmount</c>"] Repay quantity
        /// </summary>
        [JsonPropertyName("repayAmount")]
        public decimal RepayQuantity { get; set; }
        /// <summary>
        /// ["<c>repayType</c>"] Repay type
        /// </summary>
        [JsonPropertyName("repayType")]
        public RepayType RepayType { get; set; }
        /// <summary>
        /// ["<c>repayInterest</c>"] Repay interest
        /// </summary>
        [JsonPropertyName("repayInterest")]
        public decimal RepayInterest { get; set; }
        /// <summary>
        /// ["<c>repayPrincipal</c>"] Repay principal
        /// </summary>
        [JsonPropertyName("repayPrincipal")]
        public decimal RepayPrincipal { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}

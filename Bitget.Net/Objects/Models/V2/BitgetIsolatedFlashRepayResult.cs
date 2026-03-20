using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repayment result
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedFlashRepayResult
    {
        /// <summary>
        /// ["<c>repayId</c>"] Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>result</c>"] Result
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;
    }


}

using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position Tp/Sl result
    /// </summary>
    public record BitgetPositionTpSl
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>stopSurplusClientOid</c>"] Take profit client order id
        /// </summary>
        [JsonPropertyName("stopSurplusClientOid")]
        public string? TakeProfitClientOrderId { get; set; }
        /// <summary>
        /// ["<c>stopLossClientOid</c>"] Stop loss client order id
        /// </summary>
        [JsonPropertyName("stopLossClientOid")]
        public string? StopLossClientOrderId { get; set; }
    }


}

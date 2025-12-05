using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position Tp/Sl result
    /// </summary>
    public record BitgetPositionTpSl
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Take profit client order id
        /// </summary>
        [JsonPropertyName("stopSurplusClientOid")]
        public string? TakeProfitClientOrderId { get; set; }
        /// <summary>
        /// Stop loss client order id
        /// </summary>
        [JsonPropertyName("stopLossClientOid")]
        public string? StopLossClientOrderId { get; set; }
    }


}

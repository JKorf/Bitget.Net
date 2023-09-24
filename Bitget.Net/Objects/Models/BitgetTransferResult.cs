using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Transfer result
    /// </summary>
    public class BitgetTransferResult
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty("transferId")]
        public string TransferId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string? ClientOrderId { get; set; }
    }
}

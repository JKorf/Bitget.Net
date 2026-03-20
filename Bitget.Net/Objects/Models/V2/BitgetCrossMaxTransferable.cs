using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max transferable
    /// </summary>
    [SerializationModel]
    public record BitgetCrossMaxTransferable
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>maxTransferOutAmount</c>"] Max transfer out quantity
        /// </summary>
        [JsonPropertyName("maxTransferOutAmount")]
        public decimal MaxTransferOutQuantity { get; set; }
    }


}

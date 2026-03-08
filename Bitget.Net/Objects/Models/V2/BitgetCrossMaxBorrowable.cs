using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max borrowable
    /// </summary>
    [SerializationModel]
    public record BitgetCrossMaxBorrowable
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>maxBorrowableAmount</c>"] Max borrowable quantity
        /// </summary>
        [JsonPropertyName("maxBorrowableAmount")]
        public decimal MaxBorrowableQuantity { get; set; }
    }


}

using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Multiple orders result
    /// </summary>
    [SerializationModel]
    public record BitgetOrderMultipleResult
    {
        /// <summary>
        /// ["<c>successList</c>"] Successful orders
        /// </summary>
        [JsonPropertyName("successList")]
        public BitgetOrderId[] Success { get; set; } = Array.Empty<BitgetOrderId>();
        /// <summary>
        /// ["<c>failureList</c>"] Failed orders
        /// </summary>
        [JsonPropertyName("failureList")]
        public BitgetPlaceFailure[] Failed { get; set; } = Array.Empty<BitgetPlaceFailure>();
    }

    /// <summary>
    /// Place order failure info
    /// </summary>
    [SerializationModel]
    public record BitgetPlaceFailure
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>errorMsg</c>"] Error message
        /// </summary>
        [JsonPropertyName("errorMsg")]
        public string ErrorMessage { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>errorCode</c>"] Error code
        /// </summary>
        [JsonPropertyName("errorCode"), JsonConverter(typeof(IntConverter))]
        public int? ErrorCode { get; set; }
    }
}

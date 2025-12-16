using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order cancel request
    /// </summary>
    public record BitgetCancelOrderRequest
    {
        /// <summary>
        /// Order id. Either this or ClientOrderId should be provided
        /// </summary>
        [JsonPropertyName("orderId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? OrderId { get; set; }
        /// <summary>
        /// Client order id. Either this or OrderId should be provided
        /// </summary>
        [JsonPropertyName("clientOid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
    }
}

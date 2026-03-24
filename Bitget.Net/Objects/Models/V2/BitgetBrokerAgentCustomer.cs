using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Agent customer
    /// </summary>
    [SerializationModel]
    public record BitgetBrokerAgentCustomer
    {
        /// <summary>
        /// User Id
        /// </summary>
        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        /// <summary>
        /// Register time
        /// </summary>
        [JsonPropertyName("registerTime")]
        public DateTime RegisterTime { get; set; }
    }
}

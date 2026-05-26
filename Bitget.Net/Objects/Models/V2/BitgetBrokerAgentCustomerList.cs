using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Agent customer
    /// </summary>
    [SerializationModel]
    public record BitgetBrokerAgentCustomerList
    {
        /// <summary>
        /// Agent Customer List
        /// </summary>
        [JsonPropertyName("list")]
        public BitgetBrokerAgentCustomer[] List { get; set; } = [];

        /// <summary>
        /// Min id in the results
        /// </summary>
        [JsonPropertyName("minId")]
        public string MinId { get; set; } = string.Empty;
    }
}

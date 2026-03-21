using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Agent customer
    /// </summary>
    [SerializationModel]
    public record BitgetBrokerAgentDirectCommissions
    {
        /// <summary>
        /// Commission List
        /// </summary>
        [JsonPropertyName("commissionList")]
        public BitgetBrokerAgentDirectCommissionItem[]? CommissionList { get; set; }

        /// <summary>
        /// Last data ID. Used as an index for querying data when making a request
        /// </summary>
        [JsonPropertyName("endId")]
        public long EndId { get; set; }
    }
}

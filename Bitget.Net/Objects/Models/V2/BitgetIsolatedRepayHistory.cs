using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Repay history
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedRepayHistory : BitgetCrossRepayHistory
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;        
    }


}

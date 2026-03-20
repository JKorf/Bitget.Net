using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Funding rate
    /// </summary>
    [SerializationModel]
    public record BitgetCurrentFundingRate
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fundingRate</c>"] Current funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// ["<c>fundingRateInterval</c>"] Funding interval in hours
        /// </summary>
        [JsonPropertyName("fundingRateInterval")]
        public int FundingInterval { get; set; }
        /// <summary>
        /// ["<c>minFundingRate</c>"] Lower limit of funding rate, 0.025 represents 2.5%
        /// </summary>
        [JsonPropertyName("minFundingRate")]
        public decimal? FundingRateLowerLimit { get; set; }
        /// <summary>
        /// ["<c>maxFundingRate</c>"] Upper limit of funding rate, 0.025 represents 2.5%
        /// </summary>
        [JsonPropertyName("maxFundingRate")]
        public decimal? FundingRateUpperLimit { get; set; }
    }
}

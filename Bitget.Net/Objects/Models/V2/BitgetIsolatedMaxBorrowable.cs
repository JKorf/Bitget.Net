using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max borrowable
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedMaxBorrowable
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Base asset max borrow quantity
        /// </summary>
        [JsonPropertyName("baseCoinMaxBorrowAmount")]
        public decimal BaseAssetMaxBorrowQuantity { get; set; }
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset max borrow quantity
        /// </summary>
        [JsonPropertyName("quoteCoinMaxBorrowAmount")]
        public decimal QuoteAssetMaxBorrowQuantity { get; set; }
    }


}

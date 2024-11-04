using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Max transferable
    /// </summary>
    public record BitgetIsolatedMaxTransferable
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
        /// Base asset max transfer out quantity
        /// </summary>
        [JsonPropertyName("baseCoinMaxTransferOutAmount")]
        public decimal BaseAssetMaxBorrowQuantity { get; set; }
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset max transfer out quantity
        /// </summary>
        [JsonPropertyName("quoteCoinMaxTransferOutAmount")]
        public decimal QuoteAssetMaxBorrowQuantity { get; set; }
    }


}

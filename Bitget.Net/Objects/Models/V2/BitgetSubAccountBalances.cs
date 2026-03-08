using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Sub account balances
    /// </summary>
    [SerializationModel]
    public record BitgetSubAccountBalances
    {
        /// <summary>
        /// ["<c>id</c>"] Cursor id
        /// </summary>
        [JsonPropertyName("id")]
        public string? CursorId { get; set; }
        /// <summary>
        /// ["<c>userId</c>"] User id
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// ["<c>assetsList</c>"] Assets
        /// </summary>
        [JsonPropertyName("assetsList")]
        public BitgetSubAccountBalance[] Assets { get; set; } = Array.Empty<BitgetSubAccountBalance>();
    }

    /// <summary>
    /// Sub account balance
    /// </summary>
    [SerializationModel]
    public record BitgetSubAccountBalance
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>available</c>"] Available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>limitAvailable</c>"] Restricted availability, for spot copy trading
        /// </summary>
        [JsonPropertyName("limitAvailable")]
        public decimal LimitAvailable { get; set; }
        /// <summary>
        /// ["<c>frozen</c>"] Frozen
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// ["<c>locked</c>"] Locked
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }


}

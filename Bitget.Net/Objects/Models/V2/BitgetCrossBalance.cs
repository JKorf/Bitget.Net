using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Cross margin balance
    /// </summary>
    [SerializationModel]
    public record BitgetCrossBalance
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>totalAmount</c>"] Total quantity
        /// </summary>
        [JsonPropertyName("totalAmount")]
        public decimal TotalQuantity { get; set; }
        /// <summary>
        /// ["<c>available</c>"] Available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>frozen</c>"] Frozen
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// ["<c>borrow</c>"] Borrow
        /// </summary>
        [JsonPropertyName("borrow")]
        public decimal Borrow { get; set; }
        /// <summary>
        /// ["<c>interest</c>"] Interest
        /// </summary>
        [JsonPropertyName("interest")]
        public decimal Interest { get; set; }
        /// <summary>
        /// ["<c>net</c>"] Net
        /// </summary>
        [JsonPropertyName("net")]
        public decimal Net { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ["<c>coupon</c>"] Coupon
        /// </summary>
        [JsonPropertyName("coupon")]
        public decimal Coupon { get; set; }
    }


}

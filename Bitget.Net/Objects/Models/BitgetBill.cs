using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bill info
    /// </summary>
    public class BitgetBill
    {
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Asset id
        /// </summary>
        [JsonProperty("coinId")]
        public string AssetId { get; set; } = string.Empty;
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coinName")]
        public string AssetName { get; set; } = string.Empty;
        /// <summary>
        /// Group type
        /// </summary>
        [JsonProperty("groupType")]
        public BitgetGroupType GroupType { get; set; }
        /// <summary>
        /// Transaction type
        /// </summary>
        [JsonProperty("bizType")]
        public BizType Type { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Balance Before transfer
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonProperty("fees")]
        public decimal Fees { get; set; }
        /// <summary>
        /// Bill id
        /// </summary>
        [JsonProperty("billId")]
        public string BillId { get; set; } = string.Empty;
    }
}

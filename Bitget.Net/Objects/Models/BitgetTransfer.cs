using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Transfer info
    /// </summary>
    public class BitgetTransfer
    {
        /// <summary>
        /// Asset transfered
        /// </summary>
        [JsonProperty("coinName")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public BitgetTransferStatus Status { get; set; }
        /// <summary>
        /// To type
        /// </summary>
        [JsonProperty("toType")]
        public BitgetAccountType ToType { get; set; }
        /// <summary>
        /// To symbol
        /// </summary>
        [JsonProperty("toSymbol")]
        public string? ToSymbol { get; set; }
        /// <summary>
        /// From type
        /// </summary>
        [JsonProperty("fromType")]
        public BitgetAccountType FromType { get; set; }
        /// <summary>
        /// From symbol
        /// </summary>
        [JsonProperty("fromSymbol")]
        public string? FromSymbol { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("tradeTime")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty("transferId")]
        public string? TransferId { get; set; }
    }
}

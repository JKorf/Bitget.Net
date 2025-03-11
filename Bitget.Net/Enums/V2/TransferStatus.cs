using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Transfer status 
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TransferStatus>))]
    public enum TransferStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Successful", "success")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Failed", "fail")]
        Failed,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("Processing", "pending")]
        Processing
    }
}

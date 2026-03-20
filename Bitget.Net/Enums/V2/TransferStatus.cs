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
        /// ["<c>Successful</c>"] Success
        /// </summary>
        [Map("Successful", "success")]
        Success,
        /// <summary>
        /// ["<c>Failed</c>"] Failed
        /// </summary>
        [Map("Failed", "fail")]
        Failed,
        /// <summary>
        /// ["<c>Processing</c>"] Processing
        /// </summary>
        [Map("Processing", "pending")]
        Processing
    }
}

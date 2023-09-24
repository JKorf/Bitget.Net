using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Transfer status
    /// </summary>
    public enum BitgetTransferStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Successful")]
        Successful,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Failed")]
        Failed,
        /// <summary>
        /// In progress
        /// </summary>
        [Map("Processing")]
        Processing
    }
}

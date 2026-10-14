using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Objects.Options
{
    /// <inheritdoc />
    public class BitgetSharedApiOptions : SharedApiOptions
    {
        /// <summary>
        /// The API version to use for Shared API resolution
        /// </summary>
        public BitgetApiVersion ApiVersion { get; set; } = BitgetApiVersion.Classic;
    }

    /// <summary>
    /// API version for the Bitget API
    /// </summary>
    public enum BitgetApiVersion
    {
        /// <summary>
        /// Classic Spot and Futures API
        /// </summary>
        Classic,
        /// <summary>
        /// Unified API
        /// </summary>
        Unified
    }
}

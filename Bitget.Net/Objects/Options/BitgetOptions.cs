using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget options
    /// </summary>
    public class BitgetOptions : LibraryOptions<BitgetRestOptions, BitgetSocketOptions, BitgetCredentials, BitgetEnvironment>
    {
        /// <summary>
        /// Options for Shared API usage
        /// </summary>
        public SharedApiOptions SharedApi { get; set; } = new();
    }
}

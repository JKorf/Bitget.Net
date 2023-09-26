using Bitget.Net.Objects;
using CryptoExchange.Net.Objects;

namespace Bitget.Net
{
    /// <summary>
    /// Bitget environment
    /// </summary>
    public class BitgetEnvironment : TradeEnvironment
    {
        /// <summary>
        /// Base rest API address
        /// </summary>
        public string RestBaseAddress { get; }
        /// <summary>
        /// Base socket API address
        /// </summary>
        public string SocketBaseAddress { get; }

        internal BitgetEnvironment(string name, string baseRestAddress, string baseSocketAddress) :
            base(name)
        {
            RestBaseAddress = baseRestAddress;
            SocketBaseAddress = baseSocketAddress;
        }

        /// <summary>
        /// Live environment
        /// </summary>
        public static BitgetEnvironment Live { get; } = new BitgetEnvironment(TradeEnvironmentNames.Live, BitgetApiAddresses.Default.RestBaseAddress, BitgetApiAddresses.Default.SocketBaseAddress);

        /// <summary>
        /// Create a custom environment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="baseRestAddress"></param>
        /// <param name="socketRestAddress"></param>
        /// <returns></returns>
        public static BitgetEnvironment CreateCustom(string name, string baseRestAddress, string socketRestAddress)
            => new BitgetEnvironment(name, baseRestAddress, socketRestAddress);
    }
}
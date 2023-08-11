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
        /// Base API address
        /// </summary>
        public string BaseAddress { get; }

        internal BitgetEnvironment(string name, string baseAddress) :
            base(name)
        {
            BaseAddress = baseAddress;
        }

        /// <summary>
        /// Live environment
        /// </summary>
        public static BitgetEnvironment Live { get; } = new BitgetEnvironment(TradeEnvironmentNames.Live, BitgetApiAddresses.Default.BaseAddress);

        /// <summary>
        /// Create a custom environment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="spotAddress"></param>
        /// <param name="futuresAddress"></param>
        /// <returns></returns>
        public static BitgetEnvironment CreateCustom(string name, string baseAddress)
            => new BitgetEnvironment(name, baseAddress);
    }
}
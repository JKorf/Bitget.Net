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
        /// ctor for DI, use <see cref="CreateCustom"/> for creating a custom environment
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BitgetEnvironment() : base(TradeEnvironmentNames.Live)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        { }

        /// <summary>
        /// Get the Bitget environment by name
        /// </summary>
        public static BitgetEnvironment? GetEnvironmentByName(string? name)
         => name switch
         {
             TradeEnvironmentNames.Live => Live,
             "" => Live,
             null => Live,
             _ => default
         };

        /// <summary>
        /// Live environment
        /// </summary>
        public static BitgetEnvironment Live { get; } = new BitgetEnvironment(TradeEnvironmentNames.Live, BitgetApiAddresses.Default.RestBaseAddress, BitgetApiAddresses.Default.SocketBaseAddress);

        /// <summary>
        /// Demo trading environment
        /// </summary>
        public static BitgetEnvironment DemoTrading { get; } = new BitgetEnvironment("DemoTrading", BitgetApiAddresses.Default.RestBaseAddress, BitgetApiAddresses.Default.SocketBaseAddress);

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
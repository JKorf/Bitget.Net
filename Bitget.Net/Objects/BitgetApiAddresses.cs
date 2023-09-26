namespace Bitget.Net.Objects
{
    /// <summary>
    /// Bitget Api addresses
    /// </summary>
    public class BitgetApiAddresses
    {
        /// <summary>
        /// The address used by the library for the Bitget rest API
        /// </summary>
        public string RestBaseAddress { get; set; } = string.Empty;
        /// <summary>
        /// The address used by the library for the Bitget socket API
        /// </summary>
        public string SocketBaseAddress { get; set; } = string.Empty;

        /// <summary>
        /// The default addresses to connect to the kucoin.com API
        /// </summary>
        public static BitgetApiAddresses Default = new BitgetApiAddresses
        {
            RestBaseAddress = "https://api.bitget.com",
            SocketBaseAddress = "wss://ws.bitget.com",
        };
    }
}

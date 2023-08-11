namespace Bitget.Net.Objects
{
    /// <summary>
    /// Bitget Api addresses
    /// </summary>
    public class BitgetApiAddresses
    {
        /// <summary>
        /// The address used by the Bitget for the API
        /// </summary>
        public string BaseAddress { get; set; } = string.Empty;

        /// <summary>
        /// The default addresses to connect to the kucoin.com API
        /// </summary>
        public static BitgetApiAddresses Default = new BitgetApiAddresses
        {
            BaseAddress = "https://api.bitget.com"
        };
    }
}

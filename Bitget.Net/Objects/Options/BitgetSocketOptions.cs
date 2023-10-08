using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget socket client options
    /// </summary>
    public class BitgetSocketOptions : SocketExchangeOptions<BitgetEnvironment, BitgetApiCredentials>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        public static BitgetSocketOptions Default { get; set; } = new BitgetSocketOptions()
        {
            Environment = BitgetEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10
        };

        /// <summary>
        /// Spot API options
        /// </summary>
        public SocketApiOptions SpotOptions { get; private set; } = new SocketApiOptions();

        /// <summary>
        /// Futures API options
        /// </summary>
        public SocketApiOptions FuturesOptions { get; private set; } = new SocketApiOptions();

        internal BitgetSocketOptions Copy()
        {
            var options = Copy<BitgetSocketOptions>();
            options.SpotOptions = SpotOptions.Copy<SocketApiOptions>();
            options.FuturesOptions = FuturesOptions.Copy<SocketApiOptions>();
            return options;
        }
    }
}

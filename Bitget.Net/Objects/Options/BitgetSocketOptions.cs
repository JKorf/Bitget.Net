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
        internal static BitgetSocketOptions Default { get; set; } = new BitgetSocketOptions()
        {
            Environment = BitgetEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10,
            MaxSocketConnections = 100
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Spot API options
        /// </summary>
        public SocketApiOptions<BitgetApiCredentials> SpotOptions { get; private set; } = new SocketApiOptions<BitgetApiCredentials>();

        /// <summary>
        /// Futures API options
        /// </summary>
        public SocketApiOptions<BitgetApiCredentials> FuturesOptions { get; private set; } = new SocketApiOptions<BitgetApiCredentials>();

        internal BitgetSocketOptions Set(BitgetSocketOptions targetOptions)
        {
            targetOptions = base.Set<BitgetSocketOptions>(targetOptions);
            targetOptions.SpotOptions = SpotOptions.Set(targetOptions.SpotOptions);
            targetOptions.FuturesOptions = FuturesOptions.Set(targetOptions.FuturesOptions);
            return targetOptions;
        }
    }
}

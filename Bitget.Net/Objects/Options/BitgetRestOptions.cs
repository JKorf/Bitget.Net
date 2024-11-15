using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget rest client options
    /// </summary>
    public class BitgetRestOptions : RestExchangeOptions<BitgetEnvironment, BitgetApiCredentials>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static BitgetRestOptions Default { get; set; } = new BitgetRestOptions()
        {
            Environment = BitgetEnvironment.Live
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Channel code
        /// </summary>
        public string? ChannelCode { get; set; }

        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiOptions SpotOptions { get; private set; } = new RestApiOptions();

        /// <summary>
        /// Futures API options
        /// </summary>
        public RestApiOptions FuturesOptions { get; private set; } = new RestApiOptions();

        internal BitgetRestOptions Set(BitgetRestOptions targetOptions)
        {
            targetOptions = base.Set<BitgetRestOptions>(targetOptions);
            targetOptions.ChannelCode = ChannelCode;
            targetOptions.FuturesOptions = FuturesOptions.Set(targetOptions.FuturesOptions);
            targetOptions.SpotOptions = SpotOptions.Set(targetOptions.SpotOptions);
            return targetOptions;
        }
    }
}

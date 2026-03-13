using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget rest client options
    /// </summary>
    public class BitgetRestOptions : RestExchangeOptions<BitgetEnvironment, BitgetCredentials>
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
        /// Support language such as: Chinese (zh-CN), English (en-US)
        /// </summary>
        public string Locale { get; set; } = "en-US";

        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiOptions<BitgetCredentials> SpotOptions { get; private set; } = new RestApiOptions<BitgetCredentials>();

        /// <summary>
        /// Futures API options
        /// </summary>
        public RestApiOptions<BitgetCredentials> FuturesOptions { get; private set; } = new RestApiOptions<BitgetCredentials>();

        /// <summary>
        /// Copy Trading API options
        /// </summary>
        public RestApiOptions<BitgetCredentials> CopyTradingOptions { get; private set; } = new RestApiOptions<BitgetCredentials>();

        internal BitgetRestOptions Set(BitgetRestOptions targetOptions)
        {
            targetOptions = base.Set(targetOptions);
            targetOptions.ChannelCode = ChannelCode;
            targetOptions.FuturesOptions = FuturesOptions.Set(targetOptions.FuturesOptions);
            targetOptions.SpotOptions = SpotOptions.Set(targetOptions.SpotOptions);
            targetOptions.CopyTradingOptions = CopyTradingOptions.Set(targetOptions.CopyTradingOptions);
            return targetOptions;
        }
    }
}

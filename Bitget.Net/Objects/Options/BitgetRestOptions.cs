using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget rest client options
    /// </summary>
    public class BitgetRestOptions : RestExchangeOptions<BitgetEnvironment>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        public static BitgetRestOptions Default { get; set; } = new BitgetRestOptions()
        {
            Environment = BitgetEnvironment.Live
        };

        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiOptions SpotOptions { get; private set; } = new RestApiOptions();

        internal BitgetRestOptions Copy()
        {
            var options = Copy<BitgetRestOptions>();
            options.SpotOptions = SpotOptions.Copy<RestApiOptions>();
            return options;
        }
    }
}

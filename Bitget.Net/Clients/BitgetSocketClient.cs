using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetSocketClient : BaseSocketClient, IBitgetSocketClient
    {
        /// <inheritdoc />
        public Interfaces.Clients.SpotApi.IBitgetSocketClientSpotApi SpotApi { get; set; }
        /// <inheritdoc />
        public Interfaces.Clients.SpotApiV2.IBitgetSocketClientSpotApi SpotApiV2 { get; set; }
        /// <inheritdoc />
        public Interfaces.Clients.FuturesApi.IBitgetSocketClientFuturesApi FuturesApi { get; set; }
        /// <inheritdoc />
        public Interfaces.Clients.FuturesApiV2.IBitgetSocketClientFuturesApi FuturesApiV2 { get; set; }

        #region ctor

        /// <summary>
        /// Create a new instance of the BitgetSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        public BitgetSocketClient(ILoggerFactory? loggerFactory = null) : this((x) => { }, loggerFactory)
        {
        }

        /// <summary>
        /// Create a new instance of the BitgetSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetSocketClient(Action<BitgetSocketOptions> optionsDelegate) : this(optionsDelegate, null)
        {
        }

        /// <summary>
        /// Create a new instance of the BitgetSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetSocketClient(Action<BitgetSocketOptions> optionsDelegate, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bitget")
        {
            var options = BitgetSocketOptions.Default.Copy();
            optionsDelegate(options);
            Initialize(options);

            SpotApi = AddApiClient(new SpotApi.BitgetSocketClientSpotApi(_logger, options));
            SpotApiV2 = AddApiClient(new SpotApiV2.BitgetSocketClientSpotApi(_logger, options));
            FuturesApi = AddApiClient(new FuturesApi.BitgetSocketClientFuturesApi(_logger, options));
            FuturesApiV2 = AddApiClient(new FuturesApiV2.BitgetSocketClientFuturesApi(_logger, options));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetSocketOptions> optionsDelegate)
        {
            var options = BitgetSocketOptions.Default.Copy();
            optionsDelegate(options);
            BitgetSocketOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(BitgetApiCredentials credentials)
        {
            SpotApi.SetApiCredentials(credentials);
            SpotApiV2.SetApiCredentials(credentials);
            FuturesApi.SetApiCredentials(credentials);
            FuturesApiV2.SetApiCredentials(credentials);
        }
    }
}

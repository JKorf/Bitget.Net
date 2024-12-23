using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetSocketClient(Action<BitgetSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        {
        }

        /// <summary>
        /// Create a new instance of the BitgetSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public BitgetSocketClient(IOptions<BitgetSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bitget")
        {
            Initialize(options.Value);

            SpotApi = AddApiClient(new SpotApi.BitgetSocketClientSpotApi(_logger, options.Value));
            SpotApiV2 = AddApiClient(new SpotApiV2.BitgetSocketClientSpotApi(_logger, options.Value));
            FuturesApi = AddApiClient(new FuturesApi.BitgetSocketClientFuturesApi(_logger, options.Value));
            FuturesApiV2 = AddApiClient(new FuturesApiV2.BitgetSocketClientFuturesApi(_logger, options.Value));
        }

        #endregion

        /// <inheritdoc />
        public void SetOptions(UpdateOptions options)
        {
            SpotApi.SetOptions(options);
            SpotApiV2.SetOptions(options);
            FuturesApi.SetOptions(options);
            FuturesApiV2.SetOptions(options);
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetSocketOptions> optionsDelegate)
        {
            BitgetSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
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

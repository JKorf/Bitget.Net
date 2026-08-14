using Bitget.Net.Clients.UnifiedApi;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetSocketClient : BaseSocketClient<BitgetEnvironment, BitgetCredentials>, IBitgetSocketClient
    {
        /// <inheritdoc />
        public Interfaces.Clients.SpotApiV2.IBitgetSocketClientSpotApi SpotApiV2 { get; set; }
        /// <inheritdoc />
        public Interfaces.Clients.FuturesApiV2.IBitgetSocketClientFuturesApi FuturesApiV2 { get; set; }
        /// <inheritdoc />
        public IBitgetSocketClientUnifiedApi UnifiedApi { get; set; }

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

            SpotApiV2 = AddApiClient(new SpotApiV2.BitgetSocketClientSpotApi(loggerFactory, options.Value));
            FuturesApiV2 = AddApiClient(new FuturesApiV2.BitgetSocketClientFuturesApi(loggerFactory, options.Value));
            UnifiedApi = AddApiClient(new BitgetSocketClientUnifiedApi(loggerFactory, options.Value));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetSocketOptions> optionsDelegate)
        {
            BitgetSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}

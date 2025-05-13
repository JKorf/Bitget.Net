using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetRestClient : BaseRestClient, IBitgetRestClient
    {
        internal readonly string _defaultChannelCode = "6x21p";

        /// <inheritdoc />
        public Interfaces.Clients.SpotApiV2.IBitgetRestClientSpotApi SpotApiV2 { get; }
        /// <inheritdoc />
        public Interfaces.Clients.FuturesApiV2.IBitgetRestClientFuturesApi FuturesApiV2 { get; }
        /// <inheritdoc />
        public Interfaces.Clients.CopyTradingApiV2.IBitgetRestClientCopyTradingApi CopyTradingFuturesV2 { get; }

        /// <summary> 
        /// Create a new instance of BitgetRestClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetRestClient(Action<BitgetRestOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate)))
        {
        }

        /// <summary>
        /// Create a new instance of BitgetRestClient
        /// </summary>
        /// <param name="options">Option configuration</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public BitgetRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BitgetRestOptions> options) : base(loggerFactory, "Bitget")
        {
            Initialize(options.Value);

            SpotApiV2 = AddApiClient(new SpotApiV2.BitgetRestClientSpotApi(_logger, httpClient, this, options.Value));
            FuturesApiV2 = AddApiClient(new FuturesApiV2.BitgetRestClientFuturesApi(_logger, httpClient, this, options.Value));
            CopyTradingFuturesV2 = AddApiClient(new CopyTradingApiV2.BitgetRestClientCopyTradingApi(_logger, httpClient, this, options.Value));
        }

        /// <inheritdoc />
        public void SetOptions(UpdateOptions options)
        {
            SpotApiV2.SetOptions(options);
            FuturesApiV2.SetOptions(options);
            CopyTradingFuturesV2.SetOptions(options);
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            SpotApiV2.SetApiCredentials(credentials);
            FuturesApiV2.SetApiCredentials(credentials);
            CopyTradingFuturesV2.SetApiCredentials(credentials);
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsFunc">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetRestOptions> optionsFunc)
        {
            BitgetRestOptions.Default = ApplyOptionsDelegate(optionsFunc);
        }
    }
}

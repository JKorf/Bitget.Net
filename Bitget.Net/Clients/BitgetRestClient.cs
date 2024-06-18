using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetRestClient : BaseRestClient, IBitgetRestClient
    {
        internal readonly string _defaultChannelCode = "6x21p";

        /// <inheritdoc />
        public Interfaces.Clients.SpotApi.IBitgetRestClientSpotApi SpotApi { get; }
        /// <inheritdoc />
        public Interfaces.Clients.SpotApiV2.IBitgetRestClientSpotApi SpotApiV2 { get; }
        /// <inheritdoc />
        public Interfaces.Clients.FuturesApi.IBitgetRestClientFuturesApi FuturesApi { get; }

        /// <summary> 
        /// Create a new instance of BitgetRestClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetRestClient(Action<BitgetRestOptions>? optionsDelegate = null) : this(null, null, optionsDelegate)
        {
        }

        /// <summary>
        /// Create a new instance of BitgetRestClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public BitgetRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, Action<BitgetRestOptions>? optionsDelegate = null) : base(loggerFactory, "Bitget")
        {
            var options = BitgetRestOptions.Default.Copy();
            if (optionsDelegate != null)
                optionsDelegate(options);
            Initialize(options);

            SpotApi = AddApiClient(new SpotApi.BitgetRestClientSpotApi(_logger, httpClient, this, options));
            SpotApiV2 = AddApiClient(new SpotApiV2.BitgetRestClientSpotApi(_logger, httpClient, this, options));
            FuturesApi = AddApiClient(new FuturesApi.BitgetRestClientFuturesApi(_logger, httpClient, this, options));
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            SpotApi.SetApiCredentials(credentials);
            FuturesApi.SetApiCredentials(credentials);
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsFunc">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetRestOptions> optionsFunc)
        {
            var options = BitgetRestOptions.Default.Copy();
            optionsFunc(options);
            BitgetRestOptions.Default = options;
        }
    }
}

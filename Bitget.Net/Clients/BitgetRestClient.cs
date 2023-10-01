using Bitget.Net.Clients.FuturesApi;
using Bitget.Net.Clients.SpotApi;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetRestClient : BaseRestClient, IBitgetRestClient
    {
        /// <inheritdoc />
        public IBitgetRestClientSpotApi SpotApi { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesApi FuturesApi { get; }

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

            SpotApi = AddApiClient(new BitgetRestClientSpotApi(_logger, httpClient, this, options));
            FuturesApi = AddApiClient(new BitgetRestClientFuturesApi(_logger, httpClient, this, options));
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

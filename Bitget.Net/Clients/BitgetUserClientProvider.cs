using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetUserClientProvider : UserClientProvider<
        IBitgetRestClient,
        IBitgetSocketClient,
        BitgetRestOptions,
        BitgetSocketOptions,
        BitgetCredentials,
        BitgetEnvironment
        >, IBitgetUserClientProvider
    {
       
        /// <inheritdoc />
        public override string ExchangeName => BitgetExchange.ExchangeName;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="optionsDelegate">Options to use for created clients</param>
        public BitgetUserClientProvider(Action<BitgetOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetUserClientProvider(
            HttpClient? httpClient,
            ILoggerFactory? loggerFactory,
            IOptions<BitgetRestOptions> restOptions,
            IOptions<BitgetSocketOptions> socketOptions):
            base (httpClient, loggerFactory, restOptions, socketOptions)
        {
        }

        /// <inheritdoc />
        protected override IBitgetRestClient ConstructRestClient(HttpClient client, ILoggerFactory? loggerFactory, IOptions<BitgetRestOptions> options)
            => new BitgetRestClient(client, loggerFactory, options);
        /// <inheritdoc />
        protected override IBitgetSocketClient ConstructSocketClient(ILoggerFactory? loggerFactory, IOptions<BitgetSocketOptions> options)
            => new BitgetSocketClient(options, loggerFactory);
    }
}

using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using Bitget.Net.SymbolOrderBooks;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IBitgetRestClient and IBitgetSocketClient. Configures the services based on the provided configuration.<br />
        /// See <see href="https://github.com/JKorf/Bitget.Net/blob/main/Examples/example-config.json" /> for an example of how to set up the configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        /// <returns></returns>
        public static IServiceCollection AddBitget(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = BitgetOptions.CreateFromConfiguration(configuration);

            services.AddSingleton(Options.Options.Create(options.Rest));
            services.AddSingleton(Options.Options.Create(options.Socket));
            services.AddSingleton(Options.Options.Create(options));

            return AddBitgetCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// Add services such as the IBitgetRestClient and IBitgetSocketClient. Services will be configured based on the provided options.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="optionsDelegate">Set options for the Bitget services</param>
        /// <returns></returns>
        public static IServiceCollection AddBitget(
            this IServiceCollection services,
            Action<BitgetOptions>? optionsDelegate = null)
        {
            var options = BitgetOptions.Create(optionsDelegate);

            services.AddSingleton(Options.Options.Create(options.Rest));
            services.AddSingleton(Options.Options.Create(options.Socket));
            services.AddSingleton(Options.Options.Create(options));

            return AddBitgetCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// Add the IBitgetClient and IBitgetSocketClient to the service collection so they can be injected
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="socketClientLifeTime">The lifetime of the IBitgetSocketClient for the service collection. Defaults to Singleton.</param>
        /// <returns></returns>
        private static IServiceCollection AddBitgetCore(
            this IServiceCollection services,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.AddHttpClient<IBitgetRestClient, BitgetRestClient>((client, serviceProvider) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<BitgetRestOptions>>().Value;
                client.Timeout = options.RequestTimeout;
                return new BitgetRestClient(client, serviceProvider.GetRequiredService<ILoggerFactory>(), serviceProvider.GetRequiredService<IOptions<BitgetRestOptions>>());
            }).ConfigurePrimaryHttpMessageHandler((serviceProvider) => {
                var options = serviceProvider.GetRequiredService<IOptions<BitgetRestOptions>>().Value;
                return LibraryHelpers.CreateHttpClientMessageHandler(options);
            }).SetHandlerLifetime(Timeout.InfiniteTimeSpan);
            services.Add(new ServiceDescriptor(typeof(IBitgetSocketClient), x => { return new BitgetSocketClient(x.GetRequiredService<IOptions<BitgetSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()); }, socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddTransient<IBitgetOrderBookFactory, BitgetOrderBookFactory>();
            services.AddTransient<IBitgetTrackerFactory, BitgetTrackerFactory>();
            services.AddTransient<ITrackerFactory, BitgetTrackerFactory>();
            services.AddSingleton<IBitgetUserClientProvider, BitgetUserClientProvider>(x =>
            new BitgetUserClientProvider(
                x.GetRequiredService<IHttpClientFactory>().CreateClient(typeof(IBitgetRestClient).Name),
                x.GetRequiredService<ILoggerFactory>(),
                x.GetRequiredService<IOptions<BitgetRestOptions>>(),
                x.GetRequiredService<IOptions<BitgetSocketOptions>>()));

            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBitgetRestClient>().SpotApiV2.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBitgetSocketClient>().SpotApiV2.SharedClient);
            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBitgetRestClient>().FuturesApiV2.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBitgetSocketClient>().FuturesApiV2.SharedClient);

            services.RegisterSharedApiClient<
                IBitgetSharedApiClient,
                BitgetSharedApiClient>(sharedApis => sharedApis
                    .Add(client => client.SpotRest)
                    .Add(client => client.SpotSocket)
                    .Add(client => client.FuturesRest)
                    .Add(client => client.FuturesSocket)
                    );

            return services;
        }
    }
}

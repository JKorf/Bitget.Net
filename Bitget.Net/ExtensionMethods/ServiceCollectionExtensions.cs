using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using Bitget.Net.SymbolOrderBooks;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IBitgetRestClient and IBitgetSocketClient. Configures the services based on the provided configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        /// <returns></returns>
        public static IServiceCollection AddBitget(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = new BitgetOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            configuration.Bind(options);

            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            var restEnvName = options.Rest.Environment?.Name ?? options.Environment?.Name ?? BitgetEnvironment.Live.Name;
            var socketEnvName = options.Socket.Environment?.Name ?? options.Environment?.Name ?? BitgetEnvironment.Live.Name;
            options.Rest.Environment = BitgetEnvironment.GetEnvironmentByName(restEnvName) ?? options.Rest.Environment!;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = BitgetEnvironment.GetEnvironmentByName(socketEnvName) ?? options.Socket.Environment!;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;


            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

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
            var options = new BitgetOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            optionsDelegate?.Invoke(options);
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment = options.Rest.Environment ?? options.Environment ?? BitgetEnvironment.Live;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = options.Socket.Environment ?? options.Environment ?? BitgetEnvironment.Live;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;

            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddBitgetCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// DEPRECATED; use <see cref="AddBitget(IServiceCollection, Action{BitgetOptions}?)" /> instead
        /// </summary>
        public static IServiceCollection AddBitget(
            this IServiceCollection services,
            Action<BitgetRestOptions> restDelegate,
            Action<BitgetSocketOptions>? socketDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.Configure<BitgetRestOptions>((x) => { restDelegate?.Invoke(x); });
            services.Configure<BitgetSocketOptions>((x) => { socketDelegate?.Invoke(x); });

            return AddBitgetCore(services, socketClientLifeTime);
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
                var handler = new HttpClientHandler();
                try
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;
                }
                catch (PlatformNotSupportedException) { }
                catch (NotImplementedException) { } // Mono runtime throws NotImplementedException for DefaultProxyCredentials setting

                var options = serviceProvider.GetRequiredService<IOptions<BitgetRestOptions>>().Value;
                if (options.Proxy != null)
                {
                    handler.Proxy = new WebProxy
                    {
                        Address = new Uri($"{options.Proxy.Host}:{options.Proxy.Port}"),
                        Credentials = options.Proxy.Password == null ? null : new NetworkCredential(options.Proxy.Login, options.Proxy.Password)
                    };
                }
                return handler;
            });
            services.Add(new ServiceDescriptor(typeof(IBitgetSocketClient), x => { return new BitgetSocketClient(x.GetRequiredService<IOptions<BitgetSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()); }, socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddTransient<ICryptoRestClient, CryptoRestClient>();
            services.AddTransient<ICryptoSocketClient, CryptoSocketClient>();
            services.AddTransient<IBitgetOrderBookFactory, BitgetOrderBookFactory>();
            services.AddTransient<IBitgetTrackerFactory, BitgetTrackerFactory>();

            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBitgetRestClient>().SpotApiV2.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBitgetSocketClient>().SpotApiV2.SharedClient);
            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBitgetRestClient>().FuturesApiV2.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBitgetSocketClient>().FuturesApiV2.SharedClient);

            return services;
        }
    }
}

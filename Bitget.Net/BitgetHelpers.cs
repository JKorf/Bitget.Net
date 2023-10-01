using Bitfinex.Net.SymbolOrderBooks;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net
{
    /// <summary>
    /// Helper functions
    /// </summary>
    public static class BitgetHelpers
    {
        /// <summary>
        /// Add the IBitfinexClient and IBitfinexSocketClient to the sevice collection so they can be injected
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="defaultRestOptionsDelegate">Set default options for the rest client</param>
        /// <param name="defaultSocketOptionsDelegate">Set default options for the socket client</param>
        /// <param name="socketClientLifeTime">The lifetime of the IBitfinexSocketClient for the service collection. Defaults to Singleton.</param>
        /// <returns></returns>
        public static IServiceCollection AddBitget(
            this IServiceCollection services,
            Action<BitgetRestOptions>? defaultRestOptionsDelegate = null,
            Action<BitgetSocketOptions>? defaultSocketOptionsDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            var restOptions = BitgetRestOptions.Default.Copy();

            if (defaultRestOptionsDelegate != null)
            {
                defaultRestOptionsDelegate(restOptions);
                BitgetRestClient.SetDefaultOptions(defaultRestOptionsDelegate);
            }

            if (defaultSocketOptionsDelegate != null)
                BitgetSocketClient.SetDefaultOptions(defaultSocketOptionsDelegate);

            services.AddHttpClient<IBitgetRestClient, BitgetRestClient>(options =>
            {
                options.Timeout = restOptions.RequestTimeout;
            }).ConfigurePrimaryHttpMessageHandler(() => {
                var handler = new HttpClientHandler();
                if (restOptions.Proxy != null)
                {
                    handler.Proxy = new WebProxy
                    {
                        Address = new Uri($"{restOptions.Proxy.Host}:{restOptions.Proxy.Port}"),
                        Credentials = restOptions.Proxy.Password == null ? null : new NetworkCredential(restOptions.Proxy.Login, restOptions.Proxy.Password)
                    };
                }
                return handler;
            });

            services.AddSingleton<IBitgetOrderBookFactory, BitgetOrderBookFactory>();
            services.AddTransient<IBitgetRestClient, BitgetRestClient>();
            //services.AddTransient(x => x.GetRequiredService<IBitgetRestClient>().SpotApi.CommonSpotClient);
            if (socketClientLifeTime == null)
                services.AddSingleton<IBitgetSocketClient, BitgetSocketClient>();
            else
                services.Add(new ServiceDescriptor(typeof(IBitgetSocketClient), typeof(BitgetSocketClient), socketClientLifeTime.Value));
            return services;
        }
    }
}

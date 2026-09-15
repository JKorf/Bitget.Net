using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Configuration;
using System;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget options
    /// </summary>
    public class BitgetOptions : LibraryOptions<BitgetRestOptions, BitgetSocketOptions, BitgetCredentials, BitgetEnvironment>
    {
        /// <summary>
        /// Options for Shared API usage
        /// </summary>
        public SharedApiOptions SharedApi { get; set; } = new();

        /// <summary>
        /// Create options using the provided configuration action
        /// </summary>
        public static BitgetOptions Create(Action<BitgetOptions>? configure = null)
        {
            var options = CreateUnconfigured();
            configure?.Invoke(options);
            return Normalize(options);
        }

        /// <summary>
        /// Create options using the provided configuration
        /// </summary>
        public static BitgetOptions CreateFromConfiguration(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var options = CreateUnconfigured();

            try
            {
                configuration.Bind(options);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Invalid Bitget configuration provided", ex);
            }

            if (options.Environment != null)
                options.Environment = BitgetEnvironment.GetEnvironmentByName(options.Environment.Name) ?? options.Environment;
            if (options.Rest?.Environment != null)
                options.Rest.Environment = BitgetEnvironment.GetEnvironmentByName(options.Rest.Environment.Name) ?? options.Rest.Environment;
            if (options.Socket?.Environment != null)
                options.Socket.Environment = BitgetEnvironment.GetEnvironmentByName(options.Socket.Environment.Name) ?? options.Socket.Environment;

            return Normalize(options);
        }

        private static BitgetOptions CreateUnconfigured()
        {
            var options = new BitgetOptions();
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            return options;
        }

        private static BitgetOptions Normalize(BitgetOptions options)
        {
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment ??= options.Environment ?? BitgetEnvironment.Live;
            options.Rest.ApiCredentials ??= options.ApiCredentials;
            options.Socket.Environment ??= options.Environment ?? BitgetEnvironment.Live;
            options.Socket.ApiCredentials ??= options.ApiCredentials;
            return options;
        }
    }
}

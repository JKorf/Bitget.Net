using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Options
{
    /// <summary>
    /// Bitget options
    /// </summary>
    public class BitgetOptions
    {
        /// <summary>
        /// Rest client options
        /// </summary>
        public BitgetRestOptions Rest { get; set; } = new BitgetRestOptions();

        /// <summary>
        /// Socket client options
        /// </summary>
        public BitgetSocketOptions Socket { get; set; } = new BitgetSocketOptions();

        /// <summary>
        /// Trade environment. Contains info about URL's to use to connect to the API. Use `BitgetEnvironment` to swap environment, for example `Environment = BitgetEnvironment.Live`
        /// </summary>
        public BitgetEnvironment? Environment { get; set; }

        /// <summary>
        /// The api credentials used for signing requests.
        /// </summary>
        public BitgetApiCredentials? ApiCredentials { get; set; }

        /// <summary>
        /// The DI service lifetime for the IBitgetSocketClient
        /// </summary>
        public ServiceLifetime? SocketClientLifeTime { get; set; }
    }
}

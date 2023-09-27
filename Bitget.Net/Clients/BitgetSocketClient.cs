﻿using Bitget.Net.Clients.SpotApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using Microsoft.Extensions.Logging;


namespace Bitget.Net.Clients
{
    public class BitgetSocketClient : BaseSocketClient
    {
        public BitgetSocketClientSpotApi SpotApi { get; set; }

        #region ctor

        /// <summary>
        /// Create a new instance of the BitfinexSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        public BitgetSocketClient(ILoggerFactory? loggerFactory = null) : this((x) => { }, loggerFactory)
        {
        }

        /// <summary>
        /// Create a new instance of the BitfinexSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetSocketClient(Action<BitgetSocketOptions> optionsDelegate) : this(optionsDelegate, null)
        {
        }

        /// <summary>
        /// Create a new instance of the BitfinexSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BitgetSocketClient(Action<BitgetSocketOptions> optionsDelegate, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bitget")
        {
            var options = BitgetSocketOptions.Default.Copy();
            optionsDelegate(options);
            Initialize(options);

            SpotApi = AddApiClient(new BitgetSocketClientSpotApi(_logger, options));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BitgetSocketOptions> optionsDelegate)
        {
            var options = BitgetSocketOptions.Default.Copy();
            optionsDelegate(options);
            BitgetSocketOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(BitgetApiCredentials credentials)
        {
            SpotApi.SetApiCredentials(credentials);
        }
    }
}
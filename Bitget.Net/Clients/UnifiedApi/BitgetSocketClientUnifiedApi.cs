using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using Bitget.Net.Objects.Socket.Queries;
using Bitget.Net.Objects.Socket.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal partial class BitgetSocketClientUnifiedApi : SocketApiClient<BitgetEnvironment, BitgetAuthenticationProviderV2, BitgetCredentials>, IBitgetSocketClientUnifiedApi
    {
        protected override ErrorMapping ErrorMapping => BitgetErrors.SocketErrors;

        #region ctor
        internal BitgetSocketClientUnifiedApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.UnifiedOptions)
        {
            RateLimiter = BitgetExchange.RateLimiter.Websocket;

            RegisterPeriodicQuery(
                "Ping",
                TimeSpan.FromSeconds(30),
                x => new BitgetPingQuery(),
                (connection, result) =>
                {
                    if (result.Error?.ErrorType == ErrorType.Timeout)
                    {
                        // Ping timeout, reconnect
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BitgetSocketUnifiedMessageConverter();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(AccountType type, string symbol, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(type, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(AccountType type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type) },
                        { "topic", "ticker" },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(AccountType type, string symbol, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(type, new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(AccountType type, IEnumerable<string> symbols, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type) },
                        { "topic", "kline" },
                        { "symbol", s },
                        { "interval", EnumConverter.GetString(interval) },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(AccountType type, string symbol, int? limit, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(type, new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(AccountType type, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type) },
                        { "topic", "books" + limit?.ToString()  },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(AccountType type, string symbol, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(type, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(AccountType type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type) },
                        { "topic", "publicTrade"  },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(AccountType type, Action<DataEvent<BitgetUaLiquidationUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), [new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type) },
                        { "topic", "liquidation"  }
                    }],
            null, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BitgetUaAccountUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "account"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitgetUaPositionUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "position"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitgetUaOrder[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "order"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BitgetUaUserTrade[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "fill"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        private async Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(
            string url,
            Dictionary<string, string>[] request,
            IEnumerable<string>? symbols,
            bool authenticated,
            Action<DataEvent<T>> handler,
            CancellationToken ct)
        {
            var subscription = new BitgetSubscription<T>(_logger, this, request, symbols?.ToArray(), handler, authenticated);
            return await SubscribeAsync(url, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override BitgetAuthenticationProviderV2 CreateAuthenticationProvider(BitgetCredentials credentials) 
            => new BitgetAuthenticationProviderV2(credentials);

    }
}

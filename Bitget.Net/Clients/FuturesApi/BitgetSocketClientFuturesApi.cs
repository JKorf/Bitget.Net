using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using Bitget.Net.Objects.Socket.Queries;
using Bitget.Net.Objects.Socket.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bitget.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    internal class BitgetSocketClientFuturesApi : SocketApiClient, IBitgetSocketClientFuturesApi
    {
        private static readonly MessagePath _eventPath = MessagePath.Get().Property("event");
        private static readonly MessagePath _actionPath = MessagePath.Get().Property("action");
        private static readonly MessagePath _instTypePath = MessagePath.Get().Property("arg").Property("instType");
        private static readonly MessagePath _channelPath = MessagePath.Get().Property("arg").Property("channel");
        private static readonly MessagePath _instIdPath = MessagePath.Get().Property("arg").Property("instId");

        internal BitgetSocketClientFuturesApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.FuturesOptions)
        {
            RegisterPeriodicQuery("Ping", TimeSpan.FromSeconds(30), x => new BitgetPingQuery(), null);
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

        /// <inheritdoc />
        public override string GetListenerIdentifier(IMessageAccessor message)
        {
            if (!message.IsJson)
                return "pong";

            var evnt = message.GetValue<string>(_eventPath);
            if (string.Equals(evnt, "login", StringComparison.Ordinal))
                return evnt!;

            var channel = message.GetValue<string>(_channelPath);
            var instType = message.GetValue<string>(_instTypePath);
            var instId = message.GetValue<string>(_instIdPath);
            if (evnt != null)
                return $"{evnt}-{instType?.ToLowerInvariant()}-{channel?.ToLowerInvariant()}-{instId?.ToLowerInvariant()}";

            var action = message.GetValue<string>(_actionPath);
            return $"{action}-{instType?.ToLowerInvariant()}-{channel?.ToLowerInvariant()}-{instId?.ToLowerInvariant()}";
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetFuturesTickerUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "MC" },
                        { "channel", "ticker" },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "MC" },
                        { "channel", "candle" + EnumConverter.GetString(interval) },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetOrderBookUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "MC" },
                        { "channel", "books" },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            limit.ValidateIntValues(nameof(limit), 5, 15);

            var internalHandler = (DataEvent<IEnumerable<BitgetOrderBookUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "MC" },
                        { "channel", "books" + limit },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "MC" },
                        { "channel", "trade" },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesBalanceUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), new [] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(instrumentType) },
                        { "channel", "account" },
                        { "instId", "default" },
                    }
            }, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetPositionUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"),  new [] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(instrumentType) },
                        { "channel", "positions" },
                        { "instId", "default" },
                    }
            }, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), new [] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(instrumentType) },
                        { "channel", "orders" },
                        { "instId", "default" },
                    }
            }, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPlanOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesPlanOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("mix/v1/stream"), new [] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(instrumentType) },
                        { "channel", "ordersAlgo" },
                        { "instId", "default" },
                    }
            }, true, handler, ct).ConfigureAwait(false);
        }

        private async Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(string url, Dictionary<string, string>[] request, bool authenticated, Action<DataEvent<T>> handler, CancellationToken ct)
        {
            var subscription = new BitgetSubscription<T>(_logger, request, handler, authenticated);
            return await SubscribeAsync(url, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override Query GetAuthenticationRequest(SocketConnection connection)
        {
            var time = DateTimeConverter.ConvertToSeconds(DateTime.UtcNow).Value;
            var authProvider = (BitgetAuthenticationProvider)AuthenticationProvider!;
            var signature = authProvider.GetWebsocketSignature(time);

            var socketRequest = new BitgetSocketRequest
            {
                Op = "login",
                Args = new[]
                {
                    new Dictionary<string, string>
                    {
                        { "apiKey", authProvider.ApiKey },
                        { "passphrase", authProvider.Passphrase },
                        { "timestamp", time.ToString() },
                        { "sign", signature },
                    }
                }
            };
            return new BitgetAuthQuery(socketRequest);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);
    }
}

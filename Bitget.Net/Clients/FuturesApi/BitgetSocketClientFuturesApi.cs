﻿using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetSocketClientFuturesApi : SocketApiClient, IBitgetSocketClientFuturesApi
    {
        /// <inheritdoc />
        public override SocketConverter StreamConverter { get; } = new BitgetStreamConverter();

        internal BitgetSocketClientFuturesApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.FuturesOptions)
        {
            DefaultSerializer = JsonSerializer.Create(SerializerOptions.WithConverters);

            SendPeriodic("Ping", TimeSpan.FromSeconds(30), x => "ping");
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
            //var internalHandler = (DataEvent<JToken> data) =>
            //{
            //    var internalData = data.Data["data"]!;
            //    var deserializeResult = Deserialize<T>(internalData);
            //    if (!deserializeResult)
            //    {
            //        _logger.LogWarning("Failed to deserialize update: " + deserializeResult.Error);
            //        return;
            //    }

            //    var instId = data.Data["arg"]?["instId"]?.ToString();
            //    var updateType = data.Data["action"]?.ToString();
            //    handler(data.As(deserializeResult.Data, instId, updateType == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            //};

            var subscription = new BitgetSubscription<T>(_logger, this, request, handler, authenticated);
            return await SubscribeAsync<T>(url, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override Query GetAuthenticationRequest()
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
            return new BitgetAuthRequest(socketRequest);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);
    }
}

using Bitget.Net.Enums;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetSocketClientSpotApi : SocketApiClient
    {
        #region ctor
        internal BitgetSocketClientSpotApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.SpotOptions)
        {
            SendPeriodic("Ping", TimeSpan.FromSeconds(30), x => "ping");

            SetDataInterpreter(null, data =>
            {
                if (data == "pong")
                    return "";
                return data;
            });
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new [] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetTickerUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = symbols.Select(s => new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "ticker" },
                        { "instId", s },
                    }).ToArray()
            }, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = symbols.Select(s => new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "candle" + EnumConverter.GetString(interval) },
                        { "instId", s },
                    }).ToArray()
            }, false, handler, ct).ConfigureAwait(false);
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

            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = symbols.Select(s => new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "books" },
                        { "instId", s },
                    }).ToArray()
            }, false, internalHandler, ct).ConfigureAwait(false);
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

            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = symbols.Select(s => new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "books" + limit },
                        { "instId", s },
                    }).ToArray()
            }, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetTradeUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetTradeUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = symbols.Select(s => new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "trade" },
                        { "instId", s },
                    }).ToArray()
            }, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BitgetBalanceUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = new object[] { new Dictionary<string, object>
                    {
                        { "instType", "spbl" },
                        { "channel", "account" },
                        { "instId", "default" },
                    }
                }
            }, true, handler, ct).ConfigureAwait(false);
        }

        private async Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(string url, object request, bool authenticated, Action<DataEvent<T>> handler, CancellationToken ct)
        {
            var internalHandler = (DataEvent<JToken> data) =>
            {
                var internalData = data.Data["data"]!;
                var deserializeResult = Deserialize<T>(internalData);
                if (!deserializeResult)
                {
                    _logger.LogWarning("Failed to deserialize update: " + deserializeResult.Error);
                    return;
                }

                var instId = data.Data["arg"]?["instId"]?.ToString();
                var updateType = data.Data["action"]?.ToString();
                handler(data.As(deserializeResult.Data, instId, updateType == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            };
            return await SubscribeAsync(url, request, null, authenticated, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
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

            var result = new CallResult<bool>(new ServerError("No response from server"));
            await socketConnection.SendAndWaitAsync(socketRequest, ClientOptions.RequestTimeout, null, 1, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var code = data["code"]?.ToString();
                if (code == null)
                    return false;

                var evnt = data["event"]?.ToString();
                if (code == null)
                    return false;

                if (evnt == "error" && code == "3005")
                {
                    result = new CallResult<bool>(true);
                    return true;
                }

                if (evnt == "login" && code == "0")
                {
                    result = new CallResult<bool>(true);
                    return true;
                }

                return false;
            }).ConfigureAwait(false);

            return result;
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);
        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T> callResult) => throw new NotImplementedException();
        /// <inheritdoc />
        protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request, JToken message, out CallResult<object>? callResult)
        {
            callResult = null;
            if (message.Type != JTokenType.Object)
                return false;

            var op = message["event"];
            if (op == null)
                return false;

            var bRequest = (BitgetSocketRequest)request;
            if (op.ToString() != "subscribe")
                return false;

            var instType = message["arg"]?["instType"]?.ToString();
            var channel = message["arg"]?["channel"]?.ToString();
            var instId = message["arg"]?["instId"]?.ToString();
            if (instType == null || channel == null || instId == null)
                return false;

            var dict = (Dictionary<string, object>)bRequest.Args[0];
            if (!instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            // TODO handle error

            _logger.Log(LogLevel.Trace, $"Socket {socketConnection.SocketId} Subscription completed");
            callResult = new CallResult<object>(new object());
            return true;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var action = message["action"]?.ToString();
            if (action == null)
                return false;

            if (action != "update" && action != "snapshot")
                return false;

            var arg = message["arg"];
            if (arg == null)
                return false;

            var bRequest = (BitgetSocketRequest)request;
            var instType = arg?["instType"]?.ToString();
            var channel = arg?["channel"]?.ToString();
            var instId = arg?["instId"]?.ToString();
            if (instType == null || channel == null || instId == null)
                return false;

            var dicts = bRequest.Args.OfType<Dictionary<string, object>>();
            foreach (var dict in dicts)
            {
                if (instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                    && channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                    && instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier) => throw new NotImplementedException();
        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
        {
            var topics = ((BitgetSocketRequest)subscriptionToUnsub.Request!).Args;
            var unsub = new BitgetSocketRequest { Op = "unsubscribe", Args = topics };
            var result = false;

            if (!connection.Connected)
                return true;

            await connection.SendAndWaitAsync(unsub, ClientOptions.RequestTimeout, null, 1, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;
                
                var evnt = data["event"];
                if (evnt?.ToString() != "unsubscribe")
                    return false;

                var arg = data["arg"];
                if (arg == null)
                    return false;

                var instType = arg?["instType"]?.ToString();
                var channel = arg?["channel"]?.ToString();
                var instId = arg?["instId"]?.ToString();
                if (instType == null || channel == null || instId == null)
                    return false;

                var dict = (Dictionary<string, object>)unsub.Args[0];
                if (!instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                    || !channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                    || !instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                return true;
            }).ConfigureAwait(false);
            return result;
        }
        #endregion
    }
}

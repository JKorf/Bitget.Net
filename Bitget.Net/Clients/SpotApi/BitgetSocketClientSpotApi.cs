using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bitget.Net.Clients.SpotApi
{
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
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetTickerUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("spot/v1/stream"), new BitgetSocketRequest
            {
                Op = "subscribe",
                Args = new object[] { new Dictionary<string, object>
                    {
                        { "instType", "SP" },
                        { "channel", "ticker" },
                        { "instId", symbol },
                    }
                }
            }, false, internalHandler, ct).ConfigureAwait(false);
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

                handler(data.As(deserializeResult.Data));
            };
            return await SubscribeAsync(url, request, null, authenticated, internalHandler, ct);
        }

        /// <inheritdoc />
        protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection) => throw new NotImplementedException();
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
                return false;

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

            var dict = (Dictionary<string, object>)bRequest.Args[0];
            if (!instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
                return false;

            return true;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier) => throw new NotImplementedException();
        /// <inheritdoc />
        protected override Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub) => throw new NotImplementedException();
        #endregion
    }
}

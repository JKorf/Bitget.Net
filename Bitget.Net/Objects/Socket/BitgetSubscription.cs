using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSubscription<T> : SubscriptionActor
    {
        private readonly object[] _args;
        private readonly Action<DataEvent<T>> _handler;

        public BitgetSubscription(ILogger logger, ISocketApiClient socketApiClient, object[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, socketApiClient, authenticated)
        {
            _args = args;
            _handler = handler;
        }

        public override object? GetSubscribeRequest() => new BitgetSocketRequest { Args = _args, Op = "subscribe" };
        public override object? GetUnsubscribeRequest() => new BitgetSocketRequest { Args = _args, Op = "unsubscribe" };

        public override async Task HandleEventAsync(StreamMessage message)
        {
            var deserializeResult = await DeserializeAsync<BitgetSocketUpdate<T>>(message, SerializerOptions.WithConverters).ConfigureAwait(false);
            if (!deserializeResult)
            {
                // TODO
            }

            var dataEvent = CreateDataEvent(deserializeResult.Data.Data, message);
            _handler.Invoke(dataEvent);
            message.Dispose();
        }

        public override bool MessageMatchesSubscription(StreamMessage message)
        {
            var token = message.Get(ParsingUtils.GetJToken);
            if (token.Type != JTokenType.Object)
                return false;

            var action = token["action"]?.ToString();
            if (action == null)
                return false;

            if (action != "update" && action != "snapshot")
                return false;

            var arg = token["arg"];
            if (arg == null)
                return false;

            var instType = arg?["instType"]?.ToString();
            var channel = arg?["channel"]?.ToString();
            var instId = arg?["instId"]?.ToString();
            if (instType == null || channel == null || instId == null)
                return false;

            foreach (Dictionary<string, object> dict in _args)
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

        public override (bool, CallResult?) MessageMatchesSubscribeRequest(StreamMessage message)
        {
            var token = message.Get(ParsingUtils.GetJToken);
            if (token.Type != JTokenType.Object)
                return (false, null);

            var op = token["event"]?.ToString();
            if (op == null)
                return (false, null);

            if (op != "subscribe" && op != "error")
                return (false, null);

            var instType = token["arg"]?["instType"]?.ToString();
            var channel = token["arg"]?["channel"]?.ToString();
            var instId = token["arg"]?["instId"]?.ToString();
            if (instType == null || channel == null || instId == null)
                return (false, null);

            var dict = (Dictionary<string, object>)_args[0];
            if (!instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
            {
                return (false, null);
            }

            if (op == "error")
            {
                _logger.Log(LogLevel.Trace, $"Socket {message.Connection.SocketId} Subscription failed");
                var callResult = new CallResult<object>(new ServerError(token["code"]!.Value<int>(), token["msg"]!.ToString()));
                return (true, callResult);
            }

            _logger.Log(LogLevel.Trace, $"Socket {message.Connection.SocketId} Subscription completed");
            return (true, new CallResult(null));
        }

        public override (bool, CallResult?) MessageMatchesUnsubscribeRequest(StreamMessage message)
        {
            var token = message.Get(ParsingUtils.GetJToken);
            if (token.Type != JTokenType.Object)
                return (false, null);

            var evnt = token["event"];
            if (evnt?.ToString() != "unsubscribe")
                return (false, null);

            var arg = token["arg"];
            if (arg == null)
                return (false, null);

            var instType = arg?["instType"]?.ToString();
            var channel = arg?["channel"]?.ToString();
            var instId = arg?["instId"]?.ToString();
            if (instType == null || channel == null || instId == null)
                return (false, null);

            var dict = (Dictionary<string, object>)_args[0];
            if (!instType.Equals((string)dict["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !channel.Equals((string)dict["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !instId.Equals((string)dict["instId"], StringComparison.InvariantCultureIgnoreCase))
            {
                return (false, null);
            }

            return (true, new CallResult(null));
        }
    }
}

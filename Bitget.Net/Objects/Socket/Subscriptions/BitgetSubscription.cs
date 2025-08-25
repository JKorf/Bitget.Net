using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Objects.Socket.Subscriptions
{
    internal class BitgetSubscription<T> : Subscription<BitgetSocketEvent, BitgetSocketEvent>
    {
        private readonly SocketApiClient _client;
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;

        public BitgetSubscription(ILogger logger, SocketApiClient client, Dictionary<string, string>[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _client = client;
            _args = args;
            _handler = handler;

            MessageMatcher = MessageMatcher.Create<BitgetSocketUpdate<T>>(args.SelectMany(GetIdentifier), DoHandleMessage);
        }

        private string[] GetIdentifier(Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return new[] { $"snapshot-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}", $"update-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}" };

            return new[] { $"snapshot-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-", $"update-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-" };
        }

        protected override Query? GetSubQuery(SocketConnection connection) => new BitgetQuery(_client, new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false) { RequiredResponses = _args.Count() };
        protected override Query? GetUnsubQuery(SocketConnection connection) => new BitgetQuery(_client, new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public CallResult DoHandleMessage(SocketConnection connection, DataEvent<BitgetSocketUpdate<T>> message)
        {
            var symbol = message.Data.Args.InstrumentId;
            _handler.Invoke(message.As(message.Data.Data, message.Data.Args.Channel, symbol == "default" ? null : symbol, string.Equals(message.Data.Action, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(message.Data.Timestamp));
            return CallResult.SuccessResult;
        }

    }
}

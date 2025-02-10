using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Objects.Socket.Subscriptions
{
    internal class BitgetSubscription<T> : Subscription<BitgetSocketEvent, BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BitgetSubscription(ILogger logger, Dictionary<string, string>[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _args = args;
            _handler = handler;
            ListenerIdentifiers = new HashSet<string>(args.SelectMany(GetIdentifier));
        }

        private string[] GetIdentifier(Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return new[] { $"snapshot-{arg["instType"].ToLower()}-{arg["channel"].ToLower()}-{arg["instId"].ToLower()}", $"update-{arg["instType"].ToLower()}-{arg["channel"].ToLower()}-{arg["instId"].ToLower()}" };

            return new[] { $"snapshot-{arg["instType"].ToLower()}-{arg["channel"].ToLower()}-", $"update-{arg["instType"].ToLower()}-{arg["channel"].ToLower()}-" };
        }

        public override Query? GetSubQuery(SocketConnection connection) => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false) { RequiredResponses = _args.Count() };
        public override Query? GetUnsubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public override CallResult DoHandleMessage(SocketConnection connection, DataEvent<object> message)
        {
            var data = (BitgetSocketUpdate<T>)message.Data;
            var symbol = data.Args.InstrumentId;
            _handler.Invoke(message.As(data.Data, data.Args.Channel, symbol == "default" ? null : symbol, string.Equals(data.Action, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(data.Timestamp));
            return new CallResult(null);
        }

        public override Type? GetMessageType(IMessageAccessor message) => typeof(BitgetSocketUpdate<T>);
    }
}

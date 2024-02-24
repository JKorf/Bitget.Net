using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
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
            ListenerIdentifiers = new HashSet<string>(args.SelectMany(a => new[] { $"snapshot-{a["channel"].ToLower()}-{a["instId"].ToLower()}", $"update-{a["channel"].ToLower()}-{a["instId"].ToLower()}" }));
        }

        public override Query? GetSubQuery(SocketConnection connection) => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false);
        public override Query? GetUnsubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public override Task<CallResult> DoHandleMessageAsync(SocketConnection connection, DataEvent<object> message)
        {
            var data = (BitgetSocketUpdate<T>)message.Data;
            _handler.Invoke(message.As(data.Data, data.Args.InstrumentId, data.Action == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            return Task.FromResult(new CallResult(null));
        }

        public override Type? GetMessageType(IMessageAccessor message) => typeof(BitgetSocketUpdate<T>);
    }
}

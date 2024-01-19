using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.SocketsV2;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket.Subscriptions
{
    internal class BitgetSubscription<T> : Subscription<BitgetSocketEvent, BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;
        public override List<string> StreamIdentifiers { get; set; }

        public BitgetSubscription(ILogger logger, Dictionary<string, string>[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _args = args;
            _handler = handler;
            StreamIdentifiers = args.Select(a => $"update-{a["channel"].ToLower()}-{a["instId"].ToLower()}").ToList();
        }


        public override BaseQuery? GetSubQuery(SocketConnection connection) => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false);
        public override BaseQuery? GetUnsubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public override Task<CallResult> DoHandleMessageAsync(SocketConnection connection, DataEvent<object> message)
        {
            var data = (BitgetSocketUpdate<T>)message.Data;
            _handler.Invoke(message.As(data.Data, data.Args.InstrumentId, data.Action == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            return Task.FromResult(new CallResult(null));
        }

        public override Type? GetMessageType(SocketMessage message) => typeof(BitgetSocketUpdate<T>);
    }
}

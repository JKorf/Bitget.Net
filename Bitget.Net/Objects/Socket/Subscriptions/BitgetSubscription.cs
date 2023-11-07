using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Socket.Queries;
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

namespace Bitget.Net.Objects.Socket.Subscriptions
{
    internal class BitgetSubscription<T> : Subscription<BitgetSocketEvent, BitgetSocketUpdate<T>>
    {
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;
        private readonly List<string> _identifiers;
        public override List<string> Identifiers => _identifiers;

        public BitgetSubscription(ILogger logger, Dictionary<string, string>[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _args = args;
            _handler = handler;
            _identifiers = args.Select(a => $"update-{a["channel"]}-{a["instId"]}").ToList();
        }


        public override BaseQuery? GetSubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false);
        public override BaseQuery? GetUnsubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public override async Task<CallResult> HandleEventAsync(DataEvent<ParsedMessage<BitgetSocketUpdate<T>>> message)
        {
            _handler.Invoke(message.As(message.Data.Data.Data, message.Data.Data.Args.InstrumentId, message.Data.Data.Action == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            return new CallResult(null);
        }
    }
}

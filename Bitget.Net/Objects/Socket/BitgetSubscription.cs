using Bitget.Net.Objects.Models;
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
    internal class BitgetSubscription<T> : Subscription<BitgetSocketEvent, BitgetSocketUpdate<T>>
    {
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;
        private readonly List<string> _identifiers;

        public BitgetSubscription(ILogger logger, Dictionary<string, string>[] args, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _args = args;
            _handler = handler;
            _identifiers = args.Select(a => "update" + a["instType"] + a["channel"] + a["instId"]).ToList();
            _identifiers.AddRange(args.Select(a => "snapshot" + a["instType"] + a["channel"] + a["instId"]));
        }

        public override List<string> Identifiers => _identifiers;

        public override BaseQuery? GetSubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false);
        public override BaseQuery? GetUnsubQuery() => new BitgetQuery(new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public override async Task HandleEventAsync(DataEvent<ParsedMessage<BitgetSocketUpdate<T>>> message)
        {
            _handler.Invoke(message.As(message.Data.Data.Data, message.Data.Data.Args.InstrumentId, message.Data.Data.Action == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
        }
    }
}

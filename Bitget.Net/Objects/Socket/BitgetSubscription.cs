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
    internal class BitgetSubscription<T> : Subscription
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

        public override object? GetSubRequest() => new BitgetSocketRequest { Args = _args, Op = "subscribe" };
        public override object? GetUnsubRequest() => new BitgetSocketRequest { Args = _args, Op = "unsubscribe" };

        public override async Task HandleEventAsync(DataEvent<ParsedMessage> message)
        {
            var data = (BitgetSocketUpdate<T>)message.Data.Data;
            _handler.Invoke(message.As(data.Data, data.Args.InstrumentId, data.Action == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
        }

        public override CallResult HandleSubResponse(ParsedMessage message) => new CallResult(null); // TODO check error
        public override CallResult HandleUnsubResponse(ParsedMessage message) => new CallResult(null);// TODO check error

        public override bool MessageMatchesSubRequest(ParsedMessage message)
        {
            if (message.Data is not BitgetSocketEvent socketEvent)
                return false;

            var args = _args[0];
            if (!socketEvent.Args.IntstrumentType.Equals(args["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !socketEvent.Args.Channel.Equals(args["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !socketEvent.Args.InstrumentId.Equals(args["instId"], StringComparison.InvariantCultureIgnoreCase))
                return false;

            return socketEvent.Event == "error" || socketEvent.Event == "subscribe";
        }

        public override bool MessageMatchesUnsubRequest(ParsedMessage message)
        {
            if (message.Data is not BitgetSocketEvent socketEvent)
                return false;

            var args = _args[0];
            if (!socketEvent.Args.IntstrumentType.Equals(args["instType"], StringComparison.InvariantCultureIgnoreCase)
                 || !socketEvent.Args.Channel.Equals(args["channel"], StringComparison.InvariantCultureIgnoreCase)
                 || !socketEvent.Args.InstrumentId.Equals(args["instId"], StringComparison.InvariantCultureIgnoreCase))
                return false;

            return socketEvent.Event == "error" || socketEvent.Event == "subscribe";
        }
    }
}

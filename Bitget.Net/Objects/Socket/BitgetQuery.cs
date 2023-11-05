using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetQuery : Query<BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;

        public BitgetQuery(BitgetSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
        }

        public override bool MessageMatchesQuery(ParsedMessage<BitgetSocketEvent> message)
        {
            var args = _args[0];
            var socketEvent = message.Data!;
            if (!socketEvent.Args.IntstrumentType.Equals(args["instType"], StringComparison.InvariantCultureIgnoreCase)
                || !socketEvent.Args.Channel.Equals(args["channel"], StringComparison.InvariantCultureIgnoreCase)
                || !socketEvent.Args.InstrumentId.Equals(args["instId"], StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return socketEvent.Event == "error" || socketEvent.Event == "subscribe";
        }

        public override CallResult<BitgetSocketEvent> HandleResponse(ParsedMessage<BitgetSocketEvent> message) => new CallResult<BitgetSocketEvent>(message.Data);
    }
}

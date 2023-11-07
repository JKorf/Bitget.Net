using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetQuery : Query<BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;

        public override List<string> Identifiers { get; }

        public BitgetQuery(BitgetSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
            Identifiers = _args.Select(a => $"error-{a["channel"]}-{a["instId"]}").ToList();
            Identifiers.AddRange(_args.Select(a => $"{request.Op}-{a["channel"]}-{a["instId"]}"));
        }
    }
}

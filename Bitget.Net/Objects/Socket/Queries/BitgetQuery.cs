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

        public override List<string> StreamIdentifiers { get; set; }

        public BitgetQuery(BitgetSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
            StreamIdentifiers = _args.Select(a => $"error-{a["channel"].ToLowerInvariant()}-{a["instId"].ToLowerInvariant()}").ToList();
            StreamIdentifiers.AddRange(_args.Select(a => $"{request.Op}-{a["channel"].ToLowerInvariant()}-{a["instId"].ToLowerInvariant()}"));
        }
    }
}

using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetQuery : Query<BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;

        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BitgetQuery(BitgetSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
            ListenerIdentifiers = new HashSet<string>(_args.Select(GetErrorIdentifier));
            foreach(var arg in _args)
                ListenerIdentifiers.Add(GetIdentifier(request.Op, arg));
        }

        private string GetErrorIdentifier(Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return $"error-{arg["instType"].ToLower()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}";

            return $"error-{arg["instType"].ToLower()}-{arg["channel"].ToLowerInvariant()}-";
        }

        private string GetIdentifier(string op, Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return $"{op}-{arg["instType"].ToLower()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}";

            return $"{op}-{arg["instType"].ToLower()}-{arg["channel"].ToLowerInvariant()}-";
        }

        public override CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DataEvent<BitgetSocketEvent> message)
        {
            if (message.Data.Code != null)
                return new CallResult<BitgetSocketEvent>(new ServerError(message.Data.Code.Value, message.Data.Message!), message.OriginalData);

            return base.HandleMessage(connection, message);
        }
    }
}

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
            ListenerIdentifiers = new HashSet<string>(_args.Select(a => $"error-{a["channel"].ToLowerInvariant()}-{a["instId"].ToLowerInvariant()}"));
            foreach(var arg in _args)
                ListenerIdentifiers.Add($"{request.Op}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}");
        }

        public override Task<CallResult<BitgetSocketEvent>> HandleMessageAsync(SocketConnection connection, DataEvent<BitgetSocketEvent> message)
        {
            if (message.Data.Code != null)
                return Task.FromResult(new CallResult<BitgetSocketEvent>(new ServerError(message.Data.Code.Value, message.Data.Message!), message.OriginalData));

            return base.HandleMessageAsync(connection, message);
        }
    }
}

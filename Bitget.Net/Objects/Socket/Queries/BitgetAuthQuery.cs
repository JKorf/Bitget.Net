using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetAuthQuery : Query<BitgetSocketEvent>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; } = new HashSet<string> { "login", "error" };

        public BitgetAuthQuery(BitgetSocketRequest request) : base(request, false)
        {
        }

        public override Task<CallResult<BitgetSocketEvent>> HandleMessageAsync(SocketConnection connection, DataEvent<BitgetSocketEvent> message)
        {
            var evnt = message.Data;
            if (evnt.Code == 0)
                return Task.FromResult(new CallResult<BitgetSocketEvent>(evnt));

            return Task.FromResult(new CallResult<BitgetSocketEvent>(new ServerError(evnt.Code!.Value, evnt.Message!)));
        }
    }
}

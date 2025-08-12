using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetAuthQuery : Query<BitgetSocketEvent>
    {
        private readonly SocketApiClient _client;

        public BitgetAuthQuery(SocketApiClient client, BitgetSocketRequest request) : base(request, false)
        {
            _client = client;
            MessageMatcher = MessageMatcher.Create<BitgetSocketEvent>(["login", "error"], HandleMessage);
        }

        public CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DataEvent<BitgetSocketEvent> message)
        {
            var evnt = message.Data;
            if (evnt.Code == 0)
                return new CallResult<BitgetSocketEvent>(evnt);

            return new CallResult<BitgetSocketEvent>(new ServerError(evnt.Code!.Value.ToString(), _client.GetErrorInfo(evnt.Code!.Value, evnt.Message!)));
        }
    }
}

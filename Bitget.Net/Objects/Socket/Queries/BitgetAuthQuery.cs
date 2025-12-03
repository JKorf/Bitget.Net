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
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BitgetSocketEvent>(["login", "error"], HandleMessage);
        }

        public CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitgetSocketEvent message)
        {
            if (message.Code == 0)
                return new CallResult<BitgetSocketEvent>(message, originalData, null);

            return new CallResult<BitgetSocketEvent>(new ServerError(message.Code!.Value.ToString(), _client.GetErrorInfo(message.Code!.Value, message.Message!)), originalData);
        }
    }
}

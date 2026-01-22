using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetQuery : Query<BitgetSocketEvent>
    {
        private readonly Dictionary<string, string>[] _args;
        private readonly SocketApiClient _client;

        public BitgetQuery(SocketApiClient client, BitgetSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
            _client = client;

            var routes = new List<MessageRoute>();
            foreach (var arg in _args)
            {
                routes.Add(MessageRoute<BitgetSocketEvent>.CreateWithOptionalTopicFilter(
                    $"{request.Op}{arg["instType"]}{arg["channel"]}",
                    GetRouteIdentifier(arg),
                    HandleMessage));
                routes.Add(MessageRoute<BitgetSocketEvent>.CreateWithOptionalTopicFilter(
                    $"error{arg["instType"]}{arg["channel"]}",
                    GetRouteIdentifier(arg),
                    HandleMessage));
            }

            MessageRouter = MessageRouter.Create(routes.ToArray());
        }

        private string? GetRouteIdentifier(Dictionary<string, string> arg)
        {
            return arg.TryGetValue("instId", out var symbol) ? symbol : null;
        }

        public CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitgetSocketEvent message)
        {
            if (message.Code != null)
                return new CallResult<BitgetSocketEvent>(new ServerError(message.Code.Value.ToString(), _client.GetErrorInfo(message.Code.Value, message.Message!)), originalData);

            return new CallResult<BitgetSocketEvent>(message, originalData, null);
        }
    }
}

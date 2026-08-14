using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;

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
                var topic = arg.TryGetValue("channel", out var channel) ? channel : arg["topic"];

                routes.Add(MessageRoute.CreateForQuery<BitgetSocketEvent>(
                    $"{request.Op}{arg["instType"]}{topic}",
                    GetRouteIdentifier(arg),
                    HandleMessage));
                routes.Add(MessageRoute.CreateForQuery<BitgetSocketEvent>(
                    $"error{arg["instType"]}{topic}",
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
                return CallResult<BitgetSocketEvent>.Fail(new ServerError(message.Code.Value.ToString(), _client.GetErrorInfo(message.Code.Value, message.Message!)), originalData);

            return CallResult<BitgetSocketEvent>.Ok(message, originalData);
        }
    }
}

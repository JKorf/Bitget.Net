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
            var checkers = new List<MessageHandlerLink>();
            foreach (var arg in _args)
            {
                checkers.Add(new MessageHandlerLink<BitgetSocketEvent>(GetErrorIdentifier(arg), HandleMessage));
                checkers.Add(new MessageHandlerLink<BitgetSocketEvent>(GetIdentifier(request.Op, arg), HandleMessage));

                routes.Add(MessageRoute<BitgetSocketEvent>.CreateWithOptionalTopicFilter(
                    $"{request.Op}{arg["instType"]}{arg["channel"]}",
                    GetRouteIdentifier(arg),
                    HandleMessage));
            }

            MessageMatcher = MessageMatcher.Create(checkers.ToArray());
            MessageRouter = MessageRouter.Create(routes.ToArray());

        }

        private string? GetRouteIdentifier(Dictionary<string, string> arg)
        {
            return arg.TryGetValue("instId", out var symbol) ? symbol : null;
        }

        private string GetErrorIdentifier(Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return $"error-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}";

            return $"error-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-";
        }

        private string GetIdentifier(string op, Dictionary<string, string> arg)
        {
            if (arg.ContainsKey("instId"))
                return $"{op}-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}";

            return $"{op}-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-";
        }

        public CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitgetSocketEvent message)
        {
            if (message.Code != null)
                return new CallResult<BitgetSocketEvent>(new ServerError(message.Code.Value.ToString(), _client.GetErrorInfo(message.Code.Value, message.Message!)), originalData);

            return new CallResult<BitgetSocketEvent>(message, originalData, null);
        }
    }
}

﻿using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

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

            var checkers = new List<MessageHandlerLink>();
            foreach(var arg in _args)
            {
                checkers.Add(new MessageHandlerLink<BitgetSocketEvent>(GetErrorIdentifier(arg), HandleMessage));
                checkers.Add(new MessageHandlerLink<BitgetSocketEvent>(GetIdentifier(request.Op, arg), HandleMessage));
            }

            MessageMatcher = MessageMatcher.Create(checkers.ToArray());

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

        public CallResult<BitgetSocketEvent> HandleMessage(SocketConnection connection, DataEvent<BitgetSocketEvent> message)
        {
            if (message.Data.Code != null)
                return new CallResult<BitgetSocketEvent>(new ServerError(message.Data.Code.Value.ToString(), _client.GetErrorInfo(message.Data.Code.Value, message.Data.Message!)), message.OriginalData);

            return message.ToCallResult();
        }
    }
}

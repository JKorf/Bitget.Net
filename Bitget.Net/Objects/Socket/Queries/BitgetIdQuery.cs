using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetIdQuery<TResponse> : Query<TResponse>
    {
        private readonly Parameters[] _args;
        private readonly SocketApiClient _client;

        public BitgetIdQuery(SocketApiClient client, BitgetIdSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        {
            _args = request.Args;
            _client = client;

            MessageRouter = MessageRouter.CreateForQuery<BitgetSocketResponse<TResponse>, TResponse>(request.Id, HandleMessage);
        }

        public CallResult<TResponse> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitgetSocketResponse<TResponse> message)
        {
            if (message.Code != null)
                return CallResult<TResponse>.Fail(new ServerError(message.Code.Value.ToString(), _client.GetErrorInfo(message.Code.Value, message.Message!)), originalData);

            return CallResult<TResponse>.Ok(message.Data, originalData);
        }
    }
}

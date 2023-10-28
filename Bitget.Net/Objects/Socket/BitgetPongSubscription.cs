using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetPongSubscription : SystemSubscription
    {
        public BitgetPongSubscription(ILogger logger, ISocketApiClient socketApiClient) : base(logger, socketApiClient)
        {
        }

        public override List<string> Identifiers => null;

        public override Task HandleEventAsync(StreamMessage message)
        {
            _logger.LogDebug($"Socket {message.Connection.SocketId} received pong message");
            return Task.CompletedTask;
        }

        public override bool MessageMatchesEvent(StreamMessage message)
        {
            if (message.Stream.Length != 4)
                return false;

            return message.Get(ParsingUtils.GetString) == "pong";
        }
    }
}

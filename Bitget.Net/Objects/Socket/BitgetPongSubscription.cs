using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    public class BitgetPongSubscription : SystemSubscription
    {
        public BitgetPongSubscription(ILogger logger, ISocketApiClient socketApiClient) : base(logger, socketApiClient)
        {
        }

        public override Task HandleEventAsync(StreamMessage message)
        {
            _logger.LogDebug($"Socket {message.Connection.SocketId} received pong message");
            return Task.CompletedTask;
        }

        public override bool MessageMatchesSubscription(StreamMessage message)
        {
            if (message.Stream.Length != 4)
                return false;

            return message.Get(ParsingUtils.GetString) == "pong";
        }
    }
}

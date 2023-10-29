//using CryptoExchange.Net;
//using CryptoExchange.Net.Converters;
//using CryptoExchange.Net.Interfaces;
//using CryptoExchange.Net.Objects.Sockets;
//using CryptoExchange.Net.Sockets;
//using Microsoft.Extensions.Logging;

//namespace Bitget.Net.Objects.Socket
//{
//    internal class BitgetPongSubscription : SystemSubscription
//    {
//        public BitgetPongSubscription(ILogger logger, ISocketApiClient socketApiClient) : base(logger, socketApiClient)
//        {
//        }

//        public override List<string> Identifiers => null;

//        public override Task HandleEventAsync(DataEvent<ParsedMessage> message)
//        {
//            //_logger.LogDebug($"Socket {message.Connection.SocketId} received pong message");
//            return Task.CompletedTask;
//        }
//    }
//}

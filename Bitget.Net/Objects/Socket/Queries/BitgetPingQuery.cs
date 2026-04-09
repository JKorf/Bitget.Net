using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetPingQuery : Query<string>
    {
        public BitgetPingQuery() : base("ping", false, 0)
        {
            RequestTimeout = TimeSpan.FromSeconds(5);
            MessageRouter = MessageRouter.CreateWithoutHandler<string>("pong");
        }
    }
}

using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetPingQuery : Query<string>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; } = new HashSet<string> { "pong" };

        public BitgetPingQuery() : base("ping", false, 0)
        {
        }
    }
}

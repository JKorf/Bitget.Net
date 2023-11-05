using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetPingQuery : Query<string>
    {
        public override List<string> Identifiers => new List<string>();

        public BitgetPingQuery() : base("ping", false, 0)
        {
        }
    }
}

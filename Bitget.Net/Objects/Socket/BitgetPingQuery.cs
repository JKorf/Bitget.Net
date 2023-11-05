using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetPingQuery : Query<string>
    {
        public BitgetPingQuery() : base("ping", false, 0)
        {
        }

        public override bool MessageMatchesQuery(ParsedMessage<string> message) => message.Data == "pong";
        public override CallResult<string> HandleResponse(ParsedMessage<string> message) => new CallResult<string>(message.Data);
    }
}

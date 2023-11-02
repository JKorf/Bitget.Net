using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetAuthRequest : Query
    {
        public BitgetAuthRequest(BitgetSocketRequest request) : base(request, false)
        {
        }

        public override CallResult HandleResult(ParsedMessage message)
        {
            var evnt = (BitgetSocketEvent)message.Data;
            if (evnt.Code == 0)
                return new CallResult<object>(null);

            return new CallResult<object>(new ServerError(evnt.Code!.Value, evnt.Message));
        }

        public override bool MessageMatchesQuery(ParsedMessage message)
        {
            if (message.Data is not BitgetSocketEvent evnt)
                return false;

            return evnt.Event == "login" || evnt.Event == "error";
        }
    }
}

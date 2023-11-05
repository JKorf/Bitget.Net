using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetAuthRequest : Query<BitgetSocketEvent>
    {
        public BitgetAuthRequest(BitgetSocketRequest request) : base(request, false)
        {
        }

        public override CallResult<BitgetSocketEvent> HandleResponse(ParsedMessage<BitgetSocketEvent> message)
        {
            var evnt = message.Data;
            if (evnt.Code == 0)
                return new CallResult<BitgetSocketEvent>(message.Data);

            return new CallResult<BitgetSocketEvent>(new ServerError(evnt.Code!.Value, evnt.Message));
        }

        public override bool MessageMatchesQuery(ParsedMessage<BitgetSocketEvent> message)
        {
            if (message.Data is not BitgetSocketEvent evnt)
                return false;

            return evnt.Event == "login" || evnt.Event == "error";
        }
    }
}

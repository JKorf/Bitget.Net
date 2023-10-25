using CryptoExchange.Net;
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

        public override CallResult HandleResponse(StreamMessage message)
        {
            var token = message.Get(ParsingUtils.GetJToken);
            var evnt = token["event"]!.ToString();
            var code = token["code"]!.ToString();
            if (evnt == "login" && code == "0")
                return new CallResult(null);

            return new CallResult(new ServerError("Login failed"));
        }

        public override bool MessageMatchesQuery(StreamMessage message)
        {
            var token = message.Get(ParsingUtils.GetJToken);
            if (token.Type != JTokenType.Object)
                return false;

            var code = token["code"]?.ToString();
            if (code == null)
                return false;

            var evnt = token["event"]?.ToString();
            if (code == null)
                return false;

            if (evnt == "error" && code == "30005")
                return true;

            if (evnt == "login")
                return true;

            return false;
        }
    }
}

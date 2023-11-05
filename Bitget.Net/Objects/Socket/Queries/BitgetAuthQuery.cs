using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Objects.Socket.Queries
{
    internal class BitgetAuthQuery : Query<BitgetSocketEvent>
    {
        public override List<string> Identifiers { get; } = new List<string> { "login", "error" };

        public BitgetAuthQuery(BitgetSocketRequest request) : base(request, false)
        {
            Identifiers = new List<string>();
        }

        public override Task<CallResult<BitgetSocketEvent>> HandleMessageAsync(DataEvent<ParsedMessage<BitgetSocketEvent>> message)
        {
            var evnt = message.Data.Data;
            if (evnt.Code == 0)
                return Task.FromResult(new CallResult<BitgetSocketEvent>(message.Data.Data));

            return Task.FromResult(new CallResult<BitgetSocketEvent>(new ServerError(evnt.Code!.Value, evnt.Message)));
        }
    }
}

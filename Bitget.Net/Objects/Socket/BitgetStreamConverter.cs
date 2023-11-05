using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    public class BitgetStreamConverter : SocketConverter
    {
        public override string[] TypeIdFields { get; } = new string[]
        {
            "event",
            "action",
            "arg:instType",
            "arg:channel",
            "arg:instId"
        };

        private readonly Dictionary<string, Type> _channelTypeMap = new Dictionary<string, Type>()
        {
            { "ticker", typeof(BitgetSocketUpdate<IEnumerable<BitgetTickerUpdate>>) },
            { "trade", typeof(BitgetSocketUpdate<IEnumerable<BitgetTradeUpdate>>) },
        };

        public override Type? GetDeserializationType(Dictionary<string, string> idValues, List<BasePendingRequest> pendingRequests, List<Subscription> listeners)
        {
            if (idValues["event"] == "subscribe" || idValues["event"] == "unsubscribe")
                return typeof(BitgetSocketEvent);

            if (idValues["action"] == null)
                return null;

            if (_channelTypeMap.TryGetValue(idValues["arg:channel"], out var type))
                return type;

            return null;
        }
    }
}

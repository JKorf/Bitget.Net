using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects.Sockets;
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

        public override Type? GetDeserializationType(Dictionary<string, string> idValues, List<MessageListener> listeners)
        {
            if (idValues["event"] == "subscribe" || idValues["event"] == "unsubscribe")
                return typeof(BitgetSocketEvent);

            if (idValues["action"] == null)
                return null;

            //if (args["arg:channel"] == "ticker")
            //    return typeof(BitgetTickerUpdate);

            if (idValues["arg:channel"] == "trade")
                return typeof(BitgetSocketUpdate<IEnumerable<BitgetTradeUpdate>>);

            return null;
        }
    }
}

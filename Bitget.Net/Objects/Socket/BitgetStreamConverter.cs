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
        private static readonly Dictionary<string, Type> _channelTypeMap = new Dictionary<string, Type>()
        {
            { "ticker", typeof(BitgetSocketUpdate<IEnumerable<BitgetTickerUpdate>>) },
            { "trade", typeof(BitgetSocketUpdate<IEnumerable<BitgetTradeUpdate>>) },
        };

        public override List<StreamMessageParseCallback> InterpreterPipeline { get; } = new List<StreamMessageParseCallback>
        {
            new StreamMessageParseCallback
            {
                TypeFields = new List<string> { "event" },
                IdFields = new List<string> { "event", "arg:instType", "arg:channel", "arg:instId" },
                Callback = GetDeserializationTypeEvent
            },
            new StreamMessageParseCallback
            {
                TypeFields = new List<string> { "action", "arg:channel"  },
                IdFields = new List<string> { "action", "arg:instType", "arg:channel", "arg:instId" },
                Callback = GetDeserializationTypeStream
            }
        };

        public static Type? GetDeserializationTypeEvent(Dictionary<string, string> idValues, IEnumerable<BasePendingRequest> pendingRequests, IEnumerable<Subscription> listeners)
        {
            return typeof(BitgetSocketEvent);
        }

        public static Type? GetDeserializationTypeStream(Dictionary<string, string> idValues, IEnumerable<BasePendingRequest> pendingRequests, IEnumerable<Subscription> listeners)
        {
            if (idValues["action"] == null)
                return null;

            if (_channelTypeMap.TryGetValue(idValues["arg:channel"], out var type))
                return type;

            return null;
        }
    }
}

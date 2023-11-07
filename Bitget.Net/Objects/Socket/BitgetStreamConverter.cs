using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
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

        public override MessageInterpreterPipeline InterpreterPipeline { get; } = new MessageInterpreterPipeline
        {
            PreInspectCallbacks = new List<PreInspectCallback>
            {
                new PreInspectCallback
                {
                    Callback = PreInspectForPong
                }
            },
            PostInspectCallbacks = new List<PostInspectCallback>
            {
                new PostInspectCallback
                {
                    TypeFields = new List<string> { "event", "arg:channel", "arg:instId"  },
                    Callback = GetDeserializationTypeEvent
                },
                new PostInspectCallback
                {
                    TypeFields = new List<string> { "action", "arg:channel", "arg:instId"  },
                    Callback = GetDeserializationTypeStream
                }
            }
        };

        public static PreInspectResult? PreInspectForPong(Stream stream)
        {
            return new PreInspectResult
            {
                Matched = stream.Length == 4,
                Identifier = "pong"
            };
        }

        public static PostInspectResult GetDeserializationTypeEvent(Dictionary<string, string> idValues, IDictionary<string, IMessageProcessor> processors)
        {
            return new PostInspectResult
            {
                Identifier = $"{idValues["event"]}-{idValues["arg:channel"]}-{idValues["arg:instId"].ToLowerInvariant()}",
                Type = typeof(BitgetSocketEvent)
            };
        }

        public static PostInspectResult GetDeserializationTypeStream(Dictionary<string, string> idValues, IDictionary<string, IMessageProcessor> processors)
        {
            if (idValues["action"] == null)
                return new PostInspectResult();

            if (_channelTypeMap.TryGetValue(idValues["arg:channel"], out var type))
            {
                return new PostInspectResult
                {
                    Identifier = $"update-{idValues["arg:channel"]}-{idValues["arg:instId"].ToLowerInvariant()}",
                    Type = type
                };
            }

            return new PostInspectResult();
        }
    }
}

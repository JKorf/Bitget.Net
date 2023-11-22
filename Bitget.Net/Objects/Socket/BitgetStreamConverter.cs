using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
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
            GetIdentity = GetIdentity,

            //PostInspectCallbacks = new List<object>
            //{
            //    new PostInspectCallback
            //    {
            //        TypeFields = new List<TypeField> 
            //        { 
            //            new TypeField("event"),
            //            new TypeField("arg:channel"),
            //            new TypeField("arg:instId") 
            //        },
            //        Callback = GetDeserializationTypeEvent
            //    },
            //    new PostInspectCallback
            //    {
            //        TypeFields = new List<TypeField> 
            //        { 
            //            new TypeField("action"),
            //            new TypeField("arg:channel"),
            //            new TypeField("arg:instId")
            //        },
            //        Callback = GetDeserializationTypeStream
            //    }
            //}
        };

        private static string GetIdentity(IMessageAccessor accessor)
        {
            var evnt = accessor.GetStringValue("event");
            var channel = accessor.GetStringValue("arg:channel");
            var instId = accessor.GetStringValue("arg:instId");
            if (evnt != null)
                return $"{accessor.GetStringValue("event")}-{channel.ToLowerInvariant()}-{instId.ToLowerInvariant()}";

            return $"update-{channel.ToLowerInvariant()}-{instId.ToLowerInvariant()}";
        }

        public static PreInspectResult? PreInspectForPong(Stream stream)
        {
            return new PreInspectResult
            {
                Matched = stream.Length == 4,
                Identifier = "pong"
            };
        }

        public static PostInspectResult GetDeserializationTypeEvent(IMessageAccessor accessor, Dictionary<string, Type> processors)
        {
            return new PostInspectResult
            {
                Identifier = $"{accessor.GetStringValue("event")}-{accessor.GetStringValue("arg:channel").ToLowerInvariant()}-{accessor.GetStringValue("arg:instId").ToLowerInvariant()}",
                Type = typeof(BitgetSocketEvent)
            };
        }

        public static PostInspectResult GetDeserializationTypeStream(IMessageAccessor accessor, Dictionary<string, Type> processors)
        {
            if (accessor.GetStringValue("action") == null)
                return new PostInspectResult();

            if (_channelTypeMap.TryGetValue(accessor.GetStringValue("arg:channel").ToLowerInvariant(), out var type))
            {
                return new PostInspectResult
                {
                    Identifier = $"update-{accessor.GetStringValue("arg:channel").ToLowerInvariant()}-{accessor.GetStringValue("arg:instId").ToLowerInvariant()}",
                    Type = type
                };
            }

            return new PostInspectResult();
        }
    }
}

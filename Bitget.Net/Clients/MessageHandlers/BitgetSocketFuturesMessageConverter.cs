using Bitget.Net.Objects.Socket;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text.Json;

namespace Bitget.Net.Clients.MessageHandlers
{
    internal class BitgetSocketFuturesMessageConverter : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BitgetExchange._serializerContext);

        public BitgetSocketFuturesMessageConverter()
        {
            AddTopicMapping<BitgetSocketEvent>(x => x.Args?.InstrumentId);
            AddTopicMapping<BitgetSocketUpdate>(x => x.Args.InstrumentId);
        }

        protected override MessageEvaluator[] TypeEvaluators { get; } = [

            new MessageEvaluator {
                Priority = 1,
                Fields = [
                    new PropertyFieldReference("event"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("event")}{x.FieldValue("instType")}{x.FieldValue("channel")}"
            },

            new MessageEvaluator {
                Priority = 2,
                Fields = [
                    new PropertyFieldReference("action") { Constraint = x => x!.Equals("snapshot") || x!.Equals("update") },
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("instType")}{x.FieldValue("channel")}"
            },


            new MessageEvaluator {
                Priority = 5,
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("event") { Constraint = x => x!.Equals("login", StringComparison.Ordinal) },
                ],
                StaticIdentifier = "login",
            },

            new MessageEvaluator {
                Priority = 6,
                Fields = [
                    new PropertyFieldReference("event") { Constraint = x => x!.Equals("error", StringComparison.Ordinal) },
                ],
                StaticIdentifier = "error",
            },
        ];

        public override string? GetTypeIdentifier(ReadOnlySpan<byte> data, WebSocketMessageType? webSocketMessageType)
        {
            if (data.Length == 4)
                return "pong";

            return base.GetTypeIdentifier(data, webSocketMessageType);
        }
    }
}

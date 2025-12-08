using Bitget.Net.Objects.Socket;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using System.Net.WebSockets;
using System.Text.Json;

namespace Bitget.Net.Clients.MessageHandlers
{
    internal class BitgetSocketSpotMessageConverter : JsonSocketMessageHandler
    {
        private static readonly HashSet<string?> _typeUpdates = new HashSet<string?>()
        {
            "snapshot",
            "update"
        };

        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BitgetExchange._serializerContext);

        public BitgetSocketSpotMessageConverter()
        {
            AddTopicMapping<BitgetSocketEvent>(x => x.Args?.InstrumentId);
            AddTopicMapping<BitgetSocketUpdate>(x => x.Args.InstrumentId);
        }

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("event"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                ],
                TypeIdentifierCallback = x => $"{x.FieldValue("event")}{x.FieldValue("instType")}{x.FieldValue("channel")}"
            },

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("action").WithFilterContstraint(_typeUpdates),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                ],
                TypeIdentifierCallback = x => $"{x.FieldValue("instType")}{x.FieldValue("channel")}"
            },


            new MessageTypeDefinition {
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("event").WithEqualContstraint("login"),
                ],
                StaticIdentifier = "login",
            },

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("event").WithEqualContstraint("error"),
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

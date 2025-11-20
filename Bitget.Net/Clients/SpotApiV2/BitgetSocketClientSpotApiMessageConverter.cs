using Bitget.Net;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text.Json;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal class BitgetSocketClientSpotApiMessageConverter : DynamicJsonConverter
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BitgetExchange._serializerContext);

        protected override MessageEvaluator[] MessageEvaluators { get; } = [

            new MessageEvaluator {
                Priority = 1,
                Fields = [
                    new PropertyFieldReference("action"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                    new PropertyFieldReference("instId") { Depth = 2 }
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("action").ToLowerInvariant()}-{x.FieldValue("instType").ToLowerInvariant()}-{x.FieldValue("channel").ToLowerInvariant()}-{x.FieldValue("instId").ToLowerInvariant()}"
            },

            new MessageEvaluator {
                Priority = 2,
                Fields = [
                    new PropertyFieldReference("event"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                    new PropertyFieldReference("instId") { Depth = 2 },
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("event").ToLowerInvariant()}-{x.FieldValue("instType").ToLowerInvariant()}-{x.FieldValue("channel").ToLowerInvariant()}-{x.FieldValue("instId").ToLowerInvariant()}"
            },

            new MessageEvaluator {
                Priority = 3,
                Fields = [
                    new PropertyFieldReference("action"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 }
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("action").ToLowerInvariant()}-{x.FieldValue("instType").ToLowerInvariant()}-{x.FieldValue("channel").ToLowerInvariant()}-"
            },

            new MessageEvaluator {
                Priority = 4,
                Fields = [
                    new PropertyFieldReference("event"),
                    new PropertyFieldReference("instType") { Depth = 2 },
                    new PropertyFieldReference("channel") { Depth = 2 },
                ],
                IdentifyMessageCallback = x => $"{x.FieldValue("event").ToLowerInvariant()}-{x.FieldValue("instType").ToLowerInvariant()}-{x.FieldValue("channel").ToLowerInvariant()}-"
            },

            new MessageEvaluator {
                Priority = 5,
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("event") { Constraint = x => x.Equals("login", StringComparison.Ordinal) },
                ],
                StaticIdentifier = "login",
            },

            new MessageEvaluator {
                Priority = 6,
                Fields = [
                    new PropertyFieldReference("event") { Constraint = x => x.Equals("error", StringComparison.Ordinal) },
                ],
                StaticIdentifier = "error",
            },
        ];

        public override string? GetMessageIdentifier(ReadOnlySpan<byte> data, WebSocketMessageType? webSocketMessageType)
        {
            if (data.Length == 4)
                return "pong";

            return base.GetMessageIdentifier(data, webSocketMessageType);
        }
    }
}

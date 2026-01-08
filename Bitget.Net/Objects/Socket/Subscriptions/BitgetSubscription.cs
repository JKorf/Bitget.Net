using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Objects.Socket.Subscriptions
{
    internal class BitgetSubscription<T> : Subscription
    {
        private readonly SocketApiClient _client;
        private readonly Dictionary<string, string>[] _args;
        private readonly Action<DataEvent<T>> _handler;

        public BitgetSubscription(ILogger logger, SocketApiClient client, Dictionary<string, string>[] args, string[]? symbols, Action<DataEvent<T>> handler, bool authenticated) : base(logger, authenticated)
        {
            _client = client;
            _args = args;
            _handler = handler;

            IndividualSubscriptionCount = args.Length;

            MessageMatcher = MessageMatcher.Create<BitgetSocketUpdate<T>>(args.SelectMany(GetIdentifier), DoHandleMessage);
            MessageRouter = MessageRouter.CreateWithOptionalTopicFilters<BitgetSocketUpdate<T>>(args.Select(GetRouteParams), symbols, DoHandleMessage);
        }

        private string GetRouteParams(Dictionary<string, string> arg)
        {
            return $"{arg["instType"]}{arg["channel"]}";
        }

        private string[] GetIdentifier(Dictionary<string, string> arg)
        {
            var result = new List<string>
            {
                $"snapshot-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-",
                $"update-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-"
            };

            if (arg.ContainsKey("instId"))
            {
                result.Add($"snapshot-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}");
                result.Add($"update-{arg["instType"].ToLowerInvariant()}-{arg["channel"].ToLowerInvariant()}-{arg["instId"].ToLowerInvariant()}");
            }

            return result.ToArray();
        }

        protected override Query? GetSubQuery(SocketConnection connection) => new BitgetQuery(_client, new BitgetSocketRequest { Args = _args, Op = "subscribe" }, false) { RequiredResponses = _args.Count() };
        protected override Query? GetUnsubQuery(SocketConnection connection) => new BitgetQuery(_client, new BitgetSocketRequest { Args = _args, Op = "unsubscribe" }, false);

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitgetSocketUpdate<T> message)
        {
            _client.UpdateTimeOffset(message.Timestamp);

            _handler?.Invoke(
                new DataEvent<T>(BitgetExchange.ExchangeName, message.Data, receiveTime, originalData)
                    .WithUpdateType(string.Equals(message.Action, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithSymbol(message.Args.InstrumentId)
                    .WithStreamId(message.Args.Channel)
                    .WithDataTimestamp(message.Timestamp, _client.GetTimeOffset())
                );
            return CallResult.SuccessResult;
        }

    }
}

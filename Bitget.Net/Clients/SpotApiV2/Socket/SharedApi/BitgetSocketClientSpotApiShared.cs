using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetSocketClientSpotSharedApi :
        SharedApiBase,
        IBitgetSocketClientSpotApiShared,
        IBitgetSocketClientSpotSharedApi
    {
        private readonly BitgetSocketClientSpotApi _api;

        private const string _topicId = "BitgetSpot";
        private const string _exchangeName = "Bitget";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);

        public BitgetSocketClientSpotSharedApi(BitgetSocketClientSpotApi api)
            : base(
                  SharedTransport.Socket,
                  api.Exchange,
                  new[] { TradingMode.Spot },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                SubscribeTickerOptions,
                SubscribeTradeOptions,
                SubscribeBookTickerOptions,
                SubscribeBalanceOptions,
                SubscribeSpotOrderOptions,
                SubscribeUserTradeOptions,
                SubscribeKlineOptions,
                SubscribeOrderBookOptions
                );
        }
    }
}

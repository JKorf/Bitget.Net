using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetSocketClientFuturesSharedApi :
        SharedApiBase,
        IBitgetSocketClientFuturesApiShared,
        IBitgetSocketClientFuturesSharedApi
    {
        private readonly BitgetSocketClientFuturesApi _api;

        private const string _topicId = "BitgetFutures";
        private const string _exchangeName = "Bitget";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);

        public BitgetSocketClientFuturesSharedApi(BitgetSocketClientFuturesApi api)
            : base(
                  SharedTransport.Socket,
                  api.Exchange,
                  new[] { TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                SubscribeTickerOptions,
                SubscribeTradeOptions,
                SubscribeBookTickerOptions,
                SubscribeBalanceOptions,
                SubscribeKlineOptions,
                SubscribeOrderBookOptions,
                SubscribeFuturesOrderOptions,
                SubscribeUserTradeOptions,
                SubscribePositionOptions
                );
        }

        private BitgetProductTypeV2 GetProductType(TradingMode? tradingMode, ExchangeParameters? exchangeParameters)
        {
            if (tradingMode == TradingMode.PerpetualInverse || tradingMode == TradingMode.DeliveryInverse)
            {
                return BitgetProductTypeV2.CoinFutures;
            }

            var productTypeStr = ExchangeParameters.GetValue<string>(exchangeParameters, Exchange, "ProductType");
            return (BitgetProductTypeV2)Enum.Parse(typeof(BitgetProductTypeV2), productTypeStr!);
        }
    }
}

using Bitget.Net.Clients.UnifiedApi;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetSocketClientUnifiedSharedApi :
        SharedApiBase,
        IBitgetSocketClientUnifiedSharedApi
    {
        private readonly BitgetSocketClientUnifiedApi _api;

        private const string _topicSpotId = "BitgetUnifiedSpot";
        private const string _topicFuturesId = "BitgetUnifiedFutures";
        private const string _exchangeName = "Bitget";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);

        public BitgetSocketClientUnifiedSharedApi(BitgetSocketClientUnifiedApi api)
            : base(
                  SharedTransport.Socket,
                  api,
                  new[] { TradingMode.Spot, TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                SubscribeTickerOptions
                );
        }

        /// <inheritdoc />
        public Task UnsubscribeAllAsync() => _api.UnsubscribeAllAsync();

        private ProductCategory GetCategory(SharedRequest request)
        {
            if (request.TradingMode == TradingMode.Spot)
                return ProductCategory.Spot;

            var category = request.GetParamValue<ProductCategory?>(Exchange, "ProductCategory");
            return category ?? ProductCategory.UsdtFutures;
        }
    }
}

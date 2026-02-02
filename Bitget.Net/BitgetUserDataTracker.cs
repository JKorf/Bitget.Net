using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.UserData;
using Microsoft.Extensions.Logging;

namespace Bitget.Net
{
    public class BitgetUserSpotDataTracker : UserSpotDataTracker
    {
        public BitgetUserSpotDataTracker(
            ILogger<BitgetUserSpotDataTracker> logger,
            IBitgetRestClient restClient,
            IBitgetSocketClient socketClient,
            string? userIdentifier,
            UserDataTrackerConfig config) : base(logger, restClient.SpotApiV2.SharedClient, socketClient.SpotApiV2.SharedClient, userIdentifier, config)
        {
        }
    }

    public class BitgetUserFuturesDataTracker : UserFuturesDataTracker
    {
        protected override bool WebsocketPositionUpdatesAreFullSnapshots => false;

        public BitgetUserFuturesDataTracker(
            ILogger<BitgetUserFuturesDataTracker> logger,
            IBitgetRestClient restClient,
            IBitgetSocketClient socketClient,
            string? userIdentifier,
            UserDataTrackerConfig config,
            ExchangeParameters exchangeParameters) : base(logger, restClient.FuturesApiV2.SharedClient, socketClient.FuturesApiV2.SharedClient, userIdentifier, config, exchangeParameters)
        {
        }
    }
}

using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.UserData;
using CryptoExchange.Net.Trackers.UserData.Objects;
using Microsoft.Extensions.Logging;

namespace Bitget.Net
{
    /// <inheritdoc />
    public class BitgetUserSpotDataTracker : UserSpotDataTracker
    {
        /// <summary>
        /// ctor
        /// </summary>
        public BitgetUserSpotDataTracker(
            ILogger<BitgetUserSpotDataTracker> logger,
            IBitgetRestClient restClient,
            IBitgetSocketClient socketClient,
            string? userIdentifier,
            SpotUserDataTrackerConfig config) : base(
                logger,
                restClient.SpotApiV2.SharedClient,
                null,
                restClient.SpotApiV2.SharedClient,
                socketClient.SpotApiV2.SharedClient,
                restClient.SpotApiV2.SharedClient,
                socketClient.SpotApiV2.SharedClient,
                socketClient.SpotApiV2.SharedClient,
                userIdentifier,
                config)
        {
        }
    }

    /// <inheritdoc />
    public class BitgetUserFuturesDataTracker : UserFuturesDataTracker
    {
        /// <inheritdoc />
        protected override bool WebsocketPositionUpdatesAreFullSnapshots => false;

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetUserFuturesDataTracker(
            ILogger<BitgetUserFuturesDataTracker> logger,
            IBitgetRestClient restClient,
            IBitgetSocketClient socketClient,
            string? userIdentifier,
            FuturesUserDataTrackerConfig config,
            ExchangeParameters exchangeParameters) : base(logger,
                restClient.FuturesApiV2.SharedClient,
                null,
                restClient.FuturesApiV2.SharedClient,
                socketClient.FuturesApiV2.SharedClient,
                restClient.FuturesApiV2.SharedClient,
                socketClient.FuturesApiV2.SharedClient,
                socketClient.FuturesApiV2.SharedClient,
                socketClient.FuturesApiV2.SharedClient,
                userIdentifier,
                config)
        {
        }
    }
}

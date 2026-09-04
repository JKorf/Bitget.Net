using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;

namespace Bitget.Net.Clients
{
    /// <inheritdoc />
    public class BitgetSharedApiClient : IBitgetSharedApiClient
    {
        /// <inheritdoc />
        public IBitgetRestClientSpotSharedApi SpotRest { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesSharedApi FuturesRest { get; }
        /// <inheritdoc />
        public IBitgetSocketClientSpotSharedApi SpotSocket { get; }
        /// <inheritdoc />
        public IBitgetSocketClientFuturesSharedApi FuturesSocket { get; }

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetSharedApiClient(
            IBitgetRestClient restClient,
            IBitgetSocketClient socketClient)
        {
            SpotRest = restClient.SpotApiV2.SharedApi;
            FuturesRest = restClient.FuturesApiV2.SharedApi;
            SpotSocket = socketClient.SpotApiV2.SharedApi;
            FuturesSocket = socketClient.FuturesApiV2.SharedApi;
        }
    }
}

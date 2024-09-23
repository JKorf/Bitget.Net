using CryptoExchange.Net.SharedApis.Interfaces.Rest;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Shared interface for Spot rest API usage
    /// </summary>
    public interface IBitgetRestClientSpotApiShared :
        IAssetsRestClient,
        IBalanceRestClient,
        IDepositRestClient,
        IKlineRestClient,
        IOrderBookRestClient,
        IRecentTradeRestClient,
        ISpotOrderRestClient,
        ISpotSymbolRestClient,
        ISpotTickerRestClient,
        ITradeHistoryRestClient,
        IWithdrawalRestClient,
        IWithdrawRestClient
    {
    }
}

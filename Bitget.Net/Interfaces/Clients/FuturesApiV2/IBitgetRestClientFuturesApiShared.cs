using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Shared interface for Spot rest API usage
    /// </summary>
    public interface IBitgetRestClientFuturesApiShared :
        IBalanceRestClient,
        IFuturesTickerRestClient,
        IFuturesSymbolRestClient,
        IKlineRestClient,
        IRecentTradeRestClient,
        ILeverageRestClient,
        IMarkPriceKlineRestClient,
        IIndexPriceKlineRestClient,
        IOrderBookRestClient,
        IOpenInterestRestClient,
        IFundingRateRestClient,
        IFuturesOrderRestClient,
        IPositionModeRestClient,
        IPositionHistoryRestClient
    {
    }
}

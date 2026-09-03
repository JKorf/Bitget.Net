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
        IPositionHistoryRestClient,
        IFeeRestClient,
        IFuturesOrderClientIdRestClient,
        IFuturesTriggerOrderRestClient,
        IFuturesTpSlRestClient,
        IBookTickerRestClient
    {
    }

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBitgetRestClientFuturesSharedApi :
        IGetBalancesRest,
        IGetFuturesTickerRest,
        IGetAllFuturesTickersRest,
        IGetFuturesSymbolsRest,
        IGetKlinesRest,
        IGetRecentTradesRest,
        IGetLeverageRest,
        ISetLeverageRest,
        IGetMarkPriceKlinesRest,
        IGetIndexPriceKlinesRest,
        IGetOrderBookRest,
        IGetOpenInterestRest,
        IGetFundingRateHistoryRest,
        IPlaceFuturesOrderRest,
        IGetFuturesOrderRest,
        IGetOpenFuturesOrdersRest,
        IGetClosedFuturesOrdersRest,
        IGetFuturesOrderTradesRest,
        IGetFuturesUserTradeHistoryRest,
        IGetPositionsRest,
        IClosePositionRest,
        ICancelFuturesOrderRest,
        IGetPositionModeRest,
        ISetPositionModeRest,
        IGetPositionHistoryRest,
        IGetFeesRest,
        IGetFuturesOrderByClientOrderIdRest,
        ICancelFuturesOrderByClientOrderIdRest,
        IPlaceFuturesTriggerOrderRest,
        IGetFuturesTriggerOrderRest,
        ICancelFuturesTriggerOrderRest,
        ISetFuturesTpSlRest,
        ICancelFuturesTpSlRest,
        IGetBookTickerRest
    { }
}

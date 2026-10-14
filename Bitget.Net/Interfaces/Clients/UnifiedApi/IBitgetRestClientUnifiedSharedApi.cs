using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBitgetRestClientUnifiedSharedApi
        : IGetTickerRest,
        IGetAllTickersRest,
        IGetBalancesRest,
        IGetDepositAddressesRest,
        IGetDepositHistoryRest,
        IGetFeesRest,
        IGetFundingInfoRest,
        IGetFundingRateHistoryRest,
        IGetIndexPriceRest,
        IGetAllIndexPricesRest,
        IGetMarkPriceRest,
        IGetAllMarkPricesRest,
        IGetKlinesRest,
        IGetMarkPriceKlinesRest,
        IGetIndexPriceKlinesRest,
        IGetLedgerRest,
        IGetLeverageRest,
        ISetLeverageRest,
        IGetOpenInterestRest,
        IGetBookTickerRest,
        IGetOrderBookRest,
        IGetPositionModeRest,
        ISetPositionModeRest,
        IGetFuturesSymbolsRest,
        IGetSpotSymbolsRest,
        IGetRecentTradesRest,
        IGetWithdrawalHistoryRest,
        IWithdrawRest,

        IPlaceSpotOrderRest,
        IGetSpotOrderRest,
        IGetOpenSpotOrdersRest,
        IGetClosedSpotOrdersRest,
        ICancelSpotOrderRest,
        IGetSpotOrderByClientOrderIdRest,
        ICancelSpotOrderByClientOrderIdRest,
        IGetSpotUserTradeHistoryRest,
        IGetSpotOrderTradesRest,
        ICancelAllSpotOrdersRest,
        ICancelAllSpotSymbolOrdersRest,
        IEditSpotOrderRest,
        IEditSpotOrderByClientOrderIdRest,

        IPlaceFuturesOrderRest,
        IGetFuturesOrderRest,
        IGetOpenFuturesOrdersRest,
        IGetClosedFuturesOrdersRest,
        ICancelFuturesOrderRest,
        IGetFuturesOrderByClientOrderIdRest,
        ICancelFuturesOrderByClientOrderIdRest,
        IGetFuturesUserTradeHistoryRest,
        IGetFuturesOrderTradesRest,
        ICancelAllFuturesOrdersRest,
        ICancelAllFuturesSymbolOrdersRest,
        IEditFuturesOrderRest,
        IEditFuturesOrderByClientOrderIdRest,
        ICloseFullPositionRest,
        IGetPositionsRest,
        IGetPositionHistoryRest,
        ISetFuturesTpSlRest,
        ICancelFuturesTpSlRest
    {        
    }
}

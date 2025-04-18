using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Socket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Converters
{
    [JsonSerializable(typeof(IDictionary<string, object>))]
    [JsonSerializable(typeof(BitgetFuturesPlaceOrderRequest[]))]
    [JsonSerializable(typeof(BitgetPlaceOrderRequest[]))]
    [JsonSerializable(typeof(BitgetCancelOrderRequest[]))]
    [JsonSerializable(typeof(BitgetReplaceOrderRequest[]))]

    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetTradeUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesKlineUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesBalanceUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetPositionUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesUserTradeUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesOrderUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesTriggerOrderUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetPositionHistoryUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetKlineUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetIndexPriceUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetOrderUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetUserTradeUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetTriggerOrderUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetBalanceUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetCrossAccountUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetMarginOrderUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetIsolatedAccountUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetTickerUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetOrderBookUpdate[]>))]
    [JsonSerializable(typeof(BitgetSocketUpdate<BitgetFuturesTickerUpdate[]>))]

    // End manual defined attributes

    [JsonSerializable(typeof(BitgetResponse<BitgetCurrentFundingRate[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesAdlRank[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossBorrowHistory>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossRepayHistory>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossInterest>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossLiquidation>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossFinancial>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossOrder>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossUserTrade>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetCrossLiquidationOrder>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetIsolatedBorrowHistory>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetIsolatedRepayHistory>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetIsolatedInterest>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetIsolatedLiquidation>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMinMaxResult<BitgetIsolatedFinancial>>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCopyTradingSymbolSettings[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesBalance[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetContract[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetVipFeeRate[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesTicker[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetTrade[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesKline[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFundingTime[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesPrices[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFundingRate[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetPositionTier[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetPosition[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetTriggerSubOrder[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetBalance[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetAssetValue[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetSpotBalance[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetSpotLedgerEntry[]>))]
    [JsonSerializable(typeof(BitgetResponse<string[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetTransferRecord[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetWithdrawalRecord[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetDepositRecord[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetSubAccountBalances[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetSubAccountTransfer[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetAsset[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetSymbol[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetTicker[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetKline[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetMarginSymbol[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossBalance[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossInterestLimit[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossTierConfig[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossFlashRepayStatus[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderResult[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedBalance[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedRiskRate[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedInterestLimit[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedTierConfig[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedFlashRepayResult[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderIdResult[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrder[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetUserTrade[]>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesBalance>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetPositionLeverage>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetPositionMode>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesLedger>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetServerTime>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesOrderBook>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOpenInterestResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetPositionHistory>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderId>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderMultipleResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesOrder>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesOrders>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesUserTrades>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetFuturesTriggerOrders>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetUserFee>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetAccountInfo>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetTransferResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetWithdrawResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetBgbDeduct>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetDepositAddress>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderBook>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossBorrowResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossRepayResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossRiskRate>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossMaxBorrowable>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossMaxTransferable>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetCrossFlashRepayResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedBorrowResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedRepayResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedMaxBorrowable>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetIsolatedMaxTransferable>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderIdResult>))]
    [JsonSerializable(typeof(BitgetResponse<BitgetOrderList>))]
    [JsonSerializable(typeof(IDictionary<string, object>))]    
    [JsonSerializable(typeof(BitgetAccountInfo[]))]
    [JsonSerializable(typeof(BitgetAssetNetwork[]))]
    [JsonSerializable(typeof(BitgetBgbDeduct[]))]
    [JsonSerializable(typeof(BitgetCrossBorrowHistory[]))]
    [JsonSerializable(typeof(BitgetCrossBorrowResult[]))]
    [JsonSerializable(typeof(BitgetCrossFinancial[]))]
    [JsonSerializable(typeof(BitgetCrossFlashRepayResult[]))]
    [JsonSerializable(typeof(BitgetCrossInterest[]))]
    [JsonSerializable(typeof(BitgetCrossInterestLimitVip[]))]
    [JsonSerializable(typeof(BitgetCrossLiquidation[]))]
    [JsonSerializable(typeof(BitgetCrossLiquidationOrder[]))]
    [JsonSerializable(typeof(BitgetCrossMaxBorrowable[]))]
    [JsonSerializable(typeof(BitgetCrossMaxTransferable[]))]
    [JsonSerializable(typeof(BitgetCrossOrder[]))]
    [JsonSerializable(typeof(BitgetCrossOrderRequest[]))]
    [JsonSerializable(typeof(BitgetCrossRepayHistory[]))]
    [JsonSerializable(typeof(BitgetCrossRepayResult[]))]
    [JsonSerializable(typeof(BitgetCrossRiskRate[]))]
    [JsonSerializable(typeof(BitgetCrossUserTrade[]))]
    [JsonSerializable(typeof(BitgetDepositAddress[]))]
    [JsonSerializable(typeof(BitgetFuturesLedger[]))]
    [JsonSerializable(typeof(BitgetFuturesLedgerEntry[]))]
    [JsonSerializable(typeof(BitgetFuturesOrders[]))]
    [JsonSerializable(typeof(BitgetFuturesOrder[]))]
    [JsonSerializable(typeof(BitgetFuturesOrderBook[]))]
    [JsonSerializable(typeof(BitgetFuturesTriggerOrders[]))]
    [JsonSerializable(typeof(BitgetFuturesTriggerOrder[]))]
    [JsonSerializable(typeof(BitgetFuturesUserTrades[]))]
    [JsonSerializable(typeof(BitgetFuturesUserTrade[]))]
    [JsonSerializable(typeof(BitgetIsolatedBorrowHistory[]))]
    [JsonSerializable(typeof(BitgetIsolatedBorrowResult[]))]
    [JsonSerializable(typeof(BitgetIsolatedFinancial[]))]
    [JsonSerializable(typeof(BitgetIsolatedInterest[]))]
    [JsonSerializable(typeof(BitgetIsolatedInterestLimitVip[]))]
    [JsonSerializable(typeof(BitgetIsolatedInterestLimitQuote[]))]
    [JsonSerializable(typeof(BitgetIsolatedLiquidation[]))]
    [JsonSerializable(typeof(BitgetIsolatedMaxBorrowable[]))]
    [JsonSerializable(typeof(BitgetIsolatedMaxTransferable[]))]
    [JsonSerializable(typeof(BitgetIsolatedRepayHistory[]))]
    [JsonSerializable(typeof(BitgetIsolatedRepayResult[]))]
    [JsonSerializable(typeof(BitgetOpenInterestResult[]))]
    [JsonSerializable(typeof(BitgetOpenInterest[]))]
    [JsonSerializable(typeof(BitgetOrderFees[]))]
    [JsonSerializable(typeof(BitgetOrderNewFees[]))]
    [JsonSerializable(typeof(BitgetOrderBook[]))]
    [JsonSerializable(typeof(BitgetOrderBookEntry[]))]
    [JsonSerializable(typeof(BitgetOrderId[]))]
    [JsonSerializable(typeof(BitgetOrderList[]))]
    [JsonSerializable(typeof(BitgetOrderMultipleResult[]))]
    [JsonSerializable(typeof(BitgetPlaceFailure[]))]
    [JsonSerializable(typeof(BitgetOrderUpdateFee[]))]
    [JsonSerializable(typeof(BitgetPositionHistory[]))]
    [JsonSerializable(typeof(BitgetPositionHistoryEntry[]))]
    [JsonSerializable(typeof(BitgetPositionLeverage[]))]
    [JsonSerializable(typeof(BitgetPositionMode[]))]
    [JsonSerializable(typeof(BitgetServerTime[]))]
    [JsonSerializable(typeof(BitgetSubAccountBalance[]))]
    [JsonSerializable(typeof(BitgetTransferResult[]))]
    [JsonSerializable(typeof(BitgetTriggerOrder[]))]
    [JsonSerializable(typeof(BitgetUserFee[]))]
    [JsonSerializable(typeof(BitgetTradeFee[]))]
    [JsonSerializable(typeof(BitgetUserTradeFee[]))]
    [JsonSerializable(typeof(BitgetWithdrawResult[]))]
    [JsonSerializable(typeof(BitgetResponse))]
    [JsonSerializable(typeof(BitgetSocketEvent))]
    [JsonSerializable(typeof(BitgetSocketRequest))]
    [JsonSerializable(typeof(int?))]
    [JsonSerializable(typeof(int))]
    [JsonSerializable(typeof(long?))]
    [JsonSerializable(typeof(long))]
    [JsonSerializable(typeof(decimal?))]
    [JsonSerializable(typeof(decimal))]
    [JsonSerializable(typeof(DateTime))]
    [JsonSerializable(typeof(DateTime?))]
    internal partial class BitgetSourceGenerationContext : JsonSerializerContext
    {
    }
}

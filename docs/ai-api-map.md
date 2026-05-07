# Bitget.Net AI API Quick Map

Use this file to route common user intents to the correct Bitget.Net client member. If a method name or parameter is not listed here, inspect `Bitget.Net/Interfaces/Clients/**` before generating code.

## Client Roots

| Intent | Use |
|---|---|
| REST calls | `new BitgetRestClient()` |
| WebSocket streams | `new BitgetSocketClient()` |
| API key authentication | `options.ApiCredentials = new BitgetCredentials("key", "secret", "passPhrase")` |
| Live environment | `BitgetEnvironment.Live` |
| Dependency injection | `services.AddBitget(options => { ... })` |
| Spot REST | `client.SpotApiV2` |
| Futures REST | `client.FuturesApiV2` |
| Copy trading futures REST | `client.CopyTradingFuturesV2` |
| Broker REST on concrete client | `client.BrokerV2` |
| Spot WebSocket | `socketClient.SpotApiV2` |
| Futures WebSocket | `socketClient.FuturesApiV2` |
| Spot shared REST | `client.SpotApiV2.SharedClient` |
| Futures shared REST | `client.FuturesApiV2.SharedClient` |
| Spot shared socket | `socketClient.SpotApiV2.SharedClient` |
| Futures shared socket | `socketClient.FuturesApiV2.SharedClient` |

## Symbols, Product Types And Enums

| Concept | Use |
|---|---|
| Spot symbol | `BTCUSDT`, `ETHUSDT`, `BGBUSDT` |
| Futures symbol | `BTCUSDT`, `ETHUSDT` |
| USDT futures product type | `BitgetProductTypeV2.UsdtFutures` |
| COIN futures product type | `BitgetProductTypeV2.CoinFutures` |
| USDC futures product type | `BitgetProductTypeV2.UsdcFutures` |
| Demo USDT futures product type | `BitgetProductTypeV2.SimUsdtFutures` |
| Futures margin asset | `"USDT"` |
| Spot REST kline interval | `Bitget.Net.Enums.V2.KlineInterval.OneMinute` |
| Futures REST kline interval | `BitgetFuturesKlineInterval.OneMinute` |
| Socket kline interval | `BitgetStreamKlineIntervalV2.OneMinute` |
| V2 order enums | `Bitget.Net.Enums.V2.OrderSide`, `OrderType`, `TimeInForce`, `MarginMode`, `TradeSide` |

## Spot Exchange Data REST

| User intent | Bitget.Net member |
|---|---|
| Get spot server time | `client.SpotApiV2.ExchangeData.GetServerTimeAsync()` |
| Get announcements | `client.SpotApiV2.ExchangeData.GetAnnouncementsAsync(...)` |
| Get asset metadata | `client.SpotApiV2.ExchangeData.GetAssetsAsync("USDT")` |
| Get symbols | `client.SpotApiV2.ExchangeData.GetSymbolsAsync("BTCUSDT")` |
| Get VIP fee rates | `client.SpotApiV2.ExchangeData.GetVipFeeRatesAsync()` |
| Get spot ticker(s) | `client.SpotApiV2.ExchangeData.GetTickersAsync("BTCUSDT")` |
| Get spot order book | `client.SpotApiV2.ExchangeData.GetOrderBookAsync("BTCUSDT", limit: 20)` |
| Get spot klines | `client.SpotApiV2.ExchangeData.GetKlinesAsync("BTCUSDT", KlineInterval.OneMinute)` |
| Get historical spot klines | `client.SpotApiV2.ExchangeData.GetHistoricalKlinesAsync("BTCUSDT", KlineInterval.OneMinute, endTime)` |
| Get recent spot trades | `client.SpotApiV2.ExchangeData.GetRecentTradesAsync("BTCUSDT")` |
| Get historical spot trades | `client.SpotApiV2.ExchangeData.GetTradesAsync("BTCUSDT", ...)` |

## Spot Account REST

| User intent | Bitget.Net member |
|---|---|
| Get funding balances | `client.SpotApiV2.Account.GetFundingBalancesAsync()` |
| Get spot balances | `client.SpotApiV2.Account.GetSpotBalancesAsync()` |
| Get trade fee | `client.SpotApiV2.Account.GetTradeFeeAsync("BTCUSDT", BitgetBusinessType.Spot)` |
| Get account info | `client.SpotApiV2.Account.GetAccountInfoAsync()` |
| Get asset valuation | `client.SpotApiV2.Account.GetAssetsValuationAsync()` |
| Set deposit account | `client.SpotApiV2.Account.SetDepositAccountAsync("USDT", AccountType.Spot)` |
| Get ledger | `client.SpotApiV2.Account.GetLedgerAsync("USDT")` |
| Transfer between accounts | `client.SpotApiV2.Account.TransferAsync("USDT", fromAccount, toAccount, quantity)` |
| Get transferable assets | `client.SpotApiV2.Account.GetTransferableAssetsAsync(fromAccount, toAccount)` |
| Withdraw | `client.SpotApiV2.Account.WithdrawAsync("USDT", TransferType.OnChain, address, quantity, network: "TRX")` |
| Get transfer history | `client.SpotApiV2.Account.GetTransferHistoryAsync("USDT")` |
| Enable/disable BGB fee deduction | `client.SpotApiV2.Account.SetBgbDeductEnabledAsync(true)` |
| Get BGB fee deduction status | `client.SpotApiV2.Account.GetBgbDeductEnabledAsync()` |
| Get deposit address | `client.SpotApiV2.Account.GetDepositAddressAsync("USDT", network: "TRX")` |
| Cancel withdrawal | `client.SpotApiV2.Account.CancelWithdrawalAsync(withdrawalOrderId)` |
| Get withdrawal history | `client.SpotApiV2.Account.GetWithdrawalHistoryAsync(startTime, endTime, asset: "USDT")` |
| Get deposit history | `client.SpotApiV2.Account.GetDepositHistoryAsync(startTime, endTime, asset: "USDT")` |
| Transfer subaccount assets | `client.SpotApiV2.Account.TransferSubAccountAsync(...)` |
| Get subaccount balances | `client.SpotApiV2.Account.GetSubAccountBalancesAsync(...)` |
| Get subaccount transfer history | `client.SpotApiV2.Account.GetSubAccountTransferHistoryAsync(...)` |
| Get subaccount deposit address | `client.SpotApiV2.Account.GetSubAccountDepositAddressAsync(subAccountId, "USDT")` |
| Get subaccount deposit history | `client.SpotApiV2.Account.GetSubAccountDepositHistoryAsync(subAccountId, asset: "USDT")` |

## Spot Trading REST

| User intent | Bitget.Net member |
|---|---|
| Place spot order | `client.SpotApiV2.Trading.PlaceOrderAsync("BTCUSDT", OrderSide.Buy, OrderType.Limit, quantity, TimeInForce.GoodTillCanceled, price)` |
| Place multiple spot orders | `client.SpotApiV2.Trading.PlaceMultipleOrdersAsync("BTCUSDT", orders)` |
| Cancel/replace spot order | `client.SpotApiV2.Trading.CancelReplaceOrderAsync(orderId, null, "BTCUSDT", quantity, price)` |
| Cancel/replace multiple spot orders | `client.SpotApiV2.Trading.CancelReplaceMultipleOrdersAsync(orders)` |
| Cancel spot order | `client.SpotApiV2.Trading.CancelOrderAsync("BTCUSDT", orderId: orderId)` |
| Cancel multiple spot orders | `client.SpotApiV2.Trading.CancelMultipleOrdersAsync("BTCUSDT", orders)` |
| Cancel all spot orders by symbol | `client.SpotApiV2.Trading.CancelOrdersBySymbolAsync("BTCUSDT")` |
| Get spot order | `client.SpotApiV2.Trading.GetOrderAsync("BTCUSDT", orderId: orderId)` |
| Get open spot orders | `client.SpotApiV2.Trading.GetOpenOrdersAsync("BTCUSDT")` |
| Get closed spot orders | `client.SpotApiV2.Trading.GetClosedOrdersAsync("BTCUSDT")` |
| Get spot user trades | `client.SpotApiV2.Trading.GetUserTradesAsync("BTCUSDT")` |
| Place spot trigger order | `client.SpotApiV2.Trading.PlaceTriggerOrderAsync(...)` |
| Edit spot trigger order | `client.SpotApiV2.Trading.EditTriggerOrderAsync(...)` |
| Cancel spot trigger order | `client.SpotApiV2.Trading.CancelTriggerOrderAsync(...)` |
| Cancel all spot trigger orders | `client.SpotApiV2.Trading.CancelAllTriggerOrdersAsync(...)` |
| Get open spot trigger orders | `client.SpotApiV2.Trading.GetOpenTriggerOrdersAsync("BTCUSDT")` |
| Get trigger suborders | `client.SpotApiV2.Trading.GetTriggerSubOrdersAsync(triggerOrderId)` |
| Get closed spot trigger orders | `client.SpotApiV2.Trading.GetClosedTriggerOrdersAsync("BTCUSDT", startTime, endTime)` |

## Spot Margin REST

| User intent | Bitget.Net member |
|---|---|
| Get margin symbols | `client.SpotApiV2.Margin.GetMarginSymbolsAsync()` |
| Get interest rates | `client.SpotApiV2.Margin.GetInterestRatesAsync("USDT")` |
| Get cross borrow history | `client.SpotApiV2.Margin.GetCrossBorrowHistoryAsync(...)` |
| Get cross repay history | `client.SpotApiV2.Margin.GetCrossRepayHistoryAsync(...)` |
| Get cross interest history | `client.SpotApiV2.Margin.GetCrossInterestHistoryAsync("USDT")` |
| Get cross liquidation history | `client.SpotApiV2.Margin.GetCrossLiquidationHistoryAsync(...)` |
| Get cross financial history | `client.SpotApiV2.Margin.GetCrossFinancialHistoryAsync(...)` |
| Get cross balances | `client.SpotApiV2.Margin.GetCrossBalancesAsync("USDT")` |
| Cross borrow | `client.SpotApiV2.Margin.CrossBorrowAsync("USDT", quantity, clientOrderId)` |
| Cross repay | `client.SpotApiV2.Margin.CrossRepayAsync("USDT", quantity)` |
| Get cross risk rate | `client.SpotApiV2.Margin.GetCrossRiskRateAsync()` |
| Get cross max borrowable | `client.SpotApiV2.Margin.GetCrossMaxBorrowableAsync("USDT")` |
| Get cross max transferable | `client.SpotApiV2.Margin.GetCrossMaxTransferableAsync("USDT")` |
| Get cross interest and limit | `client.SpotApiV2.Margin.GetCrossInterestAndLimitAsync("USDT")` |
| Get cross tier config | `client.SpotApiV2.Margin.GetCrossTierConfigAsync("USDT")` |
| Cross flash repay | `client.SpotApiV2.Margin.CrossFlashRepayAsync("USDT")` |
| Get cross flash repay status | `client.SpotApiV2.Margin.GetCrossFlashRepayStatusAsync(ids)` |
| Place cross margin order | `client.SpotApiV2.Margin.PlaceCrossOrderAsync(...)` |
| Cancel cross margin order | `client.SpotApiV2.Margin.CancelCrossOrderAsync("BTCUSDT", orderId)` |
| Get cross open orders | `client.SpotApiV2.Margin.GetCrossOpenOrdersAsync("BTCUSDT")` |
| Get cross closed orders | `client.SpotApiV2.Margin.GetCrossClosedOrdersAsync("BTCUSDT")` |
| Get cross user trades | `client.SpotApiV2.Margin.GetCrossUserTradesAsync("BTCUSDT")` |
| Get isolated borrow history | `client.SpotApiV2.Margin.GetIsolatedBorrowHistoryAsync(...)` |
| Get isolated repay history | `client.SpotApiV2.Margin.GetIsolatedRepayHistoryAsync(...)` |
| Get isolated interest history | `client.SpotApiV2.Margin.GetIsolatedInterestHistoryAsync(...)` |
| Get isolated balances | `client.SpotApiV2.Margin.GetIsolatedBalancesAsync()` |
| Isolated borrow | `client.SpotApiV2.Margin.IsolatedBorrowAsync("USDT", quantity, clientOrderId)` |
| Isolated repay | `client.SpotApiV2.Margin.IsolatedRepayAsync("USDT", quantity)` |
| Get isolated risk rate | `client.SpotApiV2.Margin.GetIsolatedRiskRateAsync()` |
| Get isolated interest and limit | `client.SpotApiV2.Margin.GetIsolatedInterestAndLimitAsync("BTCUSDT")` |
| Get isolated tier config | `client.SpotApiV2.Margin.GetIsolatedTierConfigAsync("BTCUSDT")` |
| Get isolated max borrowable | `client.SpotApiV2.Margin.GetIsolatedMaxBorrowableAsync("BTCUSDT")` |
| Get isolated max transferable | `client.SpotApiV2.Margin.GetIsolatedMaxTransferableAsync("BTCUSDT")` |
| Place isolated margin order | `client.SpotApiV2.Margin.PlaceIsolatedOrderAsync(...)` |
| Cancel isolated margin order | `client.SpotApiV2.Margin.CancelIsolatedOrderAsync("BTCUSDT", orderId)` |
| Get isolated open orders | `client.SpotApiV2.Margin.GetIsolatedOpenOrdersAsync("BTCUSDT")` |
| Get isolated closed orders | `client.SpotApiV2.Margin.GetIsolatedClosedOrdersAsync("BTCUSDT")` |
| Get isolated user trades | `client.SpotApiV2.Margin.GetIsolatedUserTradesAsync("BTCUSDT")` |

## Futures Exchange Data REST

| User intent | Bitget.Net member |
|---|---|
| Get futures server time | `client.FuturesApiV2.ExchangeData.GetServerTimeAsync()` |
| Get contracts | `client.FuturesApiV2.ExchangeData.GetContractsAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get futures VIP fee rates | `client.FuturesApiV2.ExchangeData.GetVipFeeRatesAsync()` |
| Get futures order book | `client.FuturesApiV2.ExchangeData.GetOrderBookAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", limit: 20)` |
| Get futures ticker | `client.FuturesApiV2.ExchangeData.GetTickerAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get futures tickers | `client.FuturesApiV2.ExchangeData.GetTickersAsync(BitgetProductTypeV2.UsdtFutures)` |
| Get futures recent trades | `client.FuturesApiV2.ExchangeData.GetRecentTradesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get futures historical trades | `client.FuturesApiV2.ExchangeData.GetTradesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get futures klines | `client.FuturesApiV2.ExchangeData.GetKlinesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", BitgetFuturesKlineInterval.OneMinute)` |
| Get historical futures klines | `client.FuturesApiV2.ExchangeData.GetHistoricalKlinesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", BitgetFuturesKlineInterval.OneMinute)` |
| Get index price klines | `client.FuturesApiV2.ExchangeData.GetHistoricalIndexPriceKlinesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", BitgetFuturesKlineInterval.OneMinute)` |
| Get mark price klines | `client.FuturesApiV2.ExchangeData.GetHistoricalMarkPriceKlinesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", BitgetFuturesKlineInterval.OneMinute)` |
| Get open interest | `client.FuturesApiV2.ExchangeData.GetOpenInterestAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get next funding time | `client.FuturesApiV2.ExchangeData.GetNextFundingTimeAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get prices | `client.FuturesApiV2.ExchangeData.GetPricesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get funding rate | `client.FuturesApiV2.ExchangeData.GetFundingRateAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get all funding rates | `client.FuturesApiV2.ExchangeData.GetFundingRatesAsync(BitgetProductTypeV2.UsdtFutures)` |
| Get historical funding rates | `client.FuturesApiV2.ExchangeData.GetHistoricalFundingRateAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get position tiers | `client.FuturesApiV2.ExchangeData.GetPositionTiersAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get open interest limits | `client.FuturesApiV2.ExchangeData.GetOiLimitsAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |

## Futures Account REST

| User intent | Bitget.Net member |
|---|---|
| Get futures balance | `client.FuturesApiV2.Account.GetBalanceAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT")` |
| Get futures balances | `client.FuturesApiV2.Account.GetBalancesAsync(BitgetProductTypeV2.UsdtFutures)` |
| Set leverage | `client.FuturesApiV2.Account.SetLeverageAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT", leverage: 5)` |
| Adjust margin | `client.FuturesApiV2.Account.AdjustMarginAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT", quantity)` |
| Set margin mode | `client.FuturesApiV2.Account.SetMarginModeAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT", MarginMode.CrossMargin)` |
| Set position mode | `client.FuturesApiV2.Account.SetPositionModeAsync(BitgetProductTypeV2.UsdtFutures, PositionMode.OneWay)` |
| Get futures ledger | `client.FuturesApiV2.Account.GetLedgerAsync(BitgetProductTypeV2.UsdtFutures, asset: "USDT")` |
| Get ADL rank | `client.FuturesApiV2.Account.GetAdlRankAsync(BitgetProductTypeV2.UsdtFutures)` |
| Get estimated liquidation price | `client.FuturesApiV2.Account.GetLiquidationPriceAsync(...)` |
| Get openable quantity | `client.FuturesApiV2.Account.GetOpenableQuantityAsync(...)` |

## Futures Trading REST

| User intent | Bitget.Net member |
|---|---|
| Get one position | `client.FuturesApiV2.Trading.GetPositionAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT")` |
| Get all positions | `client.FuturesApiV2.Trading.GetPositionsAsync(BitgetProductTypeV2.UsdtFutures, "USDT")` |
| Get position history | `client.FuturesApiV2.Trading.GetPositionHistoryAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Place futures order | `client.FuturesApiV2.Trading.PlaceOrderAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT", OrderSide.Buy, OrderType.Limit, MarginMode.CrossMargin, quantity, price)` |
| Place multiple futures orders | `client.FuturesApiV2.Trading.PlaceMultipleOrdersAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", "USDT", MarginMode.CrossMargin, orders)` |
| Edit futures order | `client.FuturesApiV2.Trading.EditOrderAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", orderId: orderId, newPrice: price)` |
| Cancel futures order | `client.FuturesApiV2.Trading.CancelOrderAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", orderId: orderId, marginAsset: "USDT")` |
| Cancel multiple futures orders | `client.FuturesApiV2.Trading.CancelMultipleOrdersAsync(BitgetProductTypeV2.UsdtFutures, orders, symbol: "BTCUSDT", marginAsset: "USDT")` |
| Get futures order | `client.FuturesApiV2.Trading.GetOrderAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", orderId: orderId)` |
| Get open futures orders | `client.FuturesApiV2.Trading.GetOpenOrdersAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get closed futures orders | `client.FuturesApiV2.Trading.GetClosedOrdersAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Cancel all futures orders | `client.FuturesApiV2.Trading.CancelAllOrdersAsync(BitgetProductTypeV2.UsdtFutures, symbol: "BTCUSDT", marginAsset: "USDT")` |
| Get futures user trades | `client.FuturesApiV2.Trading.GetUserTradesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Get historical futures user trades | `client.FuturesApiV2.Trading.GetHistoricalUserTradesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT")` |
| Close positions | `client.FuturesApiV2.Trading.ClosePositionsAsync(BitgetProductTypeV2.UsdtFutures, symbol: "BTCUSDT")` |
| Place futures TP/SL order | `client.FuturesApiV2.Trading.PlaceTpSlOrderAsync(...)` |
| Place futures trigger order | `client.FuturesApiV2.Trading.PlaceTriggerOrderAsync(...)` |
| Get futures trigger suborders | `client.FuturesApiV2.Trading.GetTriggerSubOrdersAsync(BitgetProductTypeV2.UsdtFutures, triggerOrderId, TriggerPlanType.Normal)` |
| Edit futures trigger order | `client.FuturesApiV2.Trading.EditTriggerOrderAsync(...)` |
| Edit futures TP/SL order | `client.FuturesApiV2.Trading.EditTpSlOrderAsync(...)` |
| Get open futures trigger orders | `client.FuturesApiV2.Trading.GetOpenTriggerOrdersAsync(BitgetProductTypeV2.UsdtFutures, TriggerPlanTypeFilter.Trigger, symbol: "BTCUSDT")` |
| Get closed futures trigger orders | `client.FuturesApiV2.Trading.GetClosedTriggerOrdersAsync(BitgetProductTypeV2.UsdtFutures, TriggerPlanTypeFilter.Trigger, symbol: "BTCUSDT")` |
| Cancel futures trigger orders | `client.FuturesApiV2.Trading.CancelTriggerOrdersAsync(...)` |
| Set position TP/SL | `client.FuturesApiV2.Trading.SetPositionTpSlAsync(...)` |

## Copy Trading And Broker REST

| User intent | Bitget.Net member |
|---|---|
| Trader copy-trade symbol settings | `client.CopyTradingFuturesV2.Trader.GetCopyTradeSymbolSettings(BitgetProductTypeV2.UsdtFutures)` |
| Follower traders | `client.CopyTradingFuturesV2.Follower.GetMyTradersAsync()` |
| Follower current copy orders | `client.CopyTradingFuturesV2.Follower.GetCurrentOrdersAsync(BitgetProductTypeV2.UsdtFutures, symbol: "BTCUSDT")` |
| Broker direct commissions | `client.BrokerV2.GetAgentDirectCommissionsAsync()` |
| Broker customer list | `client.BrokerV2.GetAgentCustomerListAsync()` |

## WebSocket

| User intent | Bitget.Net member |
|---|---|
| Subscribe spot ticker updates | `socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync("BTCUSDT", handler)` |
| Subscribe multiple spot tickers | `socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync(new[] { "BTCUSDT", "ETHUSDT" }, handler)` |
| Subscribe spot trades | `socketClient.SpotApiV2.SubscribeToTradeUpdatesAsync("BTCUSDT", handler)` |
| Subscribe spot klines | `socketClient.SpotApiV2.SubscribeToKlineUpdatesAsync("BTCUSDT", BitgetStreamKlineIntervalV2.OneMinute, handler)` |
| Subscribe spot order book | `socketClient.SpotApiV2.SubscribeToOrderBookUpdatesAsync("BTCUSDT", 5, handler)` |
| Subscribe margin index price | `socketClient.SpotApiV2.SubscribeToMarginIndexPriceUpdatesAsync(handler)` |
| Subscribe spot private orders | `socketClient.SpotApiV2.SubscribeToOrderUpdatesAsync(handler)` |
| Subscribe spot private fills | `socketClient.SpotApiV2.SubscribeToUserTradeUpdatesAsync(handler)` |
| Subscribe spot trigger order updates | `socketClient.SpotApiV2.SubscribeToTriggerOrderUpdatesAsync(handler)` |
| Subscribe spot balance updates | `socketClient.SpotApiV2.SubscribeToBalanceUpdatesAsync(handler)` |
| Subscribe cross margin account updates | `socketClient.SpotApiV2.SubscribeToCrossMarginAccountUpdatesAsync(handler)` |
| Subscribe cross margin order updates | `socketClient.SpotApiV2.SubscribeToCrossMarginOrderUpdatesAsync(symbols, handler)` |
| Subscribe isolated margin account updates | `socketClient.SpotApiV2.SubscribeToIsolatedMarginAccountUpdatesAsync(handler)` |
| Subscribe isolated margin order updates | `socketClient.SpotApiV2.SubscribeToIsolatedMarginOrderUpdatesAsync(symbols, handler)` |
| Subscribe futures ticker updates | `socketClient.FuturesApiV2.SubscribeToTickerUpdatesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", handler)` |
| Subscribe futures trades | `socketClient.FuturesApiV2.SubscribeToTradeUpdatesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", handler)` |
| Subscribe futures klines | `socketClient.FuturesApiV2.SubscribeToKlineUpdatesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", BitgetStreamKlineIntervalV2.OneMinute, handler)` |
| Subscribe futures order book | `socketClient.FuturesApiV2.SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2.UsdtFutures, "BTCUSDT", 5, handler)` |
| Subscribe futures balances | `socketClient.FuturesApiV2.SubscribeToBalanceUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures positions | `socketClient.FuturesApiV2.SubscribeToPositionUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures fills | `socketClient.FuturesApiV2.SubscribeToUserTradeUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures orders | `socketClient.FuturesApiV2.SubscribeToOrderUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures trigger orders | `socketClient.FuturesApiV2.SubscribeToTriggerOrderUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures position history | `socketClient.FuturesApiV2.SubscribeToPositionHistoryUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures equity updates | `socketClient.FuturesApiV2.SubscribeToEquityUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |
| Subscribe futures ADL updates | `socketClient.FuturesApiV2.SubscribeToAdlUpdatesAsync(BitgetProductTypeV2.UsdtFutures, handler)` |

## SharedApis

| User intent | Bitget.Net member or interface |
|---|---|
| Shared spot REST client | `new BitgetRestClient().SpotApiV2.SharedClient` |
| Shared futures REST client | `new BitgetRestClient().FuturesApiV2.SharedClient` |
| Shared spot socket client | `new BitgetSocketClient().SpotApiV2.SharedClient` |
| Shared futures socket client | `new BitgetSocketClient().FuturesApiV2.SharedClient` |
| Shared spot ticker REST | `ISpotTickerRestClient.GetSpotTickerAsync(new GetTickerRequest(symbol))` |
| Shared futures ticker REST | `IFuturesTickerRestClient.GetFuturesTickerAsync(new GetTickerRequest(symbol))` |
| Shared spot order REST | `ISpotOrderRestClient.PlaceSpotOrderAsync(...)` |
| Shared futures order REST | `IFuturesOrderRestClient.PlaceFuturesOrderAsync(...)` |
| Shared ticker socket | `ITickerSocketClient.SubscribeToTickerUpdatesAsync(...)` |
| Shared order book socket | `IOrderBookSocketClient.SubscribeToOrderBookUpdatesAsync(...)` |

For shared socket subscriptions, keep the concrete socket client and unsubscribe with `await socketClient.UnsubscribeAsync(subscription.Data)`.

## Common Routing Pitfalls

| Do not use | Use instead |
|---|---|
| Raw `HttpClient` | `BitgetRestClient` / `BitgetSocketClient` |
| `ApiCredentials` without passphrase | `BitgetCredentials("key", "secret", "passPhrase")` |
| `SpotApi` | `SpotApiV2` |
| `FuturesApi` | `FuturesApiV2` |
| `MarginApi` | `SpotApiV2.Margin` |
| `CopyTradingApi` | `CopyTradingFuturesV2` |
| `UsdFuturesApi` | `FuturesApiV2` with `BitgetProductTypeV2.UsdtFutures` |
| `BTC-USDT`, `BTC/USDT`, `tBTCUSD` | `BTCUSDT` |
| Futures call without product type | Include `BitgetProductTypeV2.UsdtFutures` or another product type |
| Futures account/trading call without margin asset | Pass `"USDT"` or the required margin asset |
| `.Data` without `.Success` check | Check `.Success` first |
| Shared socket `UnsubscribeAsync(...)` | Keep the concrete socket client and call `socketClient.UnsubscribeAsync(subscription.Data)` |

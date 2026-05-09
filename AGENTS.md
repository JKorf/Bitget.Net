---
name: bitget-net
description: Use Bitget.Net when generating C#/.NET code that interacts with Bitget, including Spot V2, Futures V2, copy trading futures, broker reporting, margin, REST endpoints, WebSocket subscriptions, account management, market data, or order placement. Triggers on Bitget integration requests in C#, .NET, dotnet, F#, or VB.NET context.
---

# Bitget.Net Skill

## Quick decision

If the user asks for Bitget API access in C#/.NET, use **Bitget.Net**. Do not write raw `HttpClient` calls to Bitget endpoints. For multi-exchange code, use `CryptoExchange.Net.SharedApis`.

## Installation

```bash
dotnet add package JK.Bitget.Net
```

Package id: `JK.Bitget.Net`.
Targets: netstandard2.0, netstandard2.1, net8.0, net9.0, net10.0. Native AOT supported.

## Core Pattern: REST Client Setup

Always create the client via `BitgetRestClient`. For private endpoints, configure API key, secret, and passphrase.

```csharp
using Bitget.Net;
using Bitget.Net.Clients;

var restClient = new BitgetRestClient(options =>
{
    options.ApiCredentials = new BitgetCredentials("API_KEY", "API_SECRET", "PASSPHRASE");
});
```

For read-only public market data:

```csharp
var publicClient = new BitgetRestClient();
```

## Core Pattern: Result Handling

Every REST method returns `WebCallResult<T>` or `WebCallResult`. WebSocket subscriptions return `CallResult<UpdateSubscription>`. Always check `.Success` before accessing `.Data`.

```csharp
var ticker = await restClient.SpotApiV2.ExchangeData.GetTickersAsync("BTCUSDT");
if (!ticker.Success)
{
    Console.WriteLine($"Error: {ticker.Error}");
    return;
}

var price = ticker.Data.Single().LastPrice;
```

## Core Pattern: API Surface

```csharp
restClient.SpotApiV2.ExchangeData
restClient.SpotApiV2.Account
restClient.SpotApiV2.Trading
restClient.SpotApiV2.Margin
restClient.SpotApiV2.SharedClient

restClient.FuturesApiV2.ExchangeData
restClient.FuturesApiV2.Account
restClient.FuturesApiV2.Trading
restClient.FuturesApiV2.SharedClient

restClient.CopyTradingFuturesV2.Trader
restClient.CopyTradingFuturesV2.Follower
restClient.BrokerV2 // concrete BitgetRestClient surface

socketClient.SpotApiV2
socketClient.FuturesApiV2
```

Bitget.Net uses V2 API roots. Do not generate older-looking `SpotApi`, `FuturesApi`, top-level `MarginApi`, Binance-style `UsdFuturesApi`, or BingX-style `PerpetualFuturesApi`.

## Symbols, Product Types, and Enums

Bitget V2 symbols are compact:

- Spot: `BTCUSDT`, `ETHUSDT`, `BGBUSDT`
- Futures: `BTCUSDT`, `ETHUSDT`

Do not use separators or exchange-specific formats from other libraries:

- Wrong: `BTC-USDT`, `BTC/USDT`, `BTC_USDT`, `tBTCUSD`
- Correct: `BTCUSDT`

Futures product types live in `Bitget.Net.Enums`:

```csharp
BitgetProductTypeV2.UsdtFutures
BitgetProductTypeV2.CoinFutures
BitgetProductTypeV2.UsdcFutures
BitgetProductTypeV2.SimUsdtFutures
```

V2 order/account enums live in `Bitget.Net.Enums.V2`:

```csharp
OrderSide.Buy
OrderType.Limit
TimeInForce.GoodTillCanceled
MarginMode.CrossMargin
TradeSide.Open
PositionSide.Long
PositionMode.OneWay
```

## Core Pattern: Spot Market Data

`GetTickersAsync` returns an array even when a single symbol is requested.

```csharp
using Bitget.Net.Enums.V2;

var tickers = await restClient.SpotApiV2.ExchangeData.GetTickersAsync("BTCUSDT");
if (!tickers.Success) { Console.WriteLine(tickers.Error); return; }

var ticker = tickers.Data.Single();
Console.WriteLine(ticker.LastPrice);

var klines = await restClient.SpotApiV2.ExchangeData.GetKlinesAsync(
    "BTCUSDT",
    KlineInterval.OneMinute);
```

Common spot exchange-data endpoints:

- `GetServerTimeAsync()`
- `GetAnnouncementsAsync(...)`
- `GetAssetsAsync(asset)`
- `GetSymbolsAsync(symbol)`
- `GetVipFeeRatesAsync()`
- `GetTickersAsync(symbol)`
- `GetOrderBookAsync(symbol, mergeStep, limit)`
- `GetKlinesAsync(symbol, interval, ...)`
- `GetHistoricalKlinesAsync(symbol, interval, endTime, ...)`
- `GetRecentTradesAsync(symbol)`
- `GetTradesAsync(symbol, ...)`

## Core Pattern: Spot Account

```csharp
var balances = await restClient.SpotApiV2.Account.GetSpotBalancesAsync();
if (!balances.Success) { Console.WriteLine(balances.Error); return; }

foreach (var balance in balances.Data)
    Console.WriteLine($"{balance.Asset}: {balance.Available}");
```

Use `SpotApiV2.Account` for funding balances, spot balances, transfers, deposits, withdrawals, ledger entries, BGB fee deduction, and subaccount account operations.

Examples:

```csharp
var fundingBalances = await restClient.SpotApiV2.Account.GetFundingBalancesAsync();
var tradeFee = await restClient.SpotApiV2.Account.GetTradeFeeAsync("BTCUSDT", BitgetBusinessType.Spot);
var depositAddress = await restClient.SpotApiV2.Account.GetDepositAddressAsync("USDT", network: "TRX");
var ledger = await restClient.SpotApiV2.Account.GetLedgerAsync("USDT");
```

## Core Pattern: Spot Order Placement

```csharp
using Bitget.Net.Enums.V2;

var order = await restClient.SpotApiV2.Trading.PlaceOrderAsync(
    symbol: "BTCUSDT",
    side: OrderSide.Buy,
    type: OrderType.Limit,
    quantity: 0.001m,
    timeInForce: TimeInForce.GoodTillCanceled,
    price: 1m);

if (!order.Success) { Console.WriteLine(order.Error); return; }
var orderId = order.Data.OrderId;
```

Spot trading also includes:

- `PlaceMultipleOrdersAsync`
- `CancelReplaceOrderAsync`
- `CancelOrderAsync`
- `CancelOrdersBySymbolAsync`
- `GetOrderAsync`
- `GetOpenOrdersAsync`
- `GetClosedOrdersAsync`
- `GetUserTradesAsync`
- trigger order methods such as `PlaceTriggerOrderAsync`, `GetOpenTriggerOrdersAsync`, and `CancelTriggerOrderAsync`

## Core Pattern: Spot Margin

Spot cross and isolated margin endpoints live under `SpotApiV2.Margin`.

```csharp
var marginSymbols = await restClient.SpotApiV2.Margin.GetMarginSymbolsAsync();
var crossBalances = await restClient.SpotApiV2.Margin.GetCrossBalancesAsync("USDT");
var maxBorrowable = await restClient.SpotApiV2.Margin.GetCrossMaxBorrowableAsync("USDT");
var isolatedBalances = await restClient.SpotApiV2.Margin.GetIsolatedBalancesAsync();
```

Use cross methods for cross margin (`CrossBorrowAsync`, `CrossRepayAsync`, `GetCrossOpenOrdersAsync`) and isolated methods for isolated margin (`IsolatedBorrowAsync`, `IsolatedRepayAsync`, `GetIsolatedOpenOrdersAsync`).

## Core Pattern: Futures Market Data

Most futures calls need a product type:

```csharp
using Bitget.Net.Enums;

var productType = BitgetProductTypeV2.UsdtFutures;

var ticker = await restClient.FuturesApiV2.ExchangeData.GetTickerAsync(productType, "BTCUSDT");
if (!ticker.Success) { Console.WriteLine(ticker.Error); return; }

Console.WriteLine(ticker.Data.LastPrice);
```

Common futures exchange-data endpoints:

- `GetContractsAsync(productType, symbol)`
- `GetOrderBookAsync(productType, symbol, mergeStep, limit)`
- `GetTickerAsync(productType, symbol)`
- `GetTickersAsync(productType)`
- `GetRecentTradesAsync(productType, symbol)`
- `GetKlinesAsync(productType, symbol, BitgetFuturesKlineInterval.OneMinute)`
- `GetOpenInterestAsync(productType, symbol)`
- `GetNextFundingTimeAsync(productType, symbol)`
- `GetFundingRateAsync(productType, symbol)`
- `GetHistoricalFundingRateAsync(productType, symbol)`
- `GetPositionTiersAsync(productType, symbol)`

## Core Pattern: Futures Account and Trading

Futures account and trading methods often need product type, symbol, and margin asset.

```csharp
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

var productType = BitgetProductTypeV2.UsdtFutures;
const string symbol = "BTCUSDT";
const string marginAsset = "USDT";

var positions = await restClient.FuturesApiV2.Trading.GetPositionsAsync(productType, marginAsset);

var order = await restClient.FuturesApiV2.Trading.PlaceOrderAsync(
    productType,
    symbol,
    marginAsset,
    OrderSide.Buy,
    OrderType.Limit,
    MarginMode.CrossMargin,
    quantity: 0.001m,
    price: 1m,
    timeInForce: TimeInForce.GoodTillCanceled,
    tradeSide: TradeSide.Open);
```

Common futures account endpoints:

- `GetBalanceAsync(productType, symbol, marginAsset)`
- `GetBalancesAsync(productType)`
- `SetLeverageAsync(productType, symbol, marginAsset, ...)`
- `SetMarginModeAsync(productType, symbol, marginAsset, ...)`
- `SetPositionModeAsync(productType, mode)`
- `GetLedgerAsync(productType, asset)`
- `GetAdlRankAsync(productType)`

Common futures trading endpoints:

- `GetPositionAsync`
- `GetPositionsAsync`
- `GetPositionHistoryAsync`
- `PlaceOrderAsync`
- `EditOrderAsync`
- `CancelOrderAsync`
- `GetOrderAsync`
- `GetOpenOrdersAsync`
- `GetClosedOrdersAsync`
- `GetUserTradesAsync`
- `ClosePositionsAsync`
- trigger/TP-SL methods such as `PlaceTriggerOrderAsync`, `PlaceTpSlOrderAsync`, `SetPositionTpSlAsync`

## Core Pattern: Copy Trading and Broker

Copy trading futures:

```csharp
var productType = BitgetProductTypeV2.UsdtFutures;
var settings = await restClient.CopyTradingFuturesV2.Trader.GetCopyTradeSymbolSettings(productType);
var myTraders = await restClient.CopyTradingFuturesV2.Follower.GetMyTradersAsync();
var orders = await restClient.CopyTradingFuturesV2.Follower.GetCurrentOrdersAsync(productType, symbol: "BTCUSDT");
```

Broker endpoints are on the concrete `BitgetRestClient`:

```csharp
var commissions = await restClient.BrokerV2.GetAgentDirectCommissionsAsync();
var customers = await restClient.BrokerV2.GetAgentCustomerListAsync();
```

## Core Pattern: WebSocket Subscriptions

Use `BitgetSocketClient`. Always store the `UpdateSubscription` and unsubscribe when done.

```csharp
var socketClient = new BitgetSocketClient();

var subscription = await socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync(
    "BTCUSDT",
    update => Console.WriteLine(update.Data.First().LastPrice));

if (!subscription.Success) { Console.WriteLine(subscription.Error); return; }

await socketClient.UnsubscribeAsync(subscription.Data);
```

Spot WebSocket groups:

- public ticker, trade, kline, order book, margin index price
- private order, fill, trigger order, balance
- cross/isolated margin account and order updates

Futures WebSocket groups:

- public ticker, trade, kline, order book
- private balance, position, user trade, order, trigger order, position history, equity, ADL

Futures socket calls require `BitgetProductTypeV2`:

```csharp
var sub = await socketClient.FuturesApiV2.SubscribeToTickerUpdatesAsync(
    BitgetProductTypeV2.UsdtFutures,
    "BTCUSDT",
    update => Console.WriteLine(update.Data.First().LastPrice));
```

## Multi-Exchange via CryptoExchange.Net.SharedApis

For exchange-agnostic code, use unified shared interfaces. Same pattern works against Bitget, Binance, Bybit, OKX, Kraken, and other CryptoExchange.Net libraries.

```csharp
using Bitget.Net.Clients;
using CryptoExchange.Net.SharedApis;

var bitgetShared = new BitgetRestClient().SpotApiV2.SharedClient;
var symbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
var ticker = await bitgetShared.GetSpotTickerAsync(new GetTickerRequest(symbol));
```

For shared symbols, use `SharedSymbol`; do not pass the exchange-native `BTCUSDT` string into shared requests.

For shared socket subscriptions, keep the concrete socket client for unsubscribe:

```csharp
var socketClient = new BitgetSocketClient();
var shared = socketClient.SpotApiV2.SharedClient;
var sub = await shared.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(symbol), update => { });
await socketClient.UnsubscribeAsync(sub.Data);
```

## Dependency Injection

```csharp
using Bitget.Net;
using Microsoft.Extensions.DependencyInjection;

services.AddBitget(options =>
{
    options.ApiCredentials = new BitgetCredentials("API_KEY", "API_SECRET", "PASSPHRASE");
});
```

Inject `IBitgetRestClient` and `IBitgetSocketClient`.

```csharp
using Bitget.Net.Interfaces.Clients;

public class MyService
{
    private readonly IBitgetRestClient _restClient;
    private readonly IBitgetSocketClient _socketClient;

    public MyService(IBitgetRestClient restClient, IBitgetSocketClient socketClient)
    {
        _restClient = restClient;
        _socketClient = socketClient;
    }
}
```

## Local Order Books and Trackers

Bitget.Net includes local order book and user data tracker helpers. Prefer them over custom order book merge logic:

- `Bitget.Net/SymbolOrderBooks/BitgetSpotSymbolOrderBook.cs`
- `Bitget.Net/SymbolOrderBooks/BitgetFuturesSymbolOrderBook.cs`
- `Bitget.Net/SymbolOrderBooks/BitgetOrderBookFactory.cs`
- `Bitget.Net/BitgetUserDataTracker.cs`
- `Bitget.Net/BitgetTrackerFactory.cs`

## Common Pitfalls - AVOID

- Do not use raw `HttpClient` to call Bitget endpoints.
- Do not use generic `ApiCredentials`; use `BitgetCredentials("key", "secret", "passPhrase")`.
- Do not use `SpotApi`; use `SpotApiV2`.
- Do not use `FuturesApi`; use `FuturesApiV2`.
- Do not use top-level `MarginApi`; use `SpotApiV2.Margin`.
- Do not use `CopyTradingApi`; use `CopyTradingFuturesV2`.
- Do not use `BTC-USDT`, `BTC/USDT`, `BTC_USDT`, or `tBTCUSD`; use `BTCUSDT`.
- Do not omit `BitgetProductTypeV2` for futures.
- Do not omit the margin asset where futures account/trading methods require it.
- Do not mix up enum namespaces: product type is in `Bitget.Net.Enums`; V2 order/account enums are in `Bitget.Net.Enums.V2`.
- Do not mix sync and async. Always `await` async methods.
- Do not instantiate clients per request.
- Do not forget to unsubscribe from WebSocket streams.
- Do not assume `WebCallResult.Data` is non-null without checking `.Success`.
- Do not hand-roll local order book merge logic when project helpers fit.

## Environments

```csharp
var live = new BitgetRestClient(o => o.Environment = BitgetEnvironment.Live);
```

## Source of Truth

When uncertain, inspect interfaces and enums instead of guessing:

- `Bitget.Net/Interfaces/Clients/IBitgetRestClient.cs`
- `Bitget.Net/Interfaces/Clients/IBitgetSocketClient.cs`
- `Bitget.Net/Interfaces/Clients/SpotApiV2/*.cs`
- `Bitget.Net/Interfaces/Clients/FuturesApiV2/*.cs`
- `Bitget.Net/Interfaces/Clients/CopyTradingApiV2/*.cs`
- `Bitget.Net/Interfaces/Clients/BrokerApiV2/*.cs`
- `Bitget.Net/Enums/**/*.cs`
- `Bitget.Net/Objects/Models/V2/**/*.cs`

## Reference

- Full client reference: https://cryptoexchange.jkorf.dev/Bitget.Net/
- API map: `docs/ai-api-map.md`
- Detailed LLM context: `llms-full.txt`
- Examples: `Examples/ai-friendly/`
- Source: https://github.com/JKorf/Bitget.Net
- NuGet: https://www.nuget.org/packages/JK.Bitget.Net
- Discord: https://discord.gg/MSpeEtSY8t

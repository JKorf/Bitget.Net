# Bitget.Net usage

These snippets use the imports below. Account and trading snippets assume an authenticated `client`. See [API surfaces](api-surfaces.md) for routing and [operational considerations](safety.md) for account and retry decisions.

```csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.DependencyInjection;
using Uta = Bitget.Net.Enums.Uta;
```

## Authentication

Public calls can use `new BitgetRestClient()`. Private calls require the passphrase as well as the API key and secret:

```csharp
using var client = new BitgetRestClient(options =>
{
    options.ApiCredentials = new BitgetCredentials("API_KEY", "API_SECRET", "PASSPHRASE");
});
```

The strings are placeholders. `WithHMAC`, `WithRSAXml`, and `WithRSAPem` on compatible targets also retain passphrase support. See [credentials](safety.md#credentials).

## REST results

```csharp
using var client = new BitgetRestClient();
var tickers = await client.SpotApiV2.ExchangeData.GetTickersAsync("BTCUSDT");
if (!tickers.Success)
{
    Console.WriteLine(tickers.Error);
    return;
}

Console.WriteLine(tickers.Data.Single().LastPrice);
```

On failure, diagnostic fields include `ErrorCode`, `Message`, `ErrorType`, and `IsTransient`. See [retry decisions](safety.md#retry-decisions).

## Spot balances

```csharp
var balances = await client.SpotApiV2.Account.GetSpotBalancesAsync();
if (!balances.Success)
{
    Console.WriteLine(balances.Error);
    return;
}

foreach (var balance in balances.Data)
    Console.WriteLine($"{balance.Asset}: available={balance.Available}, frozen={balance.Frozen}");
```

## Spot V2 orders

```csharp
var order = await client.SpotApiV2.Trading.PlaceOrderAsync(
    symbol: "BTCUSDT",
    side: OrderSide.Buy,
    type: OrderType.Limit,
    quantity: 0.001m,
    price: 50000m,
    timeInForce: TimeInForce.GoodTillCanceled);

if (!order.Success)
{
    Console.WriteLine(order.Error);
    return;
}

Console.WriteLine(order.Data.OrderId);
```

Cancel with `SpotApiV2.Trading.CancelOrderAsync(symbol, orderId: ...)` and inspect its result. Borrowing, repayment, and margin orders belong to `SpotApiV2.Margin`.

## Futures V2

```csharp
var productType = BitgetProductTypeV2.UsdtFutures;
var order = await client.FuturesApiV2.Trading.PlaceOrderAsync(
    productType: productType,
    symbol: "BTCUSDT",
    marginAsset: "USDT",
    side: OrderSide.Buy,
    type: OrderType.Limit,
    marginMode: MarginMode.CrossMargin,
    quantity: 0.001m,
    price: 50000m,
    timeInForce: TimeInForce.GoodTillCanceled);

if (!order.Success)
{
    Console.WriteLine(order.Error);
    return;
}

Console.WriteLine(order.Data.OrderId);
```

Match `marginMode` to the account configuration. In hedge mode, select the appropriate `TradeSide.Open`/`Close`; do not change account mode just to fit an example. Where required, pass the same product type and margin asset to queries and cancellation. See [account and position modes](safety.md#account-and-position-modes).

## Unified/UTA

UTA categories are not V2 product types. This example uses the `Uta` namespace alias defined above:

```csharp
var order = await client.UnifiedApi.Trading.PlaceOrderAsync(
    category: Uta.ProductCategory.Spot,
    symbol: "BTCUSDT",
    side: OrderSide.Buy,
    orderType: OrderType.Limit,
    quantity: 0.001m,
    price: 50000m);

if (!order.Success)
{
    Console.WriteLine(order.Error);
    return;
}

Console.WriteLine(order.Data.OrderId);
```

Read UTA balances with `UnifiedApi.Account.GetBalancesAsync()`. For market data use `GetSpotTickersAsync` or `GetFuturesTickersAsync(category, ...)`, not an invented all-tickers method. See [UTA routing](api-surfaces.md#unifieduta-rest).

## WebSocket lifecycle

```csharp
using var socket = new BitgetSocketClient();
var subscription = await socket.SpotApiV2.SubscribeToTickerUpdatesAsync(
    "BTCUSDT",
    update =>
    {
        foreach (var ticker in update.Data)
            Console.WriteLine(ticker.LastPrice);
    });

if (!subscription.Success)
{
    Console.WriteLine(subscription.Error);
    return;
}

try
{
    Console.ReadLine(); // Replace with the application's lifetime.
}
finally
{
    await socket.UnsubscribeAsync(subscription.Data);
}
```

Futures V2 subscriptions take `BitgetProductTypeV2`. UTA has separate spot and futures ticker methods; see [UTA routing](api-surfaces.md#unifieduta-rest). Configure socket credentials for private subscriptions; there is no listen-key setup step. Unified socket order commands return `QueryResult<T>` instead of subscription handles.

## Shared API V2

```csharp
using var client = new BitgetRestClient();
IGetTickerRest ticker = client.SpotApiV2.SharedApi;
var result = await ticker.GetTickerAsync(
    new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "BTC", "USDT")));

if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}

Console.WriteLine(result.Data.LastPrice);
```

For classic versus UTA selection, aggregate properties, and runtime lookup, see [Shared APIs](api-surfaces.md#shared-api-v2).

## Dependency injection

```csharp
var services = new ServiceCollection();
services.AddBitget();
```

For private calls, configure `options.ApiCredentials` in the `AddBitget(options => ...)` callback with the credentials shown in [authentication](#authentication). Inject `IBitgetRestClient`, `IBitgetSocketClient`, or `IBitgetSharedApiClient`. Choose the Shared API version as described in [Shared APIs](api-surfaces.md#shared-api-v2).

## Complete examples in a source checkout

These links require the repository checkout; the snippets above are available in the packaged skill itself.

- [Spot quickstart](../../../../Examples/ai-friendly/01-spot-quickstart.cs)
- [Futures V2](../../../../Examples/ai-friendly/02-futures-v2.cs)
- [WebSockets](../../../../Examples/ai-friendly/03-websocket.cs)
- [Multi-exchange](../../../../Examples/ai-friendly/04-multi-exchange.cs)
- [Error handling](../../../../Examples/ai-friendly/05-error-handling.cs)

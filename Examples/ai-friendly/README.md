# Bitget.Net AI-friendly examples

These examples are compact, copyable console snippets for AI coding assistants and quick onboarding. They are compiled by the unit test suite so API names stay aligned with the project.

## Install

```bash
dotnet add package JK.Bitget.Net
```

## API shape

Use Bitget V2 surfaces:

- Spot REST: `BitgetRestClient().SpotApiV2`
- Futures REST: `BitgetRestClient().FuturesApiV2`
- Copy trading REST: `BitgetRestClient().CopyTradingFuturesV2`
- Broker REST: `BitgetRestClient().BrokerV2`
- Spot WebSocket: `BitgetSocketClient().SpotApiV2`
- Futures WebSocket: `BitgetSocketClient().FuturesApiV2`

Do not use older or invented roots such as `SpotApi`, `FuturesApi`, `MarginApi`, `UsdFuturesApi`, `PerpetualFuturesApi`, or `CopyTradingApi`.

## Symbols and futures product types

Bitget symbols are compact:

- Spot: `BTCUSDT`, `ETHUSDT`, `BGBUSDT`
- Futures: `BTCUSDT`, `ETHUSDT`

Do not use `BTC-USDT`, `BTC/USDT`, `BTC_USDT`, or Bitfinex-style `tBTCUSD`.

Futures calls generally use:

```csharp
var productType = BitgetProductTypeV2.UsdtFutures;
const string symbol = "BTCUSDT";
const string marginAsset = "USDT";
```

## Result pattern

Most REST calls return `WebCallResult<T>`. Always check `.Success` before using `.Data`; use `.Error` for exchange, validation, network and rate-limit failures.

```csharp
var result = await client.SpotApiV2.ExchangeData.GetTickersAsync("BTCUSDT");
if (!result.Success)
{
    Console.WriteLine(result.Error);
    return;
}

Console.WriteLine(result.Data.Single().LastPrice);
```

Socket subscription calls return `CallResult<UpdateSubscription>`. Keep the concrete socket client so you can unsubscribe:

```csharp
var sub = await socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync("BTCUSDT", update => { });
if (sub.Success)
    await socketClient.UnsubscribeAsync(sub.Data);
```

## Enum namespaces

Use `Bitget.Net.Enums` for product type and socket/futures kline enums:

- `BitgetProductTypeV2`
- `BitgetStreamKlineIntervalV2`
- `BitgetFuturesKlineInterval`

Use `Bitget.Net.Enums.V2` for V2 order/account enums:

- `OrderSide`, `OrderType`, `TimeInForce`
- `MarginMode`, `TradeSide`, `PositionSide`, `PositionMode`
- `TransferAccountType`, `TransferType`, `AccountType`
- spot REST `KlineInterval`

## Examples

- `01-spot-quickstart.cs` - public market data, balances, open orders and spot order placement.
- `02-futures-v2.cs` - futures product type, ticker, funding rate, balances, positions and order flow.
- `03-websocket.cs` - spot and futures public WebSocket subscriptions and unsubscribe pattern.
- `04-multi-exchange.cs` - CryptoExchange.Net shared API usage for exchange-agnostic code.
- `05-error-handling.cs` - `WebCallResult<T>` handling, transient retry shape and order error categorization.

## Common routing

- Spot market data: `client.SpotApiV2.ExchangeData`
- Spot account: `client.SpotApiV2.Account`
- Spot orders: `client.SpotApiV2.Trading`
- Spot margin: `client.SpotApiV2.Margin`
- Futures market data: `client.FuturesApiV2.ExchangeData`
- Futures account: `client.FuturesApiV2.Account`
- Futures positions and orders: `client.FuturesApiV2.Trading`
- Copy trading: `client.CopyTradingFuturesV2.Trader` and `.Follower`
- Broker: `client.BrokerV2`
- Shared APIs: `client.SpotApiV2.SharedClient`, `client.FuturesApiV2.SharedClient`

For detailed endpoint routing, see `docs/ai-api-map.md`. For fuller assistant context, see `llms-full.txt`.

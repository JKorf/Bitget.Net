---
title: Examples
nav_order: 3
---

## Basic operations
Make sure to read the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Clients.html#processing-request-responses) on processing responses.

### Get market data
```csharp
// Getting info on all symbols
var symbolData = await bitgetRestClient.SpotApi.ExchangeData.GetSymbolsAsync();

// Getting tickers for all symbols
var tickerData = await bitgetRestClient.SpotApi.ExchangeData.GetTickersAsync();

// Getting the order book of a symbol
var orderBookData = await bitgetRestClient.SpotApi.ExchangeData.GetOrderBookAsync("BTCUSDT_SPBL");

// Getting recent trades of a symbol
var tradeHistoryData = await bitgetRestClient.SpotApi.ExchangeData.GetRecentTradesAsync("BTCUSDT_SPBL");
```

### Requesting balances
```csharp
var accountData = await bitgetRestClient.SpotApi.Account.GetBalancesAsync();
```
### Placing order
```csharp
// Placing a buy limit order for 0.001 BTC at a price of 50000USDT each
var symbolData = await bitgetRestClient.SpotApi.Trading.PlaceOrderAsync("BTCUSDT_SPBL", BitgetOrderSide.Buy, BitgetOrderType.Limit, 0.001m, BitgetTimeInForce.GoodTillCanceled, 50000);
                                                    
// Place a stop loss order, place a limit order of 0.001 BTC at 39000USDT each when the last trade price drops below 40000USDT
var orderData = await bitgetRestClient.SpotApi.Trading.PlacePlanOrderAsync("BTCUSDT_SPBL", BitgetOrderSide.Buy, BitgetOrderType.Limit, 0.001m, 40000, BitgetTriggerType.FillPrice, 39000);
```
### Requesting a specific order
```csharp
// Request info on order with id `1234`
var orderData = await bitgetRestClient.SpotApi.Trading.GetOrderAsync("BTCUSDT_SPBL", "1234");
```

### Requesting order history
```csharp
// Get all orders conform the parameters
 var ordersData = await bitgetRestClient.SpotApi.Trading.GetOrderHistoryAsync("BTCUSDT_SPBL");
```

### Cancel order
```csharp
// Cancel order with id `1234`
var orderData = await bitgetRestClient.SpotApi.Trading.CancelOrderAsync("BTCUSDT_SPBL", "1234");
```

### Get user trades
```csharp
var userTradesResult = await bitgetRestClient.SpotApi.Trading.GetUserTradesAsync("BTCUSDT_SPBL");
```

### Subscribing to market data updates
```csharp
var subscribeResult = await bitgetSocketClient.SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT_SPBL", data =>
{
    // Handle ticker data
});
```

### Subscribing to order updates
```csharp
var subscribeResult = 
await bitgetSocketClient.SpotApi.SubscribeToOrderUpdatesAsync(data =>
{
    // Handle order data
});
```

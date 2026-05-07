// 01-spot-quickstart.cs
//
// Demonstrates: Bitget V2 spot market data, balances and order flow.
//
// Setup: dotnet add package JK.Bitget.Net

using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Enums.V2;

var client = new BitgetRestClient(options =>
{
    options.ApiCredentials = new BitgetCredentials("API_KEY", "API_SECRET", "PASSPHRASE");
});

const string symbol = "BTCUSDT";

// ---- 1. PUBLIC MARKET DATA ----
var ticker = await client.SpotApiV2.ExchangeData.GetTickersAsync(symbol);
if (!ticker.Success)
{
    Console.WriteLine($"Ticker failed: {ticker.Error}");
    return;
}

var btcTicker = ticker.Data.Single();
Console.WriteLine($"{btcTicker.Symbol} last price: {btcTicker.LastPrice}");
Console.WriteLine($"{btcTicker.Symbol} 24h base volume: {btcTicker.Volume}");

// ---- 2. AUTHENTICATED ACCOUNT DATA ----
var balances = await client.SpotApiV2.Account.GetSpotBalancesAsync();
if (!balances.Success)
{
    Console.WriteLine($"Balances failed: {balances.Error}");
    return;
}

foreach (var balance in balances.Data.Where(x => x.Asset is "BTC" or "USDT"))
{
    Console.WriteLine($"{balance.Asset}: available={balance.Available}, frozen={balance.Frozen}");
}

// ---- 3. PLACE A SMALL LIMIT ORDER ----
var order = await client.SpotApiV2.Trading.PlaceOrderAsync(
    symbol: symbol,
    side: OrderSide.Buy,
    type: OrderType.Limit,
    quantity: 0.001m,
    timeInForce: TimeInForce.GoodTillCanceled,
    price: 1m);

if (!order.Success)
{
    Console.WriteLine($"Order rejected: {order.Error}");
    return;
}

Console.WriteLine($"Placed spot order {order.Data.OrderId}");

var openOrders = await client.SpotApiV2.Trading.GetOpenOrdersAsync(symbol);
if (openOrders.Success)
{
    Console.WriteLine($"Open spot orders on {symbol}: {openOrders.Data.Length}");
}

var cancel = await client.SpotApiV2.Trading.CancelOrderAsync(
    symbol: symbol,
    orderId: order.Data.OrderId);

Console.WriteLine(cancel.Success
    ? "Cancel request accepted"
    : $"Cancel failed: {cancel.Error}");

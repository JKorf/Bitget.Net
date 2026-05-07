// 02-futures-v2.cs
//
// Demonstrates: Bitget V2 futures product type, ticker, balances, positions and order flow.
//
// Setup: dotnet add package JK.Bitget.Net

using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

var client = new BitgetRestClient(options =>
{
    options.ApiCredentials = new BitgetCredentials("API_KEY", "API_SECRET", "PASSPHRASE");
});

var productType = BitgetProductTypeV2.UsdtFutures;
const string symbol = "BTCUSDT";
const string marginAsset = "USDT";

// ---- 1. PUBLIC FUTURES MARKET DATA ----
var ticker = await client.FuturesApiV2.ExchangeData.GetTickerAsync(productType, symbol);
if (!ticker.Success)
{
    Console.WriteLine($"Futures ticker failed: {ticker.Error}");
    return;
}

Console.WriteLine($"{ticker.Data.Symbol} futures last price: {ticker.Data.LastPrice}");
Console.WriteLine($"{ticker.Data.Symbol} mark price: {ticker.Data.MarkPrice}");

var funding = await client.FuturesApiV2.ExchangeData.GetFundingRateAsync(productType, symbol);
if (funding.Success)
{
    Console.WriteLine($"{symbol} funding rate: {funding.Data.FundingRate}");
}

// ---- 2. AUTHENTICATED FUTURES ACCOUNT DATA ----
var balances = await client.FuturesApiV2.Account.GetBalancesAsync(productType);
if (!balances.Success)
{
    Console.WriteLine($"Futures balances failed: {balances.Error}");
    return;
}

Console.WriteLine($"Futures balances returned: {balances.Data.Length}");

var positions = await client.FuturesApiV2.Trading.GetPositionsAsync(productType, marginAsset);
if (positions.Success)
{
    foreach (var position in positions.Data.Where(x => x.Symbol == symbol))
    {
        Console.WriteLine($"{position.Symbol} {position.PositionSide}: total={position.Total}, pnl={position.UnrealizedProfitAndLoss}");
    }
}

// ---- 3. PLACE A SMALL FUTURES LIMIT ORDER ----
var order = await client.FuturesApiV2.Trading.PlaceOrderAsync(
    productType: productType,
    symbol: symbol,
    marginAsset: marginAsset,
    side: OrderSide.Buy,
    type: OrderType.Limit,
    marginMode: MarginMode.CrossMargin,
    quantity: 0.001m,
    price: 1m,
    timeInForce: TimeInForce.GoodTillCanceled,
    tradeSide: TradeSide.Open);

if (!order.Success)
{
    Console.WriteLine($"Futures order rejected: {order.Error}");
    return;
}

Console.WriteLine($"Placed futures order {order.Data.OrderId}");

var cancel = await client.FuturesApiV2.Trading.CancelOrderAsync(
    productType: productType,
    symbol: symbol,
    orderId: order.Data.OrderId,
    marginAsset: marginAsset);

Console.WriteLine(cancel.Success
    ? "Futures cancel request accepted"
    : $"Futures cancel failed: {cancel.Error}");

using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

const string spotSymbol = "BTCUSDT";
const string futuresSymbol = "BTCUSDT";
const string marginAsset = "USDT";

// Replace with valid credentials or order placement will always fail
var apiKey = "API_KEY";
var apiSecret = "API_SECRET";
var passphrase = "PASSPHRASE";

Console.WriteLine("Bitget.Net V2 order placement example");
Console.WriteLine();
Console.WriteLine("This example can place real orders when valid credentials are configured.");
Console.WriteLine();

var client = new BitgetRestClient(options =>
{
    options.ApiCredentials = new BitgetCredentials(apiKey, apiSecret, passphrase);
});

await PlaceSpotLimitOrderAsync(client);
Console.WriteLine();
await PlaceFuturesReduceOnlyOrderExampleAsync(client);

static async Task PlaceSpotLimitOrderAsync(BitgetRestClient client)
{
    Console.WriteLine($"Placing spot V2 limit buy order for {spotSymbol}...");

    var ticker = await client.SpotApiV2.ExchangeData.GetTickersAsync(spotSymbol);
    if (!ticker.Success)
    {
        Console.WriteLine($"Failed to get spot ticker: {ticker.Error}");
        return;
    }

    var safePrice = Math.Round(ticker.Data.Single().LastPrice * 0.95m, 2);
    var order = await client.SpotApiV2.Trading.PlaceOrderAsync(
        symbol: spotSymbol,
        side: OrderSide.Buy,
        type: OrderType.Limit,
        quantity: 0.001m,
        timeInForce: TimeInForce.GoodTillCanceled,
        price: safePrice);

    if (!order.Success)
    {
        Console.WriteLine($"Failed to place spot order: {order.Error}");
        return;
    }

    Console.WriteLine($"Placed spot order {order.Data.OrderId}");

    var orderStatus = await client.SpotApiV2.Trading.GetOrderAsync(order.Data.OrderId);
    if (orderStatus.Success)
    {
        foreach (var status in orderStatus.Data)
            Console.WriteLine($"Spot order status: {status.Status}, filled: {status.QuantityFilled}");
    }
    else
    {
        Console.WriteLine($"Failed to query spot order: {orderStatus.Error}");
    }

    var cancel = await client.SpotApiV2.Trading.CancelOrderAsync(spotSymbol, order.Data.OrderId);
    Console.WriteLine(cancel.Success
        ? $"Cancelled spot order {order.Data.OrderId}"
        : $"Failed to cancel spot order: {cancel.Error}");
}

static async Task PlaceFuturesReduceOnlyOrderExampleAsync(BitgetRestClient client)
{
    Console.WriteLine($"Placing futures V2 reduce-only limit sell order for {futuresSymbol}...");

    var ticker = await client.FuturesApiV2.ExchangeData.GetTickerAsync(BitgetProductTypeV2.UsdtFutures, futuresSymbol);
    if (!ticker.Success)
    {
        Console.WriteLine($"Failed to get futures ticker: {ticker.Error}");
        return;
    }

    var safePrice = Math.Round(ticker.Data.LastPrice * 1.05m, 2);
    var order = await client.FuturesApiV2.Trading.PlaceOrderAsync(
        productType: BitgetProductTypeV2.UsdtFutures,
        symbol: futuresSymbol,
        marginAsset: marginAsset,
        side: OrderSide.Sell,
        type: OrderType.Limit,
        marginMode: MarginMode.CrossMargin,
        quantity: 0.001m,
        price: safePrice,
        timeInForce: TimeInForce.GoodTillCanceled,
        tradeSide: TradeSide.Close,
        reduceOnly: true);

    if (!order.Success)
    {
        Console.WriteLine($"Failed to place futures order: {order.Error}");
        return;
    }

    Console.WriteLine($"Placed futures order {order.Data.OrderId}");

    var orderStatus = await client.FuturesApiV2.Trading.GetOrderAsync(BitgetProductTypeV2.UsdtFutures, futuresSymbol, order.Data.OrderId);
    if (orderStatus.Success)
        Console.WriteLine($"Futures order status: {orderStatus.Data.Status}, filled: {orderStatus.Data.QuantityFilled}");
    else
        Console.WriteLine($"Failed to query futures order: {orderStatus.Error}");

    var cancel = await client.FuturesApiV2.Trading.CancelOrderAsync(
        productType: BitgetProductTypeV2.UsdtFutures,
        symbol: futuresSymbol,
        orderId: order.Data.OrderId,
        marginAsset: marginAsset);

    Console.WriteLine(cancel.Success
        ? $"Cancelled futures order {order.Data.OrderId}"
        : $"Failed to cancel futures order: {cancel.Error}");
}

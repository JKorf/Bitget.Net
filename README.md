# ![.Bitget.Net](https://github.com/JKorf/Bitget.Net/blob/main/Bitget.Net/Icon/icon.png?raw=true) Bitget.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/Bitget.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/Bitget.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/Bitget.Net?style=for-the-badge)

Bitget.Net is a client library for accessing the [Bitget REST and Websocket API](https://bitgetlimited.github.io/apidoc/en/spot). All data is mapped to readable models and enum values. Additional features include an implementation for maintaining a client side order book, easy integration with other exchange client libraries and more.

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility

|.NET implementation|Version Support|
|--|--|
|.NET Core|`2.0` and higher|
|.NET Framework|`4.6.1` and higher|
|Mono|`5.4` and higher|
|Xamarin.iOS|`10.14` and higher|
|Xamarin.Android|`8.0` and higher|
|UWP|`10.0.16299` and higher|
|Unity|`2018.1` and higher|

## Get the library
[![Nuget version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=for-the-badge)](https://www.nuget.org/packages/JK.Bitget.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/JK.Bitget.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/JK.Bitget.Net)

	dotnet add package JK.Bitget.Net

## How to use
*REST Endpoints*  

```csharp
// Get the ETH/USDT ticker via rest request
var restClient = new BitgetRestClient();
var tickerResult = await restClient.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT_SPBL");
var lastPrice = tickerResult.Data.ClosePrice;
```
*Websocket streams*  

```csharp
// Subscribe to ETH/USDT ticker updates via the websocket API
var socketClient = new BitgetSocketClient();
var tickerSubscriptionResult = socketClient.SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", (update) => 
{
  var lastPrice = update.Data.LastPrice;
});
```

For information on the clients, dependency injection, response processing and more see the [documentation](https://jkorf.github.io/CryptoExchange.Net), or have a look at the examples  [here](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples).

## CryptoExchange.Net
Biget.Net is based on the [CryptoExchange.Net](https://github.com/JKorf/CryptoExchange.Net) base library. Other exchange API implementations based on the CryptoExchange.Net base library are available and follow the same logic.

CryptoExchange.Net also allows for [easy access to different exchange API's](https://jkorf.github.io/CryptoExchange.Net#idocs_common).

|Exchange|Repository|Nuget|
|--|--|--|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|Bybit|[JKorf/Bybit.Net](https://github.com/JKorf/Bybit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg?style=flat-square)](https://www.nuget.org/packages/Bybit.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|Huobi/HTX|[JKorf/Huobi.Net](https://github.com/JKorf/Huobi.Net)|[![Nuget version](https://img.shields.io/nuget/v/Huobi.net.svg?style=flat-square)](https://www.nuget.org/packages/Huobi.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|

## Discord
[![Nuget version](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)  
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Supported functionality

*The library currently uses the V1 API, it will be updated to V2 soon*

### Spot
|API|Supported|Location|
|--|--:|--|
|Rest Public|✓|`restClient.SpotApi.ExchangeData`|
|Rest Market|✓|`restClient.SpotApi.ExchangeData`|
|Rest Wallet|✓|`restClient.SpotApi.Account`|
|Rest Account|✓|`restClient.SpotApi.Account`|
|Rest Trade|✓|`restClient.SpotApi.Trading`|
|Rest P2P|X||
|Rest Sub-Account|X||
|Rest Convert|X||
|Websocket Public|✓|`socketClient.SpotApi`|
|Websocket Private|✓|`socketClient.SpotApi`|

### Futures USDT/Coin
|API|Supported|Location|
|--|--:|--|
|Rest Market|✓|`restClient.SpotApi.ExchangeData`|
|Rest Account|✓|`restClient.SpotApi.Account`|
|Rest Trade|✓|`restClient.SpotApi.Trading`|
|Websocket Public|✓|`socketClient.SpotApi`|
|Websocket Private|✓|`socketClient.SpotApi`|

### Broker
|API|Supported|Location|
|--|--:|--|
|*|X||

### Spot Margin
|API|Supported|Location|
|--|--:|--|
|*|X||

### Copy Trading
|API|Supported|Location|
|--|--:|--|
|*|X||

## Support the project
I develop and maintain this package on my own for free in my spare time, any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1qz0jv0my7fc60rxeupr23e75x95qmlq6489n8gh  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7  

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf).

## Release notes
* Version 1.3.0 - 16 Mar 2024
    * Updated CryptoExchange.Net to 7.1.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes
    * Updated unit test package dependencies and updated tests accordingly
	
* Version 1.2.0 - 10 Mar 2024
    * Updated GetBillsAsync endpoints to V2 API to fix some issues occurring with the V1 endpoints. Full update to the V2 API will follow later

* Version 1.1.2 - 08 Mar 2024
    * Fixed deserialization error for nullable UpdateTime properties

* Version 1.1.1 - 08 Mar 2024
    * Fixed Socket Futures subscription data handling

* Version 1.1.0 - 25 Feb 2024
    * Updated CryptoExchange.Net and implemented reworked websocket message handling. For release notes for the CryptoExchange.Net base library see here: https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes
    * Fixed issue in DI registration causing http client to not be correctly injected
    * Updated some namespaces

* Version 1.0.7 - 05 Feb 2024
    * Added FuturesApi.Trading.GetPlanOrdersAsync endpoint
    * Fixed futures order update deserialization when filled

* Version 1.0.6 - 19 Jan 2024
    * Fixed V5.Trading.GetPlanOrderHistoryAsync
    * Added missing PlanType enum value

* Version 1.0.5 - 16 Jan 2024
    * Updated PlanType enum
    * Added UpdateTime to BitgetPosition model

* Version 1.0.4 - 23 Dec 2023
    * Fixed deserialization issues Symbol models

* Version 1.0.3 - 03 Dec 2023
    * Updated CryptoExchange.Net
    * Fixed nullability on BitgetSymbol model

* Version 1.0.2 - 23 Nov 2023
    * Fixed FuturesApi.Trading.PlacePlanOrderAsync quantity serialization

* Version 1.0.1 - 22 Nov 2023
    * Fixed FuturesApi.Trading.GetOpenOrders deserialization error

* Version 1.0.0 - 24 Oct 2023
    * Updated CryptoExchange.Net

* Version 0.0.1 - 09 Oct 2023
    * Initial release


# ![.Bitget.Net](https://github.com/JKorf/Bitget.Net/blob/main/Bitget.Net/Icon/icon.png?raw=true) Bitget.Net

[![.NET](https://img.shields.io/github/actions/workflow/status/JKorf/Bitget.Net/dotnet.yml?style=for-the-badge)](https://github.com/JKorf/Bitget.Net/actions/workflows/dotnet.yml) ![License](https://img.shields.io/github/license/JKorf/Bitget.Net?style=for-the-badge)

Bitget.Net is a strongly typed client library for accessing the [Bitget REST and Websocket API](https://bitgetlimited.github.io/apidoc/en/spot).
## Features
* Response data is mapped to descriptive models
* Input parameters and response values are mapped to discriptive enum values where possible
* Automatic websocket (re)connection management 
* Client side rate limiting 
* Client side order book implementation
* Extensive logging
* Support for different environments
* Easy integration with other exchange client based on the CryptoExchange.Net base library
* Native AOT support

## Supported Frameworks
The library is targeting both `.NET Standard 2.0` and `.NET Standard 2.1` for optimal compatibility, as well as dotnet 8.0 and 9.0 to use the latest framework features.

|.NET implementation|Version Support|
|--|--|
|.NET Core|`2.0` and higher|
|.NET Framework|`4.6.1` and higher|
|Mono|`5.4` and higher|
|Xamarin.iOS|`10.14` and higher|
|Xamarin.Android|`8.0` and higher|
|UWP|`10.0.16299` and higher|
|Unity|`2018.1` and higher|

## Install the library

### NuGet 
[![NuGet version](https://img.shields.io/nuget/v/JK.Bitget.net.svg?style=for-the-badge)](https://www.nuget.org/packages/JK.Bitget.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/JK.Bitget.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/JK.Bitget.Net)

	dotnet add package JK.Bitget.Net
	
### GitHub packages
Bitget.Net is available on [GitHub packages](https://github.com/JKorf/Bitget.Net/pkgs/nuget/JK.Bitget.Net). You'll need to add `https://nuget.pkg.github.com/JKorf/index.json` as a NuGet package source.

### Download release
[![GitHub Release](https://img.shields.io/github/v/release/JKorf/Bitget.Net?style=for-the-badge&label=GitHub)](https://github.com/JKorf/Bitget.Net/releases)

The NuGet package files are added along side the source with the latest GitHub release which can found [here](https://github.com/JKorf/Bitget.Net/releases).

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

For information on the clients, dependency injection, response processing and more see the [Bitget.Net documentation](https://cryptoexchange.jkorf.dev?library=Bitget.Net) or have a look at the examples [here](https://github.com/JKorf/Bitget.Net/tree/main/Examples) or [here](https://github.com/JKorf/CryptoExchange.Net/tree/master/Examples).

## CryptoExchange.Net
Biget.Net is based on the [CryptoExchange.Net](https://github.com/JKorf/CryptoExchange.Net) base library. Other exchange API implementations based on the CryptoExchange.Net base library are available and follow the same logic.

CryptoExchange.Net also allows for [easy access to different exchange API's](https://cryptoexchange.jkorf.dev/client-libs/shared).

|Exchange|Repository|Nuget|
|--|--|--|
|Binance|[JKorf/Binance.Net](https://github.com/JKorf/Binance.Net)|[![Nuget version](https://img.shields.io/nuget/v/Binance.net.svg?style=flat-square)](https://www.nuget.org/packages/Binance.Net)|
|BingX|[JKorf/BingX.Net](https://github.com/JKorf/BingX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.BingX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.BingX.Net)|
|Bitfinex|[JKorf/Bitfinex.Net](https://github.com/JKorf/Bitfinex.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bitfinex.net.svg?style=flat-square)](https://www.nuget.org/packages/Bitfinex.Net)|
|BitMart|[JKorf/BitMart.Net](https://github.com/JKorf/BitMart.Net)|[![Nuget version](https://img.shields.io/nuget/v/BitMart.net.svg?style=flat-square)](https://www.nuget.org/packages/BitMart.Net)|
|BitMEX|[JKorf/BitMEX.Net](https://github.com/JKorf/BitMEX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.BitMEX.net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.BitMEX.Net)|
|Bybit|[JKorf/Bybit.Net](https://github.com/JKorf/Bybit.Net)|[![Nuget version](https://img.shields.io/nuget/v/Bybit.net.svg?style=flat-square)](https://www.nuget.org/packages/Bybit.Net)|
|Coinbase|[JKorf/Coinbase.Net](https://github.com/JKorf/Coinbase.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.Coinbase.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.Coinbase.Net)|
|CoinEx|[JKorf/CoinEx.Net](https://github.com/JKorf/CoinEx.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinEx.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinEx.Net)|
|CoinGecko|[JKorf/CoinGecko.Net](https://github.com/JKorf/CoinGecko.Net)|[![Nuget version](https://img.shields.io/nuget/v/CoinGecko.net.svg?style=flat-square)](https://www.nuget.org/packages/CoinGecko.Net)|
|Crypto.com|[JKorf/CryptoCom.Net](https://github.com/JKorf/CryptoCom.Net)|[![Nuget version](https://img.shields.io/nuget/v/CryptoCom.net.svg?style=flat-square)](https://www.nuget.org/packages/CryptoCom.Net)|
|DeepCoin|[JKorf/DeepCoin.Net](https://github.com/JKorf/DeepCoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/DeepCoin.net.svg?style=flat-square)](https://www.nuget.org/packages/DeepCoin.Net)|
|Gate.io|[JKorf/GateIo.Net](https://github.com/JKorf/GateIo.Net)|[![Nuget version](https://img.shields.io/nuget/v/GateIo.net.svg?style=flat-square)](https://www.nuget.org/packages/GateIo.Net)|
|HTX|[JKorf/HTX.Net](https://github.com/JKorf/HTX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JKorf.HTX.Net.svg?style=flat-square)](https://www.nuget.org/packages/JKorf.HTX.Net)|
|HyperLiquid|[JKorf/HyperLiquid.Net](https://github.com/JKorf/HyperLiquid.Net)|[![Nuget version](https://img.shields.io/nuget/v/HyperLiquid.Net.svg?style=flat-square)](https://www.nuget.org/packages/HyperLiquid.Net)|
|Kraken|[JKorf/Kraken.Net](https://github.com/JKorf/Kraken.Net)|[![Nuget version](https://img.shields.io/nuget/v/KrakenExchange.net.svg?style=flat-square)](https://www.nuget.org/packages/KrakenExchange.Net)|
|Kucoin|[JKorf/Kucoin.Net](https://github.com/JKorf/Kucoin.Net)|[![Nuget version](https://img.shields.io/nuget/v/Kucoin.net.svg?style=flat-square)](https://www.nuget.org/packages/Kucoin.Net)|
|Mexc|[JKorf/Mexc.Net](https://github.com/JKorf/Mexc.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.Mexc.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.Mexc.Net)|
|OKX|[JKorf/OKX.Net](https://github.com/JKorf/OKX.Net)|[![Nuget version](https://img.shields.io/nuget/v/JK.OKX.net.svg?style=flat-square)](https://www.nuget.org/packages/JK.OKX.Net)|
|WhiteBit|[JKorf/WhiteBit.Net](https://github.com/JKorf/WhiteBit.Net)|[![Nuget version](https://img.shields.io/nuget/v/WhiteBit.net.svg?style=flat-square)](https://www.nuget.org/packages/WhiteBit.Net)|
|XT|[JKorf/XT.Net](https://github.com/JKorf/XT.Net)|[![Nuget version](https://img.shields.io/nuget/v/XT.net.svg?style=flat-square)](https://www.nuget.org/packages/XT.Net)|

## Discord
[![Nuget version](https://img.shields.io/discord/847020490588422145?style=for-the-badge)](https://discord.gg/MSpeEtSY8t)  
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Supported functionality

*Both V1 API and V2 are currently supported*

### V2  
#### Spot
|API|Supported|Location|
|--|--:|--|
|Rest Market|✓|`restClient.SpotApiV2.ExchangeData`|
|Rest Trade|✓|`restClient.SpotApiV2.Trading`|
|Rest Trigger|✓|`restClient.SpotApi.Account`|
|Rest Account|✓|`restClient.SpotApi.Account`|
|Websocket Public|✓|`socketClient.SpotApiV2`|
|Websocket Private|✓|`socketClient.SpotApiV2`|

#### Future (usdt/usdc/coin)
|API|Supported|Location|
|--|--:|--|
|Rest Market|✓|`restClient.FuturesApiV2.ExchangeData`|
|Rest Account|✓|`restClient.FuturesApiV2.Account`|
|Rest Position|✓|`restClient.FuturesApiV2.Trading`|
|Rest Trade|✓|`restClient.FuturesApiV2.Trading`|
|Rest Trigger Order|✓|`restClient.FuturesApiV2.Trading`|
|Websocket Public|✓|`socketClient.FuturesApiV2`|
|Websocket Private|✓|`socketClient.FuturesApiV2`|

#### Margin
|API|Supported|Location|
|--|--:|--|
|Common|✓|`restClient.SpotApiV2.Margin`|
|Rest Cross|✓|`restClient.SpotApiV2.Margin`|
|Rest Isolated|✓|`restClient.SpotApiV2.Margin`|
|Websocket|✓|`socketClient.SpotApiV2`|

### V1  
#### Spot
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

#### Futures USDT/Coin
|API|Supported|Location|
|--|--:|--|
|Rest Market|✓|`restClient.FuturesApi.ExchangeData`|
|Rest Account|✓|`restClient.FuturesApi.Account`|
|Rest Trade|✓|`restClient.FuturesApi.Trading`|
|Websocket Public|✓|`socketClient.FuturesApi`|
|Websocket Private|✓|`socketClient.FuturesApi`|


## Support the project
Any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1q277a5n54s2l2mzlu778ef7lpkwhjhyvghuv8qf  
**Eth**:  0xcb1b63aCF9fef2755eBf4a0506250074496Ad5b7   
**USDT (TRX)**  TKigKeJPXZYyMVDgMyXxMf17MWYia92Rjd

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf).

## Release notes
* Version 2.0.0 - 13 May 2025
    * Updated CryptoExchange.Net to version 9.0.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for Native AOT compilation
    * Added RateLimitUpdated event
    * Added SharedSymbol response property to all Shared interfaces response models returning a symbol name
    * Added GenerateClientOrderId method to Futures and Spot Shared clients
    * Added OptionalExchangeParameters and Supported properties to EndpointOptions
    * Added IBookTickerRestClient implementation to Futures and Spot Shared clients
    * Added IFuturesOrderClientIdClient implementation to Futures Shared client
    * Added IFuturesTriggerOrderRestClient implementation to Futures Shared client
    * Added IFuturesTpSlRestClient implementation to Futures Shared client
    * Added ISpotOrderClientIdClient implementation to Spot Shared client
    * Added ISpotTriggerOrderRestClient implementation to Futures Shared client
    * Added MaxShortLeverage and MaxLongLeverage to SharedFuturesSymbol response model
    * Added support for takeProfitPrice and StopLossPrice to Futures Shared PlaceOrderAsync endpoint
    * Added TakeProfitPrice and StopLossPrice properties to SharedFuturesOrder response model
    * Added TriggerPrice and IsTriggerOrder properties to SharedFuturesOrder response model
    * Added QuoteVolume property mapping to SharedSpotTicker response model
    * Added restClient.FuturesApiV2.Account.GetAdlRankAsync endpoint
    * Added restClient.FuturesApiV2.ExchangeData.GetFundingRatesAsync endpoint
    * Added restClient.SpotApiV2.Margin.GetInterestRatesAsync endpoint
    * Added restClient.SpotApiV2.ExchangeData.GetAnnouncementsAsync endpoint
    * Added All property to retrieve all available environment on BitgetEnvironment
    * Added takeProfitLimitPrice, stopLossLimitPrice parameters to restClient.FuturesApiV2.Trading.PlaceOrderAsync endpoint
    * Added UpdateTime to BitgetMarginOrderUpdate model
    * Added idLessThan, limit parameters to restClient.SpotApiV2.Account.GetSubAccountBalancesAsync
    * Refactored Shared clients quantity parameters and responses to use SharedQuantity
    * Updated all IEnumerable response and model types to array response types
    * Updated PlaceMultipleOrdersAsync methods to return a list of CallResult models and an error if all orders fail to place
    * Updated restClient.FuturesApiV2.ExchangeData.GetFundingRateAsync response model
    * Updated restClient.SpotApiV2.Trading.GetUserTradesAsync symbol parameter to nullable
    * Updated Shared Spot GetTradeHistoryAsync max age from 30 to 90 days
    * Replaced BitgetApiCredentials with ApiCredentials
    * Fixed incorrect DataTradeMode on certain Shared interface responses
    * Fixed Shared interfaces AveragePrice property being 0 instead of null
    * Removed V1 API support
    * Removed Newtonsoft.Json dependency
    * Removed legacy AddBitget(restOptions, socketOptions) DI overload
    * Fixed some typos

* Version 2.0.0-beta3 - 01 May 2025
    * Updated CryptoExchange.Net version to 9.0.0-beta5
    * Added property to retrieve all available API environments

* Version 2.0.0-beta2 - 23 Apr 2025
    * Updated CryptoExchange.Net to version 9.0.0-beta2
    * Added Shared spot ticker QuoteVolume mapping
    * Fixed incorrect DataTradeMode on responses

* Version 2.0.0-beta1 - 22 Apr 2025
    * Updated CryptoExchange.Net to version 9.0.0-beta1, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for Native AOT compilation
    * Added RateLimitUpdated event
    * Added SharedSymbol response property to all Shared interfaces response models returning a symbol name
    * Added GenerateClientOrderId method to Futures and Spot Shared clients
    * Added OptionalExchangeParameters and Supported properties to EndpointOptions
    * Added IBookTickerRestClient implementation to Futures and Spot Shared clients
    * Added IFuturesOrderClientIdClient implementation to Futures Shared client
    * Added IFuturesTriggerOrderRestClient implementation to Futures Shared client
    * Added IFuturesTpSlRestClient implementation to Futures Shared client
    * Added ISpotOrderClientIdClient implementation to Spot Shared client
    * Added ISpotTriggerOrderRestClient implementation to Futures Shared client
    * Added MaxShortLeverage and MaxLongLeverage to SharedFuturesSymbol response model
    * Added support for takeProfitPrice and StopLossPrice to Futures Shared PlaceOrderAsync endpoint
    * Added TakeProfitPrice and StopLossPrice properties to SharedFuturesOrder response model
    * Added TriggerPrice and IsTriggerOrder properties to SharedFuturesOrder response model
    * Added restClient.FuturesApiV2.Account.GetAdlRankAsync endpoint
    * Refactored Shared clients quantity parameters and responses to use SharedQuantity
    * Updated all IEnumerable response and model types to array response types
    * Updated PlaceMultipleOrdersAsync methods to return a list of CallResult models and an error if all orders fail to place
    * Updated restClient.FuturesApiV2.ExchangeData.GetFundingRateAsync response model
    * Updated restClient.SpotApiV2.Trading.GetUserTradesAsync symbol parameter to nullable
    * Replaced BitgetApiCredentials with ApiCredentials
    * Removed V1 API support
    * Removed Newtonsoft.Json dependency
    * Removed legacy AddBitget(restOptions, socketOptions) DI overload
    * Fixed some typos

* Version 1.22.1 - 28 Mar 2025
    * Fixed ProductType parsing for shared socket subscriptions

* Version 1.22.0 - 24 Mar 2025
    * Added demo trading environment
    * Added restClient.FuturesApiV2.ExchangeData.GetOiLimitsAsync endpoint
    * Added CrossRiskRate and UnrealizedPnl properties to futures balance websocket update model
    * Added missing Trigger Order Plan Type Enum values

* Version 1.21.0 - 11 Feb 2025
    * Updated CryptoExchange.Net to version 8.8.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added support for more SharedKlineInterval values
    * Added setting of DataTime value on websocket DataEvent updates
    * Added initial futures CopyTrader endpoints
    * Updated BitgetFuturesTriggerOrder response model
    * Fix Mono runtime exception on rest client construction using DI

* Version 1.20.0 - 28 Jan 2025
    * Added restClient.SpotApiV2.Trading.CancelReplaceOrderAsync endpoint
    * Added restClient.SpotApiV2.Trading.CancelReplaceMultipleOrdersAsync endpoint
    * Added TakeProfit/StopLoss parameters to SpotApiV2 place order endpoints
    * Fixed restClient.SpotApiV2.Margin.GetIsolatedRiskRateAsync response parsing

* Version 1.19.2 - 25 Jan 2025
    * Fixed an issue with data not being parsed correctly for certain models

* Version 1.19.1 - 07 Jan 2025
    * Updated CryptoExchange.Net version
    * Added Type property to BitgetExchange class

* Version 1.19.0 - 23 Dec 2024
    * Updated CryptoExchange.Net to version 8.5.0, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Added SetOptions methods on Rest and Socket clients
    * Added setting of DefaultProxyCredentials to CredentialCache.DefaultCredentials on the DI http client
    * Added page parameter to restClient.SpotApi.Account.GetTransferHistoryAsync, marked idLessThan as deprecated
    * Improved websocket disconnect detection

* Version 1.18.1 - 03 Dec 2024
    * Updated CryptoExchange.Net to version 8.4.3, see https://github.com/JKorf/CryptoExchange.Net/releases/
    * Fixed orderbook creation via BitgetOrderBookFactory

* Version 1.18.0 - 28 Nov 2024
    * Updated CryptoExchange.Net to version 8.4.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.4.0
    * Added GetFeesAsync Shared REST client implementations
    * Updated BitgetOptions to LibraryOptions implementation
    * Updated test and analyzer package versions

* Version 1.17.0 - 25 Nov 2024
    * Added restClient.SpotApiV2.Account.TransferSubAccountAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountBalancesAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountTransferHistoryAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountDepositAddressAsync endpoint
    * Added restClient.SpotApiV2.Account.GetSubAccountDepositHistoryAsync endpoint
    * Added websocket rate limiting rules
    * Fixed restClient.SetApiCredentials having incorrect ApiCredentials type

* Version 1.16.0 - 19 Nov 2024
    * Updated CryptoExchange.Net to version 8.3.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.3.0
    * Added support for loading client settings from IConfiguration
    * Added DI registration method for configuring Rest and Socket options at the same time
    * Added DisplayName and ImageUrl properties to BitgetExchange class
    * Updated client constructors to accept IOptions from DI
    * Changed restClient.FuturesApiV2.Account.GetLedgerAsync idLessThan parameter to long type to match response model id type
    * Removed redundant BitgetSocketClient constructor

* Version 1.15.1 - 15 Nov 2024
    * Added missing futures trigger order statuses

* Version 1.15.0 - 14 Nov 2024
    * Added status filter to restClient.FuturesApiV2.Trading.GetClosedTriggerOrdersAsync
    * Updated restClient.FuturesApiV2.Account.GetLedgerAsync response model

* Version 1.14.0 - 11 Nov 2024
    * Split and corrected futures trigger plan type parameters

* Version 1.13.0 - 06 Nov 2024
    * Updated CryptoExchange.Net to version 8.2.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.2.0

* Version 1.12.0 - 04 Nov 2024
    * Added Cross and Isolated Margin API implementation
    * Fixed V1 API GET request authentication for requests without parameters
    * Fixed warning log when subscribing multiple symbols at the same time

* Version 1.11.0 - 28 Oct 2024
    * Updated CryptoExchange.Net to version 8.1.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.1.0
    * Moved FormatSymbol to BitgetExchange class
    * Added support Side setting on SharedTrade model
    * Added BitgetTrackerFactory for creating trackers
    * Added overload to Create method on BitgetOrderBookFactory support SharedSymbol parameter

* Version 1.10.4 - 15 Oct 2024
    * Fixed V1 GET request signing without parameters
    * Fixed request signing V2 with special characters
    * Fixed restClient.SpotApi.Trading.GetOrderAsync exception when order not found

* Version 1.10.3 - 14 Oct 2024
    * Updated CryptoExchange.Net to version 8.0.3, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.0.3
    * Fixed TypeLoadException during initialization

* Version 1.10.2 - 14 Oct 2024
    * Fixed V1 request signing where query parameters contain special characters

* Version 1.10.1 - 08 Oct 2024
    * Added BitgetSymbolStatus.Halt Enum value
    * Added converting to uppercase for CancelAllOrdersAsync marginAsset parameter
    * Fixed FutureApiV2.Trading.CancelTriggerOrdersAsync endpoint

* Version 1.10.0 - 27 Sep 2024
    * Updated CryptoExchange.Net to version 8.0.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/8.0.0
    * Added Shared client interfaces implementation for Spot Rest and Socket clients
    * Added oneWaySide parameter to FuturesV2.Trading.PlaceTpSlOrderAsync and renamed positionSide parameter to hedgeModePositionSide
    * Updated QuoteQuantityFilled property name to QuoteQuantity on BitgetFuturesOrderUpdate
    * Updated LastTradeId property type from decimal to string? on BitgetFuturesOrderUpdate
    * Updated LastTradeQuantity, AveragePrice, LastTradeFillPrice and LastTradeFillTime property types from decimal to decimal? on BitgetFuturesOrderUpdate
    * Updated BitgetStreamKlineIntervalV2 Enum values to match number of seconds
    * Updated QuantityDecimals and PriceDecimals property types from decimal to int on BitgetContract model
    * Updated Sourcelink package version
    * Fixed FuturesV2.ExchangeData.GetNextFundingTimeAsync potentially throwing InvalidOperationException
    * Fixed various endpoints on FuturesV2.Trading returning null data instead of empty collection
    * Fixed typo in IsolatedMarginProfitAndLoss property on BitgetFuturesBalance model
    * Fixed websocket message identification on subscriptions without symbol parameter
    * Marked ISpotClient references as deprecated

* Version 1.9.5 - 19 Sep 2024
    * Fixed ClientOrderId websocket order update deserialization

* Version 1.9.4 - 11 Sep 2024
    * Fixed UsdcPerpetualSimulated Enum value serialization

* Version 1.9.3 - 28 Aug 2024
    * Updated CryptoExchange.Net to version 7.11.2, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.11.2
    * Added missing Price property on SpotApi websocket order update model

* Version 1.9.2 - 23 Aug 2024
    * Fixed deserialization issue in FuturesApiV2.Account.SetLeverageAsync and SetMarginModeAsync response

* Version 1.9.1 - 18 Aug 2024
    * Added PositionId to FuturesApiV2.Trading.GetPositionHistoryAsync response model
    * Updated some endpoint ratelimits

* Version 1.9.0 - 07 Aug 2024
    * Updated CryptoExchange.Net to version 7.11.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.11.0
    * Updated XML code comments
    * Fixed order status and order type deserialization futures models

* Version 1.8.0 - 27 Jul 2024
    * Updated CryptoExchange.Net to version 7.10.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.10.0
    * Fixed body serialization FuturesV2, fixing PlaceMultipleOrders and CancelMultipleOrdersAsync endpoints
    * Fixed futures plan type parameters
    * Fixed spot GetHistoricalKlinesAsync endTime parameter being required
    * Fixed BitgetFuturesOrder response mapping

* Version 1.7.0 - 16 Jul 2024
    * Updated CryptoExchange.Net to version 7.9.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.9.0
    * Updated internal classes to internal access modifier
    * Fixed deserialization error on BitgetPosition model
    * Fixed positionSide parameter on FuturesApiV2.Trading.PlaceOrderAsync endpoint
    * Fixed websocket error response identification
    * Fixed CreateTime and UpdateTime deserialization on FuturesApiV2.Trading.GetPositionHistoryAsync

* Version 1.6.1 - 02 Jul 2024
    * Updated CryptoExchange.Net to V7.8.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.8.0
    * Updated ratelimiting for per-endpoint limits

* Version 1.6.0 - 28 Jun 2024
    * Fixed V1 socket subscriptions
    * Fixed FuturesApiV2.Trading.GetOpenOrdersAsync deserialization
    * Updated V2 websocket kline interval Enum values

* Version 1.5.1 - 25 Jun 2024
    * Updated CryptoExchange.Net to 7.7.2, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.7.2
    * Fixed deserialization of nullable int values
    * Fixed SpotApiV2.ExchangeData.GetSymbolsAsync deserialization

* Version 1.5.0 - 23 Jun 2024
    * Updated CryptoExchange.Net to version 7.7.0, see https://github.com/JKorf/CryptoExchange.Net/releases/tag/7.7.0
    * Added V2 SpotApi and V2 Futures API implementation

* Version 1.4.0 - 11 Jun 2024
    * Updated CryptoExchange.Net to v7.6.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.8 - 02 Jun 2024
    * Added simulated product types to BitgetInstrumentType enum

* Version 1.3.7 - 07 May 2024
    * Fixed SpotApi.Account.GetDepositHistoryAsync deserialization
    * Updated CryptoExchange.Net to v7.5.2, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.6 - 01 May 2024
    * Updated CryptoExchange.Net to v7.5.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.5 - 28 Apr 2024
    * Added BitgetExchange static info class
    * Added BitgetOrderBookFactory book creation method
    * Fixed BitgetOrderBookFactory injection issue
    * Updated CryptoExchange.Net to v7.4.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.4 - 23 Apr 2024
    * Updated CryptoExchange.Net to 7.3.3, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.3 - 18 Apr 2024
    * Updated CryptoExchange.Net to 7.3.1, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes
    * Fixed SpotApi.Account.GetWithdrawalHistoryAsync timestamp filters

* Version 1.3.2 - 04 Apr 2024
    * Fixed websocket kline deserialization
    * Fixed WithdrawAsync parameter serialization

* Version 1.3.1 - 24 Mar 2024
	* Updated CryptoExchange.Net to 7.2.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes

* Version 1.3.0 - 16 Mar 2024
    * Updated CryptoExchange.Net to 7.1.0, see https://github.com/JKorf/CryptoExchange.Net?tab=readme-ov-file#release-notes for release notes
	
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


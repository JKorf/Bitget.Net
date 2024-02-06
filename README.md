# Bitget.Net
[![.NET](https://github.com/JKorf/Bitget.Net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/JKorf/Bitget.Net/actions/workflows/dotnet.yml) [![Nuget version](https://img.shields.io/nuget/v/jk.bitget.net.svg)](https://www.nuget.org/packages/JK.Bitget.Net)  [![Nuget downloads](https://img.shields.io/nuget/dt/JK.Bitget.Net.svg)](https://www.nuget.org/packages/JK.Bitget.Net)

Bitget.Net is a wrapper around the Bitget API as described on [Bitget](https://bitgetlimited.github.io/apidoc/en/spot), including all features the API provides using clear and readable objects, both for the REST  as the websocket API's.

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/JKorf/Bitget.Net/issues)**

[Documentation](https://jkorf.github.io/Bitget.Net/)

## Installation
`dotnet add package JK.Bitget.Net`

## Support the project
I develop and maintain this package on my own for free in my spare time, any support is greatly appreciated.

### Donate
Make a one time donation in a crypto currency of your choice. If you prefer to donate a currency not listed here please contact me.

**Btc**:  bc1qz0jv0my7fc60rxeupr23e75x95qmlq6489n8gh  
**Eth**:  0x8E21C4d955975cB645589745ac0c46ECA8FAE504  

### Sponsor
Alternatively, sponsor me on Github using [Github Sponsors](https://github.com/sponsors/JKorf).

## Discord
A Discord server is available [here](https://discord.gg/MSpeEtSY8t). Feel free to join for discussion and/or questions around the CryptoExchange.Net and implementation libraries.

## Release notes
* Version 1.1.0-beta1 - 06 Feb 2024
    * Updated CryptoExchange.Net and implemented reworked websocket message handling. For release notes for the CryptoExchange.Net base library see here: https://github.com/JKorf/CryptoExchange.Net/tree/beta?tab=readme-ov-file#release-notes
    * Fixed issue in DI registration causing http client to not be correctly injected

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


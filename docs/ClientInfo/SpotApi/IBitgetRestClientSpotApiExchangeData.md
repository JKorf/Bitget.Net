---
title: IBitgetRestClientSpotApiExchangeData
has_children: false
parent: IBitgetRestClientSpotApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > SpotApi > ExchangeData`  
*Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetAssetsAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-list](https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-list)  
<p>

*Get a list of supported assets on the platform*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetAssetsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetAsset>>> GetAssetsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetFeeRatesAsync  

<p>

*Get limits according to the VIP levels*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetFeeRatesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoricalKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-history-candle-data](https://bitgetlimited.github.io/apidoc/en/spot/#get-history-candle-data)  
<p>

*Get historical kline/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetHistoricalKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetKline>>> GetHistoricalKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime endTime, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|interval|The kline interval|
|endTime|Filter by end time|
|_[Optional]_ limit|Results to return, max 1000|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-candle-data](https://bitgetlimited.github.io/apidoc/en/spot/#get-candle-data)  
<p>

*Get kline/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetKline>>> GetKlinesAsync(string symbol, BitgetKlineInterval interval, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|interval|The kline interval|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Results to return, max 1000|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMergedOrderBookAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-merged-depth-data](https://bitgetlimited.github.io/apidoc/en/spot/#get-merged-depth-data)  
<p>

*Get merged order book*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetMergedOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|_[Optional]_ mergeLevel|Merge level for entires|
|_[Optional]_ limit|Results to return, max 1000|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetNotificationsAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#notice](https://bitgetlimited.github.io/apidoc/en/spot/#notice)  
<p>

*Get server notifications of the last month*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetNotificationsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetNotification>>> GetNotificationsAsync(string languageType, string? noticeType = default, DateTime? startTime = default, DateTime? endTime = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|languageType|The language type|
|_[Optional]_ noticeType|Filter by notice type|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderBookAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-depth](https://bitgetlimited.github.io/apidoc/en/spot/#get-depth)  
<p>

*Get order book*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? mergeLevel = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|_[Optional]_ mergeLevel|Merge level for entries|
|_[Optional]_ limit|Results to return, max 1000|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRecentTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-recent-trades](https://bitgetlimited.github.io/apidoc/en/spot/#get-recent-trades)  
<p>

*Get recent trades*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetRecentTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetTrade>>> GetRecentTradesAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|_[Optional]_ limit|Results to return, max 500|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time](https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time)  
<p>

*Get the server time*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetServerTimeAsync();  
```  

```csharp  
Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetSymbolsAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-symbols](https://bitgetlimited.github.io/apidoc/en/spot/#get-symbols)  
<p>

*Get a list of supported symbols on the platform*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetSymbolsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetSymbol>>> GetSymbolsAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickerAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-single-ticker](https://bitgetlimited.github.io/apidoc/en/spot/#get-single-ticker)  
<p>

*Get a single symbol ticker*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetTickerAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickersAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-all-tickers](https://bitgetlimited.github.io/apidoc/en/spot/#get-all-tickers)  
<p>

*Get all symbol tickers*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetTickersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetTicker>>> GetTickersAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-market-trades](https://bitgetlimited.github.io/apidoc/en/spot/#get-market-trades)  
<p>

*Get trade history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.ExchangeData.GetTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetTrade>>> GetTradesAsync(string symbol, string? tradeId = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The id of the symbol|
|_[Optional]_ tradeId|Filter by trade id|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Results to return, max 500|
|_[Optional]_ ct|Cancellation token|

</p>

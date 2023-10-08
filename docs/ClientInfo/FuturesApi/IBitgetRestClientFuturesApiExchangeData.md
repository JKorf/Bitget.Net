---
title: IBitgetRestClientFuturesApiExchangeData
has_children: false
parent: IBitgetRestClientFuturesApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > FuturesApi > ExchangeData`  
*Bitget exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.*
  

***

## GetFeeRatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#vip-fee-rate](https://bitgetlimited.github.io/apidoc/en/mix/#vip-fee-rate)  
<p>

*Get fee information*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetFeeRatesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFeeLevel>>> GetFeeRatesAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetFundingRateAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate](https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate)  
<p>

*Get current funding rate*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetFundingRateAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFundingRate>> GetFundingRateAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetFundingRateHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-funding-rate](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-funding-rate)  
<p>

*Get funding rate history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetFundingRateHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFundingRateHistory>>> GetFundingRateHistoryAsync(string symbol, int? page = default, int? pageSize = default, bool? nextPage = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ page|Page number|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ nextPage|Whether to query the next page default false|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoricalIndexKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-index-candle-data](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-index-candle-data)  
<p>

*Get index klines/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetHistoricalIndexKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalIndexKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|interval|Kline interval|
|startTime|Start time|
|endTime|Filter by end time|
|_[Optional]_ priceType|Price type|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoricalKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-candle-data](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-candle-data)  
<p>

*Get klines/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetHistoricalKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|interval|Kline interval|
|startTime|Start time|
|endTime|Filter by end time|
|_[Optional]_ priceType|Price type|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoricalMarkKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-mark-candle-data](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-mark-candle-data)  
<p>

*Get mark klines/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetHistoricalMarkKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetHistoricalMarkKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|interval|Kline interval|
|startTime|Start time|
|endTime|Filter by end time|
|_[Optional]_ priceType|Price type|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetIndexPriceAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-index-price](https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-index-price)  
<p>

*Get the index price for a symbol*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetIndexPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetIndexPrice>> GetIndexPriceAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetKlinesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-candle-data](https://bitgetlimited.github.io/apidoc/en/mix/#get-candle-data)  
<p>

*Get klines/candlestick data*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetKlinesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesKline>>> GetKlinesAsync(string symbol, BitgetFuturesKlineInterval interval, DateTime startTime, DateTime endTime, BitgetKlineType? priceType = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|interval|Kline interval|
|startTime|Start time|
|endTime|Filter by end time|
|_[Optional]_ priceType|Price type|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetLeverageInfoAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-leverage](https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-leverage)  
<p>

*Get leverage info*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetLeverageInfoAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetLeverageInfo>> GetLeverageInfoAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMarkPriceAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-mark-price](https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-mark-price)  
<p>

*Get mark price*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetMarkPriceAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetMarkPrice>> GetMarkPriceAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMergedOrderBookAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-merged-depth-data](https://bitgetlimited.github.io/apidoc/en/mix/#get-merged-depth-data)  
<p>

*Get merged order book*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetMergedOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFuturesOrderBook>> GetMergedOrderBookAsync(string symbol, int? mergeLevel = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ mergeLevel|Merge level for entries|
|_[Optional]_ limit|Results to return, 1/5/15/50, defaults to 100|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetNextFundingTimeAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-next-funding-time](https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-next-funding-time)  
<p>

*Get next funding time*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetNextFundingTimeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFundingTime>> GetNextFundingTimeAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenInterestAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate](https://bitgetlimited.github.io/apidoc/en/mix/#get-current-funding-rate)  
<p>

*Get open interest rate*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetOpenInterestAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOpenInterest>> GetOpenInterestAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderBookAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-depth](https://bitgetlimited.github.io/apidoc/en/mix/#get-depth)  
<p>

*Get order book*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetOrderBookAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderBook>> GetOrderBookAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|Results to return, 1/5/15/50/100|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionRiskLimitAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-risk-position-limit](https://bitgetlimited.github.io/apidoc/en/mix/#get-risk-position-limit)  
<p>

*Get position risk limit*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetPositionRiskLimitAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetPositionRisk>>> GetPositionRiskLimitAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct||

</p>

***

## GetPositionsTiersAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-position-tier](https://bitgetlimited.github.io/apidoc/en/mix/#get-position-tier)  
<p>

*Get position tiers*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetPositionsTiersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetPositionTier>>> GetPositionsTiersAsync(BitgetProductType type, string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|symbol|Symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetRecentTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-recent-fills](https://bitgetlimited.github.io/apidoc/en/mix/#get-recent-fills)  
<p>

*Get recent trades for a symbol*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetRecentTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetRecentTradesAsync(string symbol, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetServerTimeAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time](https://bitgetlimited.github.io/apidoc/en/spot/#get-server-time)  
<p>

*Get the server time*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetServerTimeAsync();  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbols](https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbols)  
<p>

*Get symbols*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetSymbolsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesSymbol>>> GetSymbolsAsync(BitgetProductType type, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickerAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-single-symbol-ticker](https://bitgetlimited.github.io/apidoc/en/mix/#get-single-symbol-ticker)  
<p>

*Get ticker*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetTickerAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFuturesTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTickersAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbol-ticker](https://bitgetlimited.github.io/apidoc/en/mix/#get-all-symbol-ticker)  
<p>

*Get tickers*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetTickersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesTicker>>> GetTickersAsync(BitgetProductType type, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Type of symbols|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTradeHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-fills](https://bitgetlimited.github.io/apidoc/en/mix/#get-fills)  
<p>

*Get trade history for a symbol*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.ExchangeData.GetTradeHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesTrade>>> GetTradeHistoryAsync(string symbol, string? maxTradeId = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|_[Optional]_ maxTradeId|Return trades before this id|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

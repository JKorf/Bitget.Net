---
title: IBitgetRestClientFuturesApiAccount
has_children: false
parent: IBitgetRestClientFuturesApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > FuturesApi > Account`  
*Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetAccountAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-single-account](https://bitgetlimited.github.io/apidoc/en/mix/#get-single-account)  
<p>

*Get account info*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetAccountAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFuturesAccountInfo>> GetAccountAsync(string symbol, string marginAsset, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|marginAsset|Margin asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetAccountsAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-account-list](https://bitgetlimited.github.io/apidoc/en/mix/#get-account-list)  
<p>

*Get account list*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetAccountsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesAccountInfo>>> GetAccountsAsync(BitgetProductType type, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|The type of product|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBillsAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-account-bill](https://bitgetlimited.github.io/apidoc/en/mix/#get-account-bill)  
<p>

*Get account bill*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetBillsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetFuturesBill>>> GetBillsAsync(string marginAsset, DateTime startTime, DateTime endTime, BitgetProductType? type = default, string? symbol = default, int? pageSize = default, string? business = default, string? endId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|marginAsset|Margin asset|
|startTime|Start time|
|endTime|End time|
|_[Optional]_ type|Product type|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ business|Business|
|_[Optional]_ endId|Last end id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBusinessBillsAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-business-account-bill](https://bitgetlimited.github.io/apidoc/en/mix/#get-business-account-bill)  
<p>

*Get business account bills*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetBusinessBillsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetFuturesBill>>> GetBusinessBillsAsync(BitgetProductType type, DateTime startTime, DateTime endTime, int? pageSize = default, string? business = default, string? endId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|startTime|Start time|
|endTime|End time|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ business|Business type|
|_[Optional]_ endId|Last end id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetHistoryPositionAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-position](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-position)  
<p>

*Get history position (max 3 months ago)*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetHistoryPositionAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetPositionHistory>>> GetHistoryPositionAsync(DateTime startTime, DateTime endTime, BitgetProductType? type = default, string? symbol = default, int? pageSize = default, string? endId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|startTime|Start time|
|endTime|End time|
|_[Optional]_ type|Product type|
|_[Optional]_ symbol|Symbol|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ endId|Last end id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetMaxOpenPositionsAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-open-count](https://bitgetlimited.github.io/apidoc/en/mix/#get-open-count)  
<p>

*Get max open positions*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetMaxOpenPositionsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetMaxPositions>> GetMaxOpenPositionsAsync(string symbol, string marginAsset, decimal openPrice, decimal openQuantity, decimal? leverage = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|The margin asset|
|openPrice|Open price|
|openQuantity|Open quantity|
|_[Optional]_ leverage|Leverage|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-position-v2](https://bitgetlimited.github.io/apidoc/en/mix/#get-symbol-position-v2)  
<p>

*Get symbol position*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetPositionAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionAsync(string symbol, string marginAsset, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPositionsAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-all-position-v2](https://bitgetlimited.github.io/apidoc/en/mix/#get-all-position-v2)  
<p>

*Get all postions*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.GetPositionsAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionsAsync(BitgetProductType type, string? marginAsset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|_[Optional]_ marginAsset|Margin asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetAutoMarginAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#set-auto-margin](https://bitgetlimited.github.io/apidoc/en/mix/#set-auto-margin)  
<p>

*Set auto margin*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.SetAutoMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetResult>> SetAutoMarginAsync(string symbol, string marginAsset, BitgetPositionSide side, bool autoMargin, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|side|Position side|
|autoMargin|Auto margin on or off|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetHoldModeAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#change-hold-mode](https://bitgetlimited.github.io/apidoc/en/mix/#change-hold-mode)  
<p>

*Set position hold mode*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.SetHoldModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPositionMode>> SetHoldModeAsync(BitgetProductType type, BitgetHoldMode mode, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|mode|New hold mode|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetLeverageAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#change-leverage](https://bitgetlimited.github.io/apidoc/en/mix/#change-leverage)  
<p>

*Set the leverage*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.SetLeverageAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetUserLeverage>> SetLeverageAsync(string symbol, string marginAsset, decimal leverage, BitgetPositionSide? positionSide = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|leverage|Leverage|
|_[Optional]_ positionSide|Position direction (ignore this field if marginMode is crossed）|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetMarginAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#change-margin](https://bitgetlimited.github.io/apidoc/en/mix/#change-margin)  
<p>

*Set the margin*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.SetMarginAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetResult>> SetMarginAsync(string symbol, string marginAsset, decimal margin, BitgetPositionSide? positionSide = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|margin|Margin amount|
|_[Optional]_ positionSide|Position direction (ignore this field if marginMode is crossed）|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SetMarginModeAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#change-margin-mode](https://bitgetlimited.github.io/apidoc/en/mix/#change-margin-mode)  
<p>

*Change the margin mode*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Account.SetMarginModeAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetUserLeverage>> SetMarginModeAsync(string symbol, string marginAsset, BitgetMarginMode mode, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|mode|Margin mode|
|_[Optional]_ ct|Cancellation token|

</p>

---
title: IBitgetRestClientSpotApiTrading
has_children: false
parent: IBitgetRestClientSpotApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > SpotApi > Trading`  
*Bitget trading endpoints, placing and mananging orders.*
  

***

## CancelOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-v2](https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-v2)  
<p>

*Cancel an order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Order id. Either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id. Either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelOrdersAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-by-symbol](https://bitgetlimited.github.io/apidoc/en/spot/#cancel-order-by-symbol)  
<p>

*Cancel all orders for a symbol*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.CancelOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> CancelOrdersAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelPlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#cancel-plan-order](https://bitgetlimited.github.io/apidoc/en/spot/#cancel-plan-order)  
<p>

*Cancel a plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.CancelPlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> CancelPlanOrderAsync(string? orderId, string? clientOrderId, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|orderId|Order id of order to cancel, either this or clientOrderId should be provided|
|clientOrderId|Client order id of order to cancel, either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditPlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#modify-plan-order](https://bitgetlimited.github.io/apidoc/en/spot/#modify-plan-order)  
<p>

*Modify an existing plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.EditPlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(string? orderId, string? clientOrderId, BitgetOrderType type, decimal quantity, decimal triggerPrice, decimal? executePrice = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|orderId|Order id of order to edit, either this or clientOrderId should be provided|
|clientOrderId|Client order id of order to edit, either this or orderId should be provided|
|type|Order type|
|quantity|Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market|
|triggerPrice|Trigger price|
|_[Optional]_ executePrice|Execution price (if limit order)|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-order-details](https://bitgetlimited.github.io/apidoc/en/spot/#get-order-details)  
<p>

*Get order info by id*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrder>> GetOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Order id. Either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id. Either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-order-history](https://bitgetlimited.github.io/apidoc/en/spot/#get-order-history)  
<p>

*Get order history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderHistoryAsync(string symbol, string? startId = default, string? endId = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ startId|Return results with id after this|
|_[Optional]_ endId|Return results with id before this|
|_[Optional]_ limit|Max results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrdersAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-order-list](https://bitgetlimited.github.io/apidoc/en/spot/#get-order-list)  
<p>

*Get orders*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetOrdersAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrdersAsync(string? symbol = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ symbol|Symbol id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPlanOrderHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-history-plan-orders](https://bitgetlimited.github.io/apidoc/en/spot/#get-history-plan-orders)  
<p>

*Get historic plan orders*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetPlanOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrderHistoryAsync(string symbol, int pageSize, DateTime startTime, DateTime endTime, string? fromId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|pageSize|Page size|
|startTime|Filter by start time|
|endTime|Filter by end time|
|_[Optional]_ fromId|Return results after this order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPlanOrdersAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-current-plan-orders](https://bitgetlimited.github.io/apidoc/en/spot/#get-current-plan-orders)  
<p>

*Get current plan orders*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetPlanOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrdersAsync(string symbol, int pageSize, string? fromId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|pageSize|Page size|
|_[Optional]_ fromId|Return results after this order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-transaction-details](https://bitgetlimited.github.io/apidoc/en/spot/#get-transaction-details)  
<p>

*Get trade history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = default, string? startId = default, string? endId = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ startId|Filter by start id|
|_[Optional]_ endId|Filter by end id|
|_[Optional]_ limit|Max results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#trade](https://bitgetlimited.github.io/apidoc/en/spot/#trade)  
<p>

*Place a new order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, BitgetTimeInForce timeInForce, decimal? price, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|side|Order side|
|type|Order type|
|quantity|Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market|
|timeInForce|Time in force|
|price|Limit order price|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlacePlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#place-plan-order](https://bitgetlimited.github.io/apidoc/en/spot/#place-plan-order)  
<p>

*Place a new planned order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Trading.PlacePlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, decimal triggerPrice, BitgetTriggerType triggerType, decimal? executePrice = default, BitgetTimeInForce? timeInForce = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|side|Order side|
|type|Order type|
|quantity|Order quantity, base coin when orderType is limit; quote asset when orderType is buy-market, base asset when orderType is sell-market|
|triggerPrice|Trigger price|
|triggerType|Trigger type|
|_[Optional]_ executePrice|Execution price (if limit order)|
|_[Optional]_ timeInForce|Time in force|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

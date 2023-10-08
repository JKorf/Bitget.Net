---
title: IBitgetRestClientSpotApiAccount
has_children: false
parent: IBitgetRestClientSpotApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > SpotApi > Account`  
*Bitget account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings*
  

***

## GetApiKeyInfoAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-apikey-info](https://bitgetlimited.github.io/apidoc/en/spot/#get-apikey-info)  
<p>

*Get API key info*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetApiKeyInfoAsync();  
```  

```csharp  
Task<WebCallResult<BitgetApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBalancesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets](https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets)  
<p>

*Get account asset balances*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetBalancesAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesAsync(string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBalancesLiteAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets-lite](https://bitgetlimited.github.io/apidoc/en/spot/#get-account-assets-lite)  
<p>

*Get account assets, only returns assets with balance > 0*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetBalancesLiteAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetBalance>>> GetBalancesLiteAsync(string? asset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Filter by asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetBillsAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-bills](https://bitgetlimited.github.io/apidoc/en/spot/#get-bills)  
<p>

*Get bills history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetBillsAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetBill>>> GetBillsAsync(string? assetId = default, BitgetGroupType? groupType = default, BizType? bizType = default, DateTime? startTime = default, DateTime? endTime = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ assetId|Asset id|
|_[Optional]_ groupType|Transaction group type|
|_[Optional]_ bizType|	Business type|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositAddressAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-address](https://bitgetlimited.github.io/apidoc/en/spot/#get-coin-address)  
<p>

*Deposit address*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetDepositAddressAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetDepositAddress>> GetDepositAddressAsync(string asset, string network, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|network|Network|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetDepositHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-deposit-list](https://bitgetlimited.github.io/apidoc/en/spot/#get-deposit-list)  
<p>

*Get deposit history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetDepositHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetDeposit>>> GetDepositHistoryAsync(string? asset = default, DateTime? startTime = default, DateTime? endTime = default, int? page = default, int? pageSize = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Asset|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ page|Page|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetTransferHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-transfer-list](https://bitgetlimited.github.io/apidoc/en/spot/#get-transfer-list)  
<p>

*Get transfer history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetTransferHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetTransfer>>> GetTransferHistoryAsync(string assetId, BitgetAccountType fromType, DateTime startTime, DateTime endTime, string? clientOrderId = default, int? limit = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|assetId|Asset id|
|fromType|Filter by account source|
|startTime|Filter by start time|
|endTime|Filter by end time|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ limit|Max amount of results|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserFeeRatioAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-user-fee-ratio](https://bitgetlimited.github.io/apidoc/en/spot/#get-user-fee-ratio)  
<p>

*Get user maker / taker fees*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetUserFeeRatioAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetUserFee>> GetUserFeeRatioAsync(string symbol, BitgetBusinessType businessType, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|The symbol|
|businessType||
|_[Optional]_ ct||

</p>

***

## GetWithdrawalHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#get-withdraw-list](https://bitgetlimited.github.io/apidoc/en/spot/#get-withdraw-list)  
<p>

*Get withdrawal history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.GetWithdrawalHistoryAsync();  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = default, string? clientOrderId = default, DateTime? startTime = default, DateTime? endTime = default, int? page = default, int? pageSize = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|_[Optional]_ asset|Asset|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ page|Page|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ ct|Cancellation token|

</p>

***

## InnerWithdrawAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#inner-withdraw-v2](https://bitgetlimited.github.io/apidoc/en/spot/#inner-withdraw-v2)  
<p>

*Withdraw funds internally*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.InnerWithdrawAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetWithdrawResult>> InnerWithdrawAsync(string asset, string toUserId, decimal quantity, string? toType = default, string? areaCode = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|toUserId|Target user id|
|quantity|Quantity|
|_[Optional]_ toType|'email/mobile/uid', default 'uid'|
|_[Optional]_ areaCode|	Tel area code, This field is mandatory when the toType equals to 'mobile'|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## SubTransferAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#sub-transfer](https://bitgetlimited.github.io/apidoc/en/spot/#sub-transfer)  
<p>

*Transfer between subaccounts or sub and main account*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.SubTransferAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult> SubTransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string clientOrderId, string fromUserId, string toUserId, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|quantity|Transfer quantity|
|fromType|From account type|
|toType|To account type|
|clientOrderId|Client order id|
|fromUserId|From user id|
|toUserId|To user id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## TransferAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#transfer-v2](https://bitgetlimited.github.io/apidoc/en/spot/#transfer-v2)  
<p>

*Transfer between account types*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.TransferAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetTransferResult>> TransferAsync(string asset, decimal quantity, BitgetTransferAccountType fromType, BitgetTransferAccountType toType, string? symbol = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset name|
|quantity|Transfer quantity|
|fromType|From account type|
|toType|To account type|
|_[Optional]_ symbol|Must provide when fromType or toType = IsolatedMargin|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## WithdrawAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#withdraw-v2](https://bitgetlimited.github.io/apidoc/en/spot/#withdraw-v2)  
<p>

*Withdraw funds*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.SpotApi.Account.WithdrawAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetWithdrawResult>> WithdrawAsync(string asset, string address, string network, decimal quantity, string? tag = default, string? remark = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|asset|Asset|
|address|Target address|
|network|Network|
|quantity|Quantity|
|_[Optional]_ tag|Tag|
|_[Optional]_ remark|Remard|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

---
name: bitget-net
description: Build C#/.NET integrations using Bitget.Net for Bitget spot and futures V2, Unified/UTA, margin, copy trading, REST, WebSockets, authentication, account operations, trading, and Shared APIs. Use when writing or updating code that consumes the library.
---

# Bitget.Net

Use `BitgetRestClient` and `BitgetSocketClient` for Bitget exchange access. They provide signing, passphrase handling, rate limiting, result handling, and subscription management.

## Setup

```sh
dotnet add package JK.Bitget.Net
```

Use the API provided by the installed package. Select `SpotApiV2`, `FuturesApiV2`, or `UnifiedApi` for the target account/API. Spot margin is under `SpotApiV2.Margin`; copy trading uses `CopyTradingFuturesV2`. See [API surfaces](references/api-surfaces.md) for broker access and exact routing.

## Consumer conventions

- Public market data needs no credentials. Private calls use `BitgetCredentials` with an API key, secret, and passphrase; see [authentication](references/usage.md#authentication).
- Use compact native symbols such as `BTCUSDT`. Futures V2 methods require the applicable `BitgetProductTypeV2` and often a margin asset.
- Product types are in `Bitget.Net.Enums`; V2 order/account enums are in `Bitget.Net.Enums.V2`; Unified categories and settings are in `Bitget.Net.Enums.Uta`. Do not substitute V2 product types for UTA categories.
- REST calls return `HttpResult<T>` or `HttpResult`. Subscriptions return `WebSocketResult<UpdateSubscription>`; Unified socket order commands return `QueryResult<T>`. Shared non-I/O helpers can return `ExchangeCallResult<T>`. Check `Success` before accessing `Data`.
- Spot V2 ticker requests return an array even when filtering one symbol. Socket ticker callbacks also deliver collections; inspect the selected callback type.
- Reuse clients, await asynchronous methods, and pass cancellation tokens through the workflow. Keep socket callbacks short and unsubscribe through the concrete socket client on shutdown.
- Use symbol metadata to choose valid quantities and prices. Let the library generate client order IDs unless external correlation is needed.
- For portable multi-exchange code, use a surface's `SharedApi` and narrow capability interfaces. Read [Shared API selection](references/api-surfaces.md#shared-api-v2) before choosing classic versus Unified capabilities.

## Task references

Read only the references needed for the task:

- [API surfaces](references/api-surfaces.md): V2 and UTA roots, enum namespaces, routing, Shared API selection, catalogs, and stateful helpers.
- [Usage](references/usage.md): Authentication, results, balances, V2 and UTA orders, subscriptions, and dependency injection examples.
- [Operational considerations](references/safety.md): Passphrases, account/product selection, position modes, ambiguous outcomes, and retry decisions.

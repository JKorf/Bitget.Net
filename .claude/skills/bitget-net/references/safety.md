# Operational considerations

## Credentials

Use placeholders in examples and retrieve real API keys, secrets/private keys, and passphrases from environment variables or secret storage. The passphrase is part of Bitget authentication, not an optional label. Match key permissions and account/environment support to the selected API. Avoid logging signed requests or credentials.

## Account and position modes

Classic V2 and Unified/UTA operate on different account/API models. UTA changes can affect account-wide collateral and holdings; do not translate V2 settings by renaming a method. Futures V2 requests need the correct product type, margin asset, and margin mode. Hedge-mode `TradeSide.Open`/`Close` semantics differ from one-way reduce-only closing; inspect the current account mode before choosing order parameters.

Check symbol constraints before submitting illustrative prices and quantities. Limit orders can fill immediately; cancellation does not guarantee no execution. Inspect nested batch results instead of treating outer success as proof every order succeeded. Margin borrowing/repayment and copy-trading changes have account effects beyond ordinary spot orders.

## Retry decisions

Use `Error.IsTransient` to identify retry candidates, with bounded backoff and cancellation. An order timeout can leave the outcome unknown. Reconcile its open/history state before resubmitting; a transient error alone does not make an account-changing request safe to repeat.

See [API surfaces](api-surfaces.md) for lookup methods and [usage](usage.md) for result handling.

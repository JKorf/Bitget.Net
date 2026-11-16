# Bitget.Net examples

Each C# file is a complete console program. The [documentation compilation test](../../Bitget.Net.UnitTests/Documentation/AiExampleCompileTests.cs) builds them without executing exchange operations.

| Example | Purpose |
| --- | --- |
| [Spot quickstart](01-spot-quickstart.cs) | Public ticker, authenticated balances, and spot orders |
| [Futures V2](02-futures-v2.cs) | Product type, margin asset, account data, orders, and cancellation |
| [WebSockets](03-websocket.cs) | Public subscriptions and cleanup |
| [Multi-exchange](04-multi-exchange.cs) | Shared API V2 capabilities and subscriptions |
| [Error handling](05-error-handling.cs) | Results, read retries, and error diagnostics |

For imports, authentication, and Unified examples, read the [consumer skill](../../.claude/skills/bitget-net/SKILL.md). Use the [API surfaces reference](../../.claude/skills/bitget-net/references/api-surfaces.md) for endpoint routing and enum namespaces.

To try an example, create a console project, add `JK.Bitget.Net`, and copy one example into `Program.cs`. Private operations need your API key, secret, and passphrase. Review the operations before executing a program; compilation does not run its account or trading calls.

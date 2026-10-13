using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBitgetSocketClientUnifiedSharedApi :
        ISubscribeTickerSocket,
        ISubscribeBalancesSocket
    { }
}

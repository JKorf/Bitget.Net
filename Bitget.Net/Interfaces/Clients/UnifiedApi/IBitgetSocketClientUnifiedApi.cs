using Bitget.Net.Enums;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Bitget spot streams
    /// </summary>
    public interface IBitgetSocketClientUnifiedApi : ISocketApiClient<BitgetCredentials>, IDisposable
    {
    }
}

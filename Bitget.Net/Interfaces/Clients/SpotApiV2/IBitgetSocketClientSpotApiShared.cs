using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Shared interface for Spot socket API usage
    /// </summary>
    public interface IBitgetSocketClientSpotApiShared :
        ITickerSocketClient,
        ITradeSocketClient,
        IBookTickerSocketClient,
        IBalanceSocketClient,
        ISpotOrderSocketClient,
        IUserTradeSocketClient,
        IKlineSocketClient,
        IOrderBookSocketClient
    {
    }
}

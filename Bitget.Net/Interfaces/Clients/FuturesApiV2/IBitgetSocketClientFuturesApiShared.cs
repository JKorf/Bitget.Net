using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Shared interface for Futures socket API usage
    /// </summary>
    public interface IBitgetSocketClientFuturesApiShared :
        ITickerSocketClient,
        ITradeSocketClient,
        IBookTickerSocketClient,
        IBalanceSocketClient,
        IKlineSocketClient,
        IOrderBookSocketClient,
        IPositionSocketClient,
        IFuturesOrderSocketClient,
        IUserTradeSocketClient
    {
    }
}

using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Spot;
using System;
using System.Collections.Generic;
using System.Text;

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

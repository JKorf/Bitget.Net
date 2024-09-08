using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    public interface IBitgetSocketClientFuturesApiShared :
        ITickerSocketClient,
        ITradeSocketClient,
        IBookTickerSocketClient,
        IBalanceSocketClient,
        IKlineSocketClient,
        IOrderBookSocketClient,
        IFuturesOrderSocketClient,
        IUserTradeSocketClient
    {
    }
}

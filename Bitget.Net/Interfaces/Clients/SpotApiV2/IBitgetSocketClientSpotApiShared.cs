using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    public interface IBitgetSocketClientSpotApiShared :
        ITickerSocketClient,
        ITradeSocketClient,
        IBookTickerSocketClient,
        IBalanceSocketClient,
        ISpotOrderSocketClient
    {
    }
}

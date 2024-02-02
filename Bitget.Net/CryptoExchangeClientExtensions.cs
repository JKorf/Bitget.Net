using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Clients
{
    public static class CryptoExchangeClientExtensions
    {
        public static IBitgetRestClient Bitget(this ICryptoExchangeClient baseClient) => baseClient.TryGet<IBitgetRestClient>() ?? new BitgetRestClient();
    }
}

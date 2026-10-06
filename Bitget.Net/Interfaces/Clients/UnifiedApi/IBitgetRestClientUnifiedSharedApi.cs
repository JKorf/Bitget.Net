using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{

    /// <summary>
    /// Shared API interface. Shared APIs provide a common,
    /// exchange-independent contract for accessing functionality across different
    /// exchange client libraries.
    /// </summary>
    public interface IBitgetRestClientUnifiedSharedApi
        : IGetTickerRest,
        IGetAllTickersRest,
        IGetBalancesRest,
        IGetDepositAddressesRest,
        IGetDepositHistoryRest,
        IGetFeesRest
    {        
    }
}

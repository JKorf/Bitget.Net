using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces;

namespace CryptoExchange.Net.Interfaces
{

    /// <summary>
    /// Extensions for the ICryptoRestClient and ICryptoSocketClient interfaces
    /// </summary>
    public static class CryptoClientExtensions
    {
        /// <summary>
        /// Get the Bitget REST Api client
        /// </summary>
        /// <param name="baseClient"></param>
        /// <returns></returns>
        public static IBitgetRestClient Bitget(this ICryptoRestClient baseClient) => baseClient.TryGet<IBitgetRestClient>(() => new BitgetRestClient());

        /// <summary>
        /// Get the Bitget Websocket Api client
        /// </summary>
        /// <param name="baseClient"></param>
        /// <returns></returns>
        public static IBitgetSocketClient Bitget(this ICryptoSocketClient baseClient) => baseClient.TryGet<IBitgetSocketClient>(() => new BitgetSocketClient());
    }
}

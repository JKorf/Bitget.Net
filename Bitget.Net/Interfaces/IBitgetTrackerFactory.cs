using Bitget.Net.Enums;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using CryptoExchange.Net.Trackers.UserData;
using CryptoExchange.Net.Trackers.UserData.Interfaces;
using CryptoExchange.Net.Trackers.UserData.Objects;

namespace Bitget.Net.Interfaces
{
    /// <summary>
    /// Tracker factory
    /// </summary>
    public interface IBitgetTrackerFactory : ITrackerFactory
    {
        /// <summary>
        /// Create a new kline tracker
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="limit">The max amount of klines to retain</param>
        /// <param name="period">The max period the data should be retained</param>
        /// <param name="productType">Product type</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="exchangeParameters">Exchange parameters</param>
        /// <returns></returns>
        IKlineTracker CreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval, BitgetProductTypeV2 productType, string marginAsset, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null);

        /// <summary>
        /// Create a new trade tracker for a symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="limit">The max amount of trades to retain</param>
        /// <param name="period">The max period the data should be retained</param>
        /// <param name="productType">Product type</param>
        /// <param name="marginAsset">Margin asset</param>
        /// <param name="exchangeParameters">Exchange parameters</param>
        /// <returns></returns>
        ITradeTracker CreateTradeTracker(SharedSymbol symbol, BitgetProductTypeV2 productType, string marginAsset, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null);

        /// <summary>
        /// Create a new Spot user data tracker
        /// </summary>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        IUserSpotDataTracker CreateUserSpotDataTracker(string userIdentifier, BitgetCredentials credentials, SpotUserDataTrackerConfig? config = null, BitgetEnvironment? environment = null);
        /// <summary>
        /// Create a new spot user data tracker
        /// </summary>
        /// <param name="config">Configuration</param>
        IUserSpotDataTracker CreateUserSpotDataTracker(SpotUserDataTrackerConfig? config = null);

        /// <summary>
        /// Create a new futures user data tracker
        /// </summary>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        /// <param name="productType">Product type</param>
        /// <param name="marginAsset">Margin asset to track, for example USDT</param>
        IUserFuturesDataTracker CreateUserFuturesDataTracker(string userIdentifier, BitgetCredentials credentials, BitgetProductTypeV2 productType, string marginAsset, FuturesUserDataTrackerConfig? config = null, BitgetEnvironment? environment = null);
        /// <summary>
        /// Create a new futures user data tracker
        /// </summary>
        /// <param name="config">Configuration</param>
        /// <param name="productType">Product type</param>
        /// <param name="marginAsset">Margin asset to track, for example USDT</param>
        IUserFuturesDataTracker CreateUserFuturesDataTracker(BitgetProductTypeV2 productType, string marginAsset, FuturesUserDataTrackerConfig? config = null);
    }
}

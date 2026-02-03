using Bitget.Net.Enums;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
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
        /// Create a new Spot user data tracker
        /// </summary>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        IUserSpotDataTracker CreateUserSpotDataTracker(string userIdentifier, SpotUserDataTrackerConfig config, ApiCredentials credentials, BitgetEnvironment? environment = null);
        /// <summary>
        /// Create a new spot user data tracker
        /// </summary>
        /// <param name="config">Configuration</param>
        IUserSpotDataTracker CreateUserSpotDataTracker(SpotUserDataTrackerConfig config);

        /// <summary>
        /// Create a new futures user data tracker
        /// </summary>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        /// <param name="productType">Product type</param>
        IUserFuturesDataTracker CreateUserFuturesDataTracker(string userIdentifier, FuturesUserDataTrackerConfig config, ApiCredentials credentials, BitgetProductTypeV2 productType, BitgetEnvironment? environment = null);
        /// <summary>
        /// Create a new futures user data tracker
        /// </summary>
        /// <param name="config">Configuration</param>
        /// <param name="productType">Product type</param>
        IUserFuturesDataTracker CreateUserFuturesDataTracker(FuturesUserDataTrackerConfig config, BitgetProductTypeV2 productType);
    }
}

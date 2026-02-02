using Bitget.Net.Enums;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Trackers.UserData;

namespace Bitget.Net.Interfaces
{
    /// <summary>
    /// Tracker factory
    /// </summary>
    public interface IBitgetTrackerFactory : ITrackerFactory
    {
        IUserSpotDataTracker CreateUserSpotDataTracker(string userIdentifier, UserDataTrackerConfig config, ApiCredentials credentials, BitgetEnvironment? environment = null);
        IUserSpotDataTracker CreateUserSpotDataTracker(UserDataTrackerConfig config);
        IUserFuturesDataTracker CreateUserFuturesDataTracker(string userIdentifier, UserDataTrackerConfig config, ApiCredentials credentials, BitgetProductTypeV2 productType, BitgetEnvironment? environment = null);
        IUserFuturesDataTracker CreateUserFuturesDataTracker(UserDataTrackerConfig config, BitgetProductTypeV2 productType);
    }
}

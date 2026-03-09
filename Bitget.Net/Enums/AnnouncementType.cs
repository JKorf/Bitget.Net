using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Announcement type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AnnouncementType>))]
    public enum AnnouncementType
    {
        /// <summary>
        /// ["<c>latest_news</c>"] Latest news
        /// </summary>
        [Map("latest_news")]
        LatestNews,
        /// <summary>
        /// ["<c>coin_listings</c>"] Coin listing
        /// </summary>
        [Map("coin_listings")]
        CoinListing,
        /// <summary>
        /// ["<c>product_updates</c>"] Product updates
        /// </summary>
        [Map("product_updates")]
        ProductUpdates,
        /// <summary>
        /// ["<c>security</c>"] Security update
        /// </summary>
        [Map("security")]
        Security,
        /// <summary>
        /// ["<c>api_trading</c>"] Api trading update
        /// </summary>
        [Map("api_trading")]
        ApiTrading,
        /// <summary>
        /// ["<c>maintenance_system_updates</c>"] Maintenance update
        /// </summary>
        [Map("maintenance_system_updates")]
        MaintenanceSystemUpdates,
        /// <summary>
        /// ["<c>symbol_delisting</c>"] Delisting update
        /// </summary>
        [Map("symbol_delisting")]
        SymbolDelisting
    }
}

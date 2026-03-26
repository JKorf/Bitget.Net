using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Asset mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AssetMode>))]
    public enum AssetMode
    {
        /// <summary>
        /// Union
        /// </summary>
        [Map("union")]
        Union,
        /// <summary>
        /// Single
        /// </summary>
        [Map("single")]
        Single
    }
}

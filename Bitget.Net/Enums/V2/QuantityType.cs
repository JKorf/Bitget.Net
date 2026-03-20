using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<QuantityType>))]
    public enum QuantityType
    {
        /// <summary>
        /// ["<c>amount</c>"] Base asset quantity
        /// </summary>
        [Map("amount")]
        BaseAsset,
        /// <summary>
        /// ["<c>total</c>"] Quote asset quantity
        /// </summary>
        [Map("total")]
        QuoteAsset
    }
}

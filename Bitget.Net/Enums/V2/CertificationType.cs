using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Certification Type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<CertificationType>))]
    public enum CertificationType
    {
        /// <summary>
        /// Uncertified
        /// </summary>
        [Map("uncertified")]
        Uncertified,
        /// <summary>
        /// Certified
        /// </summary>
        [Map("certified")]
        Certified
    }
}

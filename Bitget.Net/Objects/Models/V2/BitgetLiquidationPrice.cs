using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Liquidation price info
    /// </summary>
    public record BitgetLiquidationPrice
    {
        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonPropertyName("liqPrice")]
        public decimal LiquidationPrice { get; set; }
    }
}

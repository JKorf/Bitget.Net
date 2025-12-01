using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

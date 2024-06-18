using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    internal record BitgetServerTime
    {
        [JsonPropertyName("serverTime")]
        public DateTime ServerTime { get; set; }
    }
}

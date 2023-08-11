using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models
{
    internal class BitgetResponse<T>
    {
        public string Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RequestTime { get; set; }
        public T? Data { get; set; }
    }
}

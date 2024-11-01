using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record BitgetMinMaxResult<T>
    {
        /// <summary>
        /// Min id in the results
        /// </summary>
        [JsonPropertyName("minId")]
        public string MinId { get; set; } = string.Empty;
        /// <summary>
        /// Max id in the results
        /// </summary>
        [JsonPropertyName("maxId")]
        public string MaxId { get; set; } = string.Empty;
        /// <summary>
        /// Results
        /// </summary>
        [JsonPropertyName("resultList")]
        public IEnumerable<T> Result { get; set; } = [];
    }
}

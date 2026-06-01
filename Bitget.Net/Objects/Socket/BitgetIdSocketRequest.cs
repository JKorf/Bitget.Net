using Bitget.Net.Enums.Uta;
using CryptoExchange.Net.Objects;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetIdSocketRequest
    {
        [JsonPropertyName("op")]
        public string Op { get; set; } = string.Empty;
        [JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("topic"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Topic { get; set; } = string.Empty;
        [JsonPropertyName("apiCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ApiCode { get; set; } = string.Empty;
        [JsonPropertyName("category"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ProductCategory? Category { get; set; }
        [JsonPropertyName("args")]
        public ParameterCollection[] Args { get; set; } = [];
    }
}

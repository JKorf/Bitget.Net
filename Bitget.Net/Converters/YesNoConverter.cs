using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitget.Net.Converters
{
    /// <inheritdoc />
    public class YesNoConverter : JsonConverter<bool>
    {
        /// <inheritdoc />
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            if (string.IsNullOrEmpty(value))
                return false;
            return value.Equals("Yes", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? "YES" : "NO");
        }
    }
}

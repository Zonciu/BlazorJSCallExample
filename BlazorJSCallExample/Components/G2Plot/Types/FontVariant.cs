using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FontVariant
    {
        [System.Text.Json.Serialization.JsonPropertyName("normal")]
        [Newtonsoft.Json.JsonProperty("normal")]
        normal,

        [JsonPropertyName("small-caps")]
        smallCaps
    }
}
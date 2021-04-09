using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FontStyle
    {
        [System.Text.Json.Serialization.JsonPropertyName("normal")]
        [Newtonsoft.Json.JsonProperty("normal")]
        normal,

        [System.Text.Json.Serialization.JsonPropertyName("italic")]
        [Newtonsoft.Json.JsonProperty("italic")]
        italic,

        [System.Text.Json.Serialization.JsonPropertyName("oblique")]
        [Newtonsoft.Json.JsonProperty("oblique")]
        oblique,
    }
}
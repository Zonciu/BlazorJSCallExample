using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FontWeight
    {
        [System.Text.Json.Serialization.JsonPropertyName("normal")]
        [Newtonsoft.Json.JsonProperty("normal")]
        normal,

        [System.Text.Json.Serialization.JsonPropertyName("bold")]
        [Newtonsoft.Json.JsonProperty("bold")]
        bold,

        [System.Text.Json.Serialization.JsonPropertyName("bolder")]
        [Newtonsoft.Json.JsonProperty("bolder")]
        bolder,

        [System.Text.Json.Serialization.JsonPropertyName("lighter")]
        [Newtonsoft.Json.JsonProperty("lighter")]
        lighter
    }
}
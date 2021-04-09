using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LineCap
    {
        [System.Text.Json.Serialization.JsonPropertyName("butt")]
        [Newtonsoft.Json.JsonProperty("butt")]
        butt,

        [System.Text.Json.Serialization.JsonPropertyName("round")]
        [Newtonsoft.Json.JsonProperty("round")]
        round,

        [System.Text.Json.Serialization.JsonPropertyName("square")]
        [Newtonsoft.Json.JsonProperty("square")]
        square,
    }
}
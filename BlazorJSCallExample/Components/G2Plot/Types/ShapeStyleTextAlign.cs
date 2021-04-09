using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShapeStyleTextAlign
    {
        [System.Text.Json.Serialization.JsonPropertyName("start")]
        [Newtonsoft.Json.JsonProperty("start")]
        start,

        [System.Text.Json.Serialization.JsonPropertyName("center")]
        [Newtonsoft.Json.JsonProperty("center")]
        center,

        [System.Text.Json.Serialization.JsonPropertyName("end")]
        [Newtonsoft.Json.JsonProperty("end")]
        end,

        [System.Text.Json.Serialization.JsonPropertyName("left")]
        [Newtonsoft.Json.JsonProperty("left")]
        left,

        [System.Text.Json.Serialization.JsonPropertyName("right")]
        [Newtonsoft.Json.JsonProperty("right")]
        right
    }
}
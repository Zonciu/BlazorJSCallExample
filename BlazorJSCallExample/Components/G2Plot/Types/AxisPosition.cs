using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AxisPosition
    {
        [System.Text.Json.Serialization.JsonPropertyName("top")]
        [Newtonsoft.Json.JsonProperty("top")]
        top,

        [System.Text.Json.Serialization.JsonPropertyName("bottom")]
        [Newtonsoft.Json.JsonProperty("bottom")]
        bottom,

        [System.Text.Json.Serialization.JsonPropertyName("right")]
        [Newtonsoft.Json.JsonProperty("right")]
        right,

        [System.Text.Json.Serialization.JsonPropertyName("left")]
        [Newtonsoft.Json.JsonProperty("left")]
        left
    }
}
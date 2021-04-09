using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShapeStyleTextBaseLine
    {
        [System.Text.Json.Serialization.JsonPropertyName("top")]
        [Newtonsoft.Json.JsonProperty("top")]
        top,

        [System.Text.Json.Serialization.JsonPropertyName("hanging")]
        [Newtonsoft.Json.JsonProperty("hanging")]
        hanging,

        [System.Text.Json.Serialization.JsonPropertyName("middle")]
        [Newtonsoft.Json.JsonProperty("middle")]
        middle,

        [System.Text.Json.Serialization.JsonPropertyName("alphabetic")]
        [Newtonsoft.Json.JsonProperty("alphabetic")]
        alphabetic,

        [System.Text.Json.Serialization.JsonPropertyName("ideographic")]
        [Newtonsoft.Json.JsonProperty("ideographic")]
        ideographic,

        [System.Text.Json.Serialization.JsonPropertyName("bottom")]
        [Newtonsoft.Json.JsonProperty("bottom")]
        bottom,
    }
}
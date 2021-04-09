using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LineJoin
    {
        [System.Text.Json.Serialization.JsonPropertyName("bevel")]
        [Newtonsoft.Json.JsonProperty("bevel")]
        bevel,

        [System.Text.Json.Serialization.JsonPropertyName("round")]
        [Newtonsoft.Json.JsonProperty("round")]
        round,

        [System.Text.Json.Serialization.JsonPropertyName("miter")]
        [Newtonsoft.Json.JsonProperty("miter")]
        miter
    }
}
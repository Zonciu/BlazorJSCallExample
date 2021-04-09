using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AutoPadding
    {
        [System.Text.Json.Serialization.JsonPropertyName("auto")]
        [Newtonsoft.Json.JsonProperty("auto")]
        auto
    }
}
using System.Text.Json.Serialization;
using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Marker
    {
        [System.Text.Json.Serialization.JsonPropertyName("circle")]
        [Newtonsoft.Json.JsonProperty("circle")]
        circle,

        [System.Text.Json.Serialization.JsonPropertyName("square")]
        [Newtonsoft.Json.JsonProperty("square")]
        square,

        [System.Text.Json.Serialization.JsonPropertyName("diamond")]
        [Newtonsoft.Json.JsonProperty("diamond")]
        diamond,

        [System.Text.Json.Serialization.JsonPropertyName("triangle")]
        [Newtonsoft.Json.JsonProperty("triangle")]
        triangle,

        [System.Text.Json.Serialization.JsonPropertyName("triangleDown")]
        [Newtonsoft.Json.JsonProperty("triangleDown")]
        triangleDown,

        [System.Text.Json.Serialization.JsonPropertyName("hexagon")]
        [Newtonsoft.Json.JsonProperty("hexagon")]
        hexagon,

        [System.Text.Json.Serialization.JsonPropertyName("bowtie")]
        [Newtonsoft.Json.JsonProperty("bowtie")]
        bowtie,

        [System.Text.Json.Serialization.JsonPropertyName("cross")]
        [Newtonsoft.Json.JsonProperty("cross")]
        cross,

        [System.Text.Json.Serialization.JsonPropertyName("tick")]
        [Newtonsoft.Json.JsonProperty("tick")]
        tick,

        [System.Text.Json.Serialization.JsonPropertyName("plus")]
        [Newtonsoft.Json.JsonProperty("plus")]
        plus,

        [System.Text.Json.Serialization.JsonPropertyName("hyphen")]
        [Newtonsoft.Json.JsonProperty("hyphen")]
        hyphen,

        [System.Text.Json.Serialization.JsonPropertyName("line")]
        [Newtonsoft.Json.JsonProperty("line")]
        line,
    }

    public class MarkerCfg : LegendMarkerCfg
    {
        /// <summary>
        /// /** 支持的 Marker 类型 */
        /// export declare type Marker = 'circle' | 'square' | 'diamond' | 'triangle' | 'triangle-down' | 'hexagon' | 'bowtie' | 'cross' | 'tick' | 'plus' | 'hyphen' | 'line';
        /// /** 自定义 Marker 的回调函数定义 */
        /// export declare type MarkerCallback = (x: number, y: number, r: number) => PathCommand;
        ///
        /// Marker | MarkerCallback
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<Marker, JSCall>? symbol { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("symbol")]
        [Newtonsoft.Json.JsonProperty("symbol")]
        public object? _symbol => symbol?.Value;
    }
}
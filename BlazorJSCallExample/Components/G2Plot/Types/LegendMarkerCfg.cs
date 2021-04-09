using BlazorJSCallExample.Core;
using ShapeAttrs = G2Plot.Types.ShapeStyle;
using OneOf;

namespace G2Plot.Types
{
    public class LegendMarkerCfg
    {
        /**
    * 图例项 marker 同后面 name 的间距
    * @type {number}
    */
        public double? spacing { get; set; }

        /**
    * 图例 marker 形状
         * string | ((x: number, y: number, r: number) => any)
    */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, JSCall>? symbol { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("symbol")]
        [Newtonsoft.Json.JsonProperty("symbol")]
        public object? _symbol => symbol?.Value;

        /**
    * 图例项 marker 的配置项
    * @type {ShapeAttrs}
    */
        public ShapeStyle? style { get; set; }
    }
}
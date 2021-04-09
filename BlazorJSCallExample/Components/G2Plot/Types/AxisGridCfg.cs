using OneOf;

namespace G2Plot.Types
{
    public class GridLineCfg
    {
        /**
     * 栅格线的类型
     * @type {string}
     */
        public string? type { get; set; }

        /**
     * 栅格线的配置项
     * @type {ShapeAttrs}
     * ShapeAttrs | ShapeAttrsCallback;
     */
        public ShapeStyle style { get; set; }
    }

    public class AxisGridCfg
    {
        /**
           * 线的样式。
           * 属性结构如下：
           *
           * ```ts
           * {
           *   type?: string; // 栅格线的类型，'line' 或者 'circle'
           *   style?: ShapeAttrs; // 栅格线的样式配置项
           * }
           * ```
           *
           * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L407|GridLineCfg}
           */
        public GridLineCfg? line { get; set; }

        /**
           * 两个栅格线间的填充色。
           */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, string[]>? alternateColor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("alternateColor")]
        [Newtonsoft.Json.JsonProperty("alternateColor")]
        public object _alternateColor => alternateColor?.Value;

        /**
           * 对于 circle 是否关闭 grid。
           */
        public bool? closed { get; set; }

        /**
     * 是否同刻度线对齐，如果值为 false，则会显示在两个刻度中间。
     * ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*YX6fS4GTTvMAAAAAAAAAAABkARQnAQ)
     */
        public bool? alignTick { get; set; }
    }
}
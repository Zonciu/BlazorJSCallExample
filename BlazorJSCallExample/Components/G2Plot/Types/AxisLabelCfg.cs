using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    public class AxisLabelCfg
    {
        /**
             * 坐标轴文本的样式
             * @type {ShapeAttrs}
             * Todo ShapeAttrs | ShapeAttrsCallback?
             */
        public ShapeStyle? style { get; set; }

        /**
             * label 的偏移量
             * @type {double}
             */
        public double? offset { get; set; }

        /**
             * 文本旋转角度
             * @type {double}
             */
        public double? rotate { get; set; }

        /// <summary>
        /// 格式化函数
        /// @type {formatterCallback} <br/>
        /// declare type formatterCallback = (text: string, item: ListItem, index: number) => any;
        /// </summary>
        public JSCall? formatter { get; set; }

        /**
             * 是否自动旋转，默认 true
             * @type {boolean|avoidCallback|string}
             */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, JSCall, string>? autoRotate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("autoRotate")]
        [Newtonsoft.Json.JsonProperty("autoRotate")]
        public object? _autoRotate => autoRotate?.Value;

        /**
             * 是否自动隐藏，默认 false
             * @type {boolean|avoidCallback|string|{type:string,cfg?:AxisLabelAutoHideCfg}}
             */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, JSCall, string, AutoHide>? autoHide { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("autoHide")]
        [Newtonsoft.Json.JsonProperty("autoHide")]
        public object? _autoHide => autoHide?.Value;

        /**
             * 是否自动省略，默认 false
             * @type {boolean|avoidCallback|string}
             */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, JSCall, string>? autoEllipsis { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("autoEllipsis")]
        [Newtonsoft.Json.JsonProperty("autoEllipsis")]
        public object? _autoEllipsis => autoEllipsis?.Value;
    }

    public class AutoHide
    {
        public string type { get; set; }

        public AxisLabelAutoHideCfg? cfg { get; set; }
    }

    public class AxisLabelAutoHideCfg
    {
        /** 最小间距配置 */
        public double? minGap { get; set; }
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BlazorJSCallExample.Core;
using Microsoft.AspNetCore.Components;
using ShapeAttrs = G2Plot.Types.ShapeStyle;
using OneOf;

namespace G2Plot.Types
{
    public class TooltipOption
    { }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TooltipPotision
    {
        [System.Text.Json.Serialization.JsonPropertyName("top")]
        [Newtonsoft.Json.JsonProperty("top")]
        top,

        [System.Text.Json.Serialization.JsonPropertyName("bottom")]
        [Newtonsoft.Json.JsonProperty("bottom")]
        bottom,

        [System.Text.Json.Serialization.JsonPropertyName("left")]
        [Newtonsoft.Json.JsonProperty("left")]
        left,

        [System.Text.Json.Serialization.JsonPropertyName("right")]
        [Newtonsoft.Json.JsonProperty("right")]
        right
    }

    /** chart.tooltip() 接口配置属性 */
    public interface TooltipCfg
    {
        /**
    * 设置 tooltip 内容框是否跟随鼠标移动。
    * 默认为 true，跟随鼠标移动，false 则固定位置不随鼠标移动。
    */
        public bool? follow { get; set; }

        /** tooltip 是否允许鼠标滑入，默认为 false，不允许 */
        public bool? enterable { get; set; }

        /** tooltip 显示延迟（ms），默认为 16ms，建议在 enterable = true 的时候才设置  */
        public double? showDelay { get; set; }

        /** 是否展示 tooltip 标题。 */
        public bool? showTitle { get; set; }

        /**
    * 设置 tooltip 的标题内容：如果值为数据字段名，则会展示数据中对应该字段的数值，如果数据中不存在该字段，则直接展示 title 值。
    */
        public string? title { get; set; }

        /** 设置 tooltip 的固定展示位置，相对于数据点。 */
        public TooltipPotision? position { get; set; }

        /** true 表示合并当前点对应的所有数据并展示，false 表示只展示离当前点最逼近的数据内容。 */
        public bool? shared { get; set; }

        /** 是否展示 crosshairs。 */
        public bool? showCrosshairs { get; set; }

        /** 配置 tooltip 的 crosshairs，当且仅当 `showCrosshairs` 为 true 时生效。 */
        public TooltipCrosshairs? crosshairs { get; set; }

        /** 是否渲染 tooltipMarkers。 */
        public bool? showMarkers { get; set; }

        /** tooltipMarker 的样式配置。 */
        public object? marker { get; set; }

        /** 是否展示 tooltip 内容框 */
        public bool? showContent { get; set; }

        /** 自定义 tooltip 的容器。 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, ElementReference>? container { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("container")]
        [Newtonsoft.Json.JsonProperty("container")]
        public object? _container => container?.Value;

        /** 用于指定图例容器的模板，自定义模板时必须包含各个 dom 节点的 class。 */
        public string? containerTpl { get; set; }

        /** 每项记录的默认模板，自定义模板时必须包含各个 dom 节点的 class。 */
        public string? itemTpl { get; set; }

        /** 传入各个 dom 的样式。 */
        public TooltipDomStyles? domStyles { get; set; }

        /** tooltip 偏移量。 */
        public double? offset { get; set; }

        /** 是否将 tooltip items 逆序 */
        public bool? reversed { get; set; }

        /** 支持自定义模板 */

        // (title: string, data: any[]) => string | HTMLElement
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<JSCall, ElementReference>? customContent { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("customContent")]
        [Newtonsoft.Json.JsonProperty("customContent")]
        public object? _customContent => customContent?.Value;
    }

    /// <summary>
    /// /** Tooltip 内容框的 css 样式定义 */
    /// </summary>
    public class TooltipDomStyles
    {
        [JsonPropertyName("g2-tooltip")]
        public Dictionary<string, object>? g2_tooltip { get; set; }

        [JsonPropertyName("g2-tooltip-title")]
        public Dictionary<string, object>? g2_tooltip_title { get; set; }

        [JsonPropertyName("g2-tooltip-list")]
        public Dictionary<string, object>? g2_tooltip_list { get; set; }

        [JsonPropertyName("g2-tooltip-list-item")]
        public Dictionary<string, object>? g2_tooltip_list_item { get; set; }

        [JsonPropertyName("g2-tooltip-marker")]
        public Dictionary<string, object>? g2_tooltip_marker { get; set; }

        [JsonPropertyName("g2-tooltip-value")]
        public Dictionary<string, object>? g2_tooltip_value { get; set; }

        [JsonPropertyName("g2-tooltip-name")]
        public Dictionary<string, object>? g2_tooltip_name { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CrosshairsType
    {
        [System.Text.Json.Serialization.JsonPropertyName("x")]
        [Newtonsoft.Json.JsonProperty("x")]
        x,

        [System.Text.Json.Serialization.JsonPropertyName("y")]
        [Newtonsoft.Json.JsonProperty("y")]
        y,

        [System.Text.Json.Serialization.JsonPropertyName("xy")]
        [Newtonsoft.Json.JsonProperty("xy")]
        xy
    }

    /** Tooltip crosshairs 配置结构 */
    public class TooltipCrosshairs
    {
        /**
     * crosshairs 的类型: `x` 表示 x 轴上的辅助线，`y` 表示 y 轴上的辅助项。
     * 以下是在不同坐标系下，crosshairs 各个类型的表现：
     *
     * | 坐标系 | type = 'x' | type = 'xy' | type = 'y' |
     * | ------------ | ------------- | ------------- |
     * | 直角坐标系  | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*jmUBQ4nbtXsAAAAAAAAAAABkARQnAQ) | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*RpWXT76ZSQgAAAAAAAAAAABkARQnAQ) | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*Xjl8TLIJLuUAAAAAAAAAAABkARQnAQ) |
     * | 极坐标 | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*zbMVSoKTyFsAAAAAAAAAAABkARQnAQ) | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*k5EYRJspET0AAAAAAAAAAABkARQnAQ) | ![image](https://gw.alipayobjects.com/mdn/rms_2274c3/afts/img/A*n_TKQpUaXWEAAAAAAAAAAABkARQnAQ) |
     */
        public CrosshairsType? type { get; set; }

        /**
     * 辅助线的样式配置。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 线的样式配置
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L1177|CrosshairLineCfg}
     */
        public CrosshairLineCfg? line { get; set; }

        /**
     * 辅助线文本配置，支持回调。
         * export declare type TooltipCrosshairsTextCallback = (type: string, defaultContent: any, items: any[], currentPoint: Point) => TooltipCrosshairsText;
     */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<TooltipCrosshairsText, JSCall>? text { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("text")]
        [Newtonsoft.Json.JsonProperty("text")]
        public object? _text => text?.Value;

        /**
     * 辅助线文本背景配置。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public number | number[]? padding { get; set; } // 文本背景周围的留白
     *   public ShapeAttrs? style { get; set; } // 文本背景的样式
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L1185|CrosshairTextBackgroundCfg}
     */
        public CrosshairTextBackgroundCfg? textBackground { get; set; }

        /** 辅助线是否跟随鼠标移动，默认为 false，即定位到数据点 */
        public bool? follow { get; set; }
    }

    public class CrosshairTextBackgroundCfg
    {
        /**
     * 文本背景周围的留白
     * @type {number|number[]}
     */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<double, double[]>? padding { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("padding")]
        [Newtonsoft.Json.JsonProperty("padding")]
        public object? _padding => padding?.Value;

        /**
     * 文本背景的样式
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class CrosshairLineCfg
    {
        /**
             * 线的配置项
             * @type {ShapeAttrs}
             */
        public ShapeStyle style { get; set; }
    }

    public class CrosshairTextBaseCfg
    {
        /**
     * 文本位置，只支持 start， end
     * @type {string}
     */
        public string? position { get; set; }

        /**
     * 文本内容
     */
        public string? content { get; set; }

        /**
     * 距离线的距离
     * @type {number}
     */
        public double? offset { get; set; }
    }

    public class CrosshairTextCfg : CrosshairTextBaseCfg
    {
        /**
     * 是否自动旋转
     * @type {boolean}
     */
        public bool? autoRotate { get; set; }

        /**
     * 文本的配置项
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    /**
 * Tooltip Crosshairs 的文本数据结构。
 */
    public class TooltipCrosshairsText : CrosshairTextCfg
    {
        /** crosshairs 文本内容 */
        public string? content { get; set; }
    }
}
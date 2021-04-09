using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    /** 点位置信息 */
    public class Point
    {
        public double x { get; set; }

        public double y { get; set; }
    };

    /** 描述一个点 x y 位置 */
    public class Position
    {
        public double x { get; set; }

        public double y { get; set; }

        public double this[int index]
        {
            get =>
                index switch
                {
                    0 => x,
                    1 => y,
                    _ => throw new IndexOutOfRangeException()
                };
            set { _ = index == 0 ? x = value : index == 1 ? y = value : throw new IndexOutOfRangeException(); }
        }
    };

    /** 一个区域描述 */
    public class Region
    {
        /** the top-left corner of layer-range, range from 0 to 1, relative to parent layer's range */
        public Point start { get; set; }

        /** the bottom-right corner of layer-range, range from 0 to 1, relative to parent layer's range */
        public Point end { get; set; }
    };

    /** 位置 */
    public class BBox
    {
        public double x { get; set; }

        public double y { get; set; }

        public double width { get; set; }

        public double height { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TextStyleAlign
    {
        [System.Text.Json.Serialization.JsonPropertyName("center")]
        [Newtonsoft.Json.JsonProperty("center")]
        center,

        [System.Text.Json.Serialization.JsonPropertyName("left")]
        [Newtonsoft.Json.JsonProperty("left")]
        left,

        [System.Text.Json.Serialization.JsonPropertyName("right")]
        [Newtonsoft.Json.JsonProperty("right")]
        right
    }

    public enum TextStyleBaseline
    {
        [System.Text.Json.Serialization.JsonPropertyName("middle")]
        [Newtonsoft.Json.JsonProperty("middle")]
        middle,

        [System.Text.Json.Serialization.JsonPropertyName("top")]
        [Newtonsoft.Json.JsonProperty("top")]
        top,

        [System.Text.Json.Serialization.JsonPropertyName("bottom")]
        [Newtonsoft.Json.JsonProperty("bottom")]
        bottom
    }

    /** 文字 */
    public class TextStyle
    {
        /** 文本大小 */
        public double? fontSize { get; set; }

        /** 字体系列 */
        public string? fontFamily { get; set; }

        /** 文本粗细 */
        public double? fontWeight { get; set; }

        /** 文本行高 */
        public double? lineHeight { get; set; }

        /** 文本对齐方式 */
        public TextStyleAlign? textAlign { get; set; }

        /** 文本基线 */
        public TextStyleBaseline? textBaseline { get; set; }
    };

    public class Size
    {
        public double width { get; set; }

        public double height { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RenderEngine
    {
        [System.Text.Json.Serialization.JsonPropertyName("svg")]
        [Newtonsoft.Json.JsonProperty("svg")]
        svg,

        [System.Text.Json.Serialization.JsonPropertyName("canvas")]
        [Newtonsoft.Json.JsonProperty("canvas")]
        canvas
    }

    public class Options
    {
        // 画布基本配置
        /** 画布宽度 */
        public double? width { get; set; }

        /** 画布高度 */
        public double? height { get; set; }

        /** 画布是否自动适配容器大小，默认为 true */
        public bool? autoFit { get; set; }

        /** 画布的 padding 值，或者开启 'auto' */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<double[], double, AutoPadding>? padding { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("padding")]
        [Newtonsoft.Json.JsonProperty("padding")]
        public object? _padding => padding?.Value;

        /** 额外怎加的 padding 值 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<double[], double>? appendPadding { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("appendPadding")]
        [Newtonsoft.Json.JsonProperty("appendPadding")]
        public object? _appendPadding => appendPadding?.Value;

        /// <summary>
        /// 是否同步子 view 的 padding <br/>
        /// export declare type SyncViewPaddingFn = (chart: View, views: View[], PC: PaddingCalCtor) => void;
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, JSCall>? syncViewPadding { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("syncViewPadding")]
        [Newtonsoft.Json.JsonProperty("syncViewPadding")]
        public object? _syncViewPadding => syncViewPadding?.Value;

        // G 相关
        /** 渲染引擎 */
        public RenderEngine? renderer { get; set; }

        /** 屏幕像素比，默认为 window.devicePixelRatio */
        public double? pixelRatio { get; set; }

        /** 是否开启局部渲染，默认为 true */
        public bool? localRefresh { get; set; }

        /** 支持 CSS transform，开启后图表的交互以及事件将在页面设置了 css transform 属性时生效，默认关闭。 */
        public bool? supportCSSTransform { get; set; }

        // 通用数据配置
        /** 具体的数据 */
        public List<Dictionary<string, object>> data { get; set; }

        /** 数据字段元信息 */
        public Dictionary<string, Meta>? meta { get; set; }

        // G2 相关
        /** 主题，G2 主题，字符串或者 theme object */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, object>? theme { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("theme")]
        [Newtonsoft.Json.JsonProperty("theme")]
        public object? _theme => theme?.Value;

        /** 颜色色板
         * string | string[] | ((datum: Datum) => string)
         */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, string[], JSCall>? color { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("color")]
        [Newtonsoft.Json.JsonProperty("color")]
        public object? _color => color?.Value;

        /** xAxis 的配置项 */
        public Axis? xAxis { get; set; }

        /** yAxis 的配置项 */
        public Axis? yAxis { get; set; }

        /** 数据标签的配置 */
        public Label? label { get; set; }

        /** tooltip 的配置项 */
        public TooltipOption? tooltip { get; set; }

        /** 图例 legend 的配置项 */
        public Legend? legend { get; set; }

        /** 缩略轴 slider 的配置项 */
        public SliderOption? slider { get; set; }

        /** 缩略轴 scrollbar 的配置项 */
        public ScrollbarOption? scrollbar { get; set; }

        public AnimateOption? animation { get; set; }

        public Interaction[]? interactions { get; set; }

        public Annotation[]? annotations { get; set; }

        // 配置 active，inactive，selected 三种状态的样式，也可在 Theme 主题中配置
        public StateOption? state { get; set; }

        /** 是否对超出坐标系范围的 Geometry 进行剪切 */
        public bool? limitInPlot { get; set; }
    }

    /** Geometry 下每个 state 的配置结构 */
    public class StateCfg
    {
        /** 状态样式配置。
         * export declare type StateStyleCallback = (element: Element) => LooseObject;
         */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<object, JSCall>? style { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("style")]
        [Newtonsoft.Json.JsonProperty("style")]
        public object? _style => style?.Value;
    }

    /** geometry.state({}) 配置定义 */
    public class StateOption
    {
        /** 默认状态样式。 */
        [System.Text.Json.Serialization.JsonPropertyName("default")]
        [Newtonsoft.Json.JsonProperty("default")]
        public StateCfg? defaultState { get; set; }

        /** active 状态配置。 */
        public StateCfg? active { get; set; }

        /** inactive 状态配置。 */
        public StateCfg? inactive { get; set; }

        /** selected 状态配置。 */
        public StateCfg? selected { get; set; }
    }

    public class Annotation
    { }

    public class Interaction
    {
        public string type { get; set; }

        public Dictionary<string, object>? cfg { get; set; }

        /** 是否开启交互, 默认开启 */
        public bool? enable { get; set; }
    }
}
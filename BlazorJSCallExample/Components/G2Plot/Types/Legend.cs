using System.Text.Json.Serialization;
using BlazorJSCallExample.Core;
using ShapeAttrs = G2Plot.Types.ShapeStyle;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LegendLayout
    {
        [System.Text.Json.Serialization.JsonPropertyName("horizontal")]
        [Newtonsoft.Json.JsonProperty("horizontal")]
        horizontal,

        [System.Text.Json.Serialization.JsonPropertyName("vertical")]
        [Newtonsoft.Json.JsonProperty("vertical")]
        vertical
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LegendPosition
    {
        [System.Text.Json.Serialization.JsonPropertyName("top")]
        [Newtonsoft.Json.JsonProperty("top")]
        top,

        [JsonPropertyName("top-left")]
        topLeft,

        [JsonPropertyName("top-right")]
        topRight,

        [System.Text.Json.Serialization.JsonPropertyName("right")]
        [Newtonsoft.Json.JsonProperty("right")]
        right,

        [JsonPropertyName("right-top")]
        rightTop,

        [JsonPropertyName("right-bottom")]
        rightBottom,

        [System.Text.Json.Serialization.JsonPropertyName("left")]
        [Newtonsoft.Json.JsonProperty("left")]
        left,

        [JsonPropertyName("left-top")]
        leftTop,

        [JsonPropertyName("left-bottom")]
        leftBottom,

        [System.Text.Json.Serialization.JsonPropertyName("bottom")]
        [Newtonsoft.Json.JsonProperty("bottom")]
        bottom,

        [JsonPropertyName("bottom-left")]
        bottomLeft,

        [JsonPropertyName("bottom-right")]
        bottomRight,
    }

    public class LegendItemValueCfg
    {
        /**
    * 是否右对齐，默认为 false，仅当设置图例项宽度时生效
    * @type {boolean}
    */
        public bool? alignRight { get; set; }

        /**
    * 格式化文本函数
    * @type {formatterCallback}
    */
        public JSCall? formatter { get; set; }

        /**
    * 图例项附加值的配置
    * @type {ShapeAttrs}
    */
        public ShapeStyle? style { get; set; }
    }

    public class G2LegendTitleCfg
    {
        /**
     * 标题同图例项的间距
     * @type {number}
     */
        public double? spacing { get; set; }

        /**
     * 文本配置项
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class LegendItemNameCfg
    {
        /**
    * 图例项 name 同后面 value 的间距
    * @type {number}
    */
        public double? spacing { get; set; }

        /**
    * 格式化文本函数
    * @type {formatterCallback}
         * declare type formatterCallback = (text: string, item: ListItem, index: number) => any;
    */
        public JSCall? formatter { get; set; }

        /**
    * 文本配置项
    * @type {ShapeAttrs}
    */
        public ShapeStyle? style { get; set; }
    }

    public class LegendBackgroundCfg
    {
        /**
     * 图例项 name 同后面 value 的间距
     * @type {number}
     */
        public double? spacing { get; set; }

        /// <summary>
        /// 格式化文本函数
        /// @type {formatterCallback} <br/>
        /// declare type formatterCallback = (text: string, item: ListItem, index: number) => any;
        /// </summary>
        public JSCall? formatter { get; set; }

        /**
     * 文本配置项
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class Legend
    {
        /**
    * 是否为自定义图例，当该属性为 true 时，需要声明 items 属性。
    */
        public bool? custom { get; set; }

        /**
    * 布局方式： horizontal，vertical
    */
        public LegendLayout? layout { get; set; }

        /**
    * 图例标题配置，默认不展示。
    *
    * 属性结构如下：
    *
    * ```ts
    * {
    *   spacing?: number;    // 标题同图例项的间距
    *   style?: ShapeAttrs;  // 文本样式配置项
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L639|LegendTitleCfg}，
    */
        public G2LegendTitleCfg? title { get; set; }

        /**
    * 背景框配置项。
    *
    * 属性结构如下：
    *
    * ```ts
    * {
    *   padding?: number | number[]; // 背景的留白
    *   style?: ShapeAttrs;          // 背景样式配置项
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L652|LegendBackgroundCfg}
    */
        public LegendBackgroundCfg? background { get; set; }

        /** 图例的位置。 */
        public LegendPosition? position { get; set; }

        /** 动画开关，默认关闭。 */
        public bool? animate { get; set; }

        /** 动画参数配置，当且仅当 `animate` 属性为 true，即动画开启时生效。 */
        public ComponentAnimateOption? animateOption { get; set; }

        /**
    * **分类图例适用**，控制图例项水平方向的间距。
    */
        public double? itemSpacing { get; set; }

        /**
    * **分类图例适用**，控制图例项垂直方向的间距。
    */
        public double? itemMarginBottom { get; set; }

        /**
    * **分类图例适用**，图例项的最大宽度，超出则自动缩略。
    * `maxItemWidth` 可以是像素值；
    * 也可以是相对值（取 0 到 1 范围的数值），代表占图表宽度的多少
    */
        public double? maxItemWidth { get; set; }

        /**
    * **分类图例适用**，图例项的宽度, 默认为 null，自动计算。
    */
        public double? itemWidth { get; set; }

        /**
    * **分类图例适用**，图例的高度，默认为 null。
    */
        public double? itemHeight { get; set; }

        /**
    * **分类图例适用**，图例项 name 文本的配置。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   spacing?: number; // 图例项 name 同后面 value 的间距
    *   formatter?: (text: string, item: ListItem, index: number) => any; // 格式化文本函数
    *   style?: ShapeAttrs; // 文本配置项
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L665|LegendItemNameCfg}，
    */
        public LegendItemNameCfg? itemName { get; set; }

        /**
    * **分类图例适用**，图例项 value 附加值的配置项。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   alignRight?: bool; // 是否右对齐，默认为 false，仅当设置图例项宽度时生效
    *   formatter?: (text: string, item: ListItem, index: number) => any; // 格式化文本函数
    *   style?: ShapeAttrs; // 图例项附加值的配置
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L685|LegendItemValueCfg}，
    */
        public LegendItemValueCfg? itemValue { get; set; }

        /**
    * **分类图例适用**，图例项最大宽度设置。
    */
        public double? maxWidth { get; set; }

        /**
    * **分类图例适用**，图例项最大高度设置。
    */
        public double? maxHeight { get; set; }

        /**
    * **分类图例适用**，图例项的 marker 图标的配置。
    */
        public MarkerCfg? marker { get; set; }

        /**
    * **适用于分类图例**，当图例项过多时是否进行分页。
    */
        public bool? flipPage { get; set; }

        /**
    * **分类图例适用**，用户自己配置图例项的内容。
    */
        public LegendItem[]? items { get; set; }

        /**
    * **分类图例适用**，是否将图例项逆序展示。
    */
        public bool? reversed { get; set; }

        /**
    * **连续图例适用**，选择范围的最小值。
    */
        public double? min { get; set; }

        /**
    * **连续图例适用**，选择范围的最大值。
    */
        public double? max { get; set; }

        /**
    * **连续图例适用**，选择的值。
    */
        public double[]? value { get; set; }

        /**
    * **连续图例适用**，选择范围的色块样式配置项。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   style?: ShapeAttrs; // 选定范围的样式
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L574|ContinueLegendTrackCfg}
    */
        public ContinueLegendTrackCfg? track { get; set; }

        /**
    * **连续图例适用**，图例滑轨（背景）的样式配置项。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   type?: string; // rail 的类型，color, size
    *   size?: number; // 滑轨的宽度
    *   defaultLength?: number; // 滑轨的默认长度，，当限制了 maxWidth,maxHeight 时，不会使用这个属性会自动计算长度
    *   style?: ShapeAttrs; // 滑轨的样式
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L595|ContinueLegendRailCfg}，
    */
        public ContinueLegendRailCfg? rail { get; set; }

        /**
    * **连续图例适用**，文本的配置项。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   // 文本同滑轨的对齐方式，有五种类型
    *   // rail ： 同滑轨对齐，在滑轨的两端
    *   // top, bottom: 图例水平布局时有效
    *   // left, right: 图例垂直布局时有效
    *   align?: string;
    *   spacing?: number; // 文本同滑轨的距离
    *   style?: ShapeAttrs; // 文本样式
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L618|ContinueLegendLabelCfg}
    */
        public ContinueLegendLabelCfg? label { get; set; }

        /**
    * **连续图例适用**，滑块的配置项。
    * 属性结构如下：
    *
    * ```ts
    * {
    *   size?: number; // 滑块的大小
    *   style?: ShapeAttrs; // 滑块的样式设置
    * }
    * ```
    *
    * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L582|ContinueLegendTrackCfg}，
    */
        public ContinueLegendHandlerCfg? handler { get; set; }

        /**
    * **连续图例适用**，滑块是否可以滑动。
    */
        public bool? slidable { get; set; }

        /** 图例 x 方向的偏移。 */
        public double? offsetX { get; set; }

        /** 图例 y 方向的偏移。 */
        public double? offsetY { get; set; }

        /** 图例在四个方向的偏移量 */
        public double[]? padding { get; set; }
    }

    public class ContinueLegendHandlerCfg
    {
        /**
    * 滑块大小
    * @type {number}
    */
        public double? size { get; set; }

        /**
    * 滑块样式
    * @type {ShapeAttrs}
    */
        public ShapeStyle? style { get; set; }
    }

    public class ContinueLegendLabelCfg
    {
        /**
     * 文本同滑轨的对齐方式，有五种类型
     *  - rail ： 同滑轨对齐，在滑轨的两端
     *  - top, bottom: 图例水平布局时有效
     *  - left, right: 图例垂直布局时有效
     * @type {string}
     */
        public string? align { get; set; }

        /**
     * 文本同滑轨的距离
     * @type {number}
     */
        public double? spacing { get; set; }

        /**
     * 文本样式
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class ContinueLegendRailCfg
    {
        /**
     * rail 的类型，color, size
     * @type {string}
     */
        public string? type { get; set; }

        /**
     * 滑轨的宽度
     * @type {number}
     */
        public double? size { get; set; }

        /**
     * 滑轨的默认长度，，当限制了 maxWidth,maxHeight 时，不会使用这个属性会自动计算长度
     * @type {number}
     */
        public double? defaultLength { get; set; }

        /**
     * 滑轨的样式
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class ContinueLegendTrackCfg
    {
        /**
     * 选定范围的样式
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }
    }

    public class LegendItem
    {
        /**
    * 唯一值，用于动画或者查找
    */
        public string? id { get; set; }

        /** 名称 */
        public string name { get; set; }

        /** 值 */
        public object value { get; set; }

        /** 图形标记 */
        public MarkerCfg? marker { get; set; }

        /** 初始是否处于未激活状态 */
        [System.Text.Json.Serialization.JsonPropertyName("unchecked")]
        [Newtonsoft.Json.JsonProperty("unchecked")]
        public bool? isUnchecked { get; set; }
    }
}
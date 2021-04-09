namespace G2Plot.Types
{
    public class AxisCfg
    {
        /**
     * 适用于直角坐标系，设置坐标轴的位置。
     */
        public AxisPosition? position { get; set; }

        /**
     * 坐标轴线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴线的样式配置项
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L91|AxisLineCfg}
     */
        public AxisLineCfg? line { get; set; }

        /**
     * 坐标轴刻度线线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴刻度线的样式配置项
     *   public boolean? alignTick { get; set; } // 是否同 tick 对齐
     *   public number? length { get; set; }  // 长度
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L103|AxisTickLineCfg}
     */
        public AxisTickLineCfg? tickLine { get; set; }

        /**
     * 坐标轴子刻度线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴刻度线的样式配置项
     *   public number? count { get; set; } // 子刻度个数
     *   public number? length { get; set; } // 子刻度线长度
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L169|AxisSubTickLineCfg}
     */
        public AxisSubTickLineCfg? subTickLine { get; set; }

        /**
     * 标题的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public number? offset { get; set; } // 标题距离坐标轴的距离
     *   public ShapeAttrs? style { get; set; } // 标题文本配置项
     *   public boolean? autoRotate { get; set; } // 是否自动旋转
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L191|AxisTitleCfg}
     */
        public AxisTitleCfg? title { get; set; }

        /**
     * 文本标签的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   // 坐标轴文本的样式
     *   public ShapeAttrs? style { get; set; }
     *   // label 的偏移量
     *   public number? offset { get; set; }
     *   // 文本旋转角度
     *   public number? rotate { get; set; }
     *   // 格式化函数
     *   public (text: string, item: ListItem, index: number) => any? formatter { get; set; }
     *   // 是否自动旋转，默认 false
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoRotate { get; set; }
     *   // 是否自动隐藏，默认 true
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoHide { get; set; }
     *   // 是否自动省略，默认 false
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoEllipsis { get; set; }
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L127|AxisLabelCfg}
     */
        public AxisLabelCfg? label { get; set; }

        /** 坐标轴网格线的配置项，null 表示不展示。 */
        public AxisGridCfg? grid { get; set; }

        /** 动画开关，默认开启。 */
        public bool? animate { get; set; }

        /** 动画参数配置。 */
        public ComponentAnimateOption? animateOption { get; set; }

        /** 标记坐标轴 label 的方向，左侧为 1，右侧为 -1。 */
        public double? verticalFactor { get; set; }

        /**
     * 配置坐标轴垂直方向的最大限制长度，对文本自适应有很大影响。
     * 1. 可以直接设置像素值，如 100；
     * 2. 也可设置绝对值，如 0.2，如果是 x 轴，则相对于图表的高度，如果是 y 轴，则相对于图表的宽度
     *
     * 在 G2 中，x 轴的文本默认最大高度为图表高度的 1/2，y 轴的文本默认最大长度为图表宽度的 1/3
     */
        public double? verticalLimitLength { get; set; }
    }

    public interface IAxisCfg
    {
        /**
     * 适用于直角坐标系，设置坐标轴的位置。
     */
        public AxisPosition? position { get; set; }

        /**
     * 坐标轴线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴线的样式配置项
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L91|AxisLineCfg}
     */
        public AxisLineCfg? line { get; set; }

        /**
     * 坐标轴刻度线线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴刻度线的样式配置项
     *   public boolean? alignTick { get; set; } // 是否同 tick 对齐
     *   public number? length { get; set; }  // 长度
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L103|AxisTickLineCfg}
     */
        public AxisTickLineCfg? tickLine { get; set; }

        /**
     * 坐标轴子刻度线的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public ShapeAttrs? style { get; set; } // 坐标轴刻度线的样式配置项
     *   public number? count { get; set; } // 子刻度个数
     *   public number? length { get; set; } // 子刻度线长度
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L169|AxisSubTickLineCfg}
     */
        public AxisSubTickLineCfg? subTickLine { get; set; }

        /**
     * 标题的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   public number? offset { get; set; } // 标题距离坐标轴的距离
     *   public ShapeAttrs? style { get; set; } // 标题文本配置项
     *   public boolean? autoRotate { get; set; } // 是否自动旋转
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L191|AxisTitleCfg}
     */
        public AxisTitleCfg? title { get; set; }

        /**
     * 文本标签的配置项，null 表示不展示。
     * 属性结构如下：
     *
     * ```ts
     * {
     *   // 坐标轴文本的样式
     *   public ShapeAttrs? style { get; set; }
     *   // label 的偏移量
     *   public number? offset { get; set; }
     *   // 文本旋转角度
     *   public number? rotate { get; set; }
     *   // 格式化函数
     *   public (text: string, item: ListItem, index: number) => any? formatter { get; set; }
     *   // 是否自动旋转，默认 false
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoRotate { get; set; }
     *   // 是否自动隐藏，默认 true
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoHide { get; set; }
     *   // 是否自动省略，默认 false
     *   public boolean | (isVertical: boolean, labelGroup: IGroup, limitLength?: number) => boolean; | string? autoEllipsis { get; set; }
     * }
     * ```
     *
     * 详见 {@link https://github.com/antvis/component/blob/81890719a431b3f9088e0c31c4d5d382ef0089df/src/types.ts#L127|AxisLabelCfg}
     */
        public AxisLabelCfg? label { get; set; }

        /** 坐标轴网格线的配置项，null 表示不展示。 */
        public AxisGridCfg? grid { get; set; }

        /** 动画开关，默认开启。 */
        public bool? animate { get; set; }

        /** 动画参数配置。 */
        public ComponentAnimateOption? animateOption { get; set; }

        /** 标记坐标轴 label 的方向，左侧为 1，右侧为 -1。 */
        public double? verticalFactor { get; set; }

        /**
     * 配置坐标轴垂直方向的最大限制长度，对文本自适应有很大影响。
     * 1. 可以直接设置像素值，如 100；
     * 2. 也可设置绝对值，如 0.2，如果是 x 轴，则相对于图表的高度，如果是 y 轴，则相对于图表的宽度
     *
     * 在 G2 中，x 轴的文本默认最大高度为图表高度的 1/2，y 轴的文本默认最大长度为图表宽度的 1/3
     */
        public double? verticalLimitLength { get; set; }
    }
}
using OneOf;

namespace G2Plot.Types
{
    public class ShapeStyle
    {
        /** x 坐标 */
        public double? x { get; set; }

        /** y 坐标 */
        public double? y { get; set; }

        /** 圆半径 */
        public double? r { get; set; }

        /** 描边颜色 */
        public string? stroke { get; set; }

        /** 描边透明度 */
        public double? strokeOpacity { get; set; }

        /** 填充颜色 */
        public string? fill { get; set; }

        /** 填充透明度 */
        public double? fillOpacity { get; set; }

        /** 整体透明度 */
        public double? opacity { get; set; }

        /** 线宽 */
        public double? lineWidth { get; set; }

        /** 指定如何绘制每一条线段末端 */
        public LineCap? lineCap { get; set; }

        /** 用来设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性（长度为0的变形部分，其指定的末端和控制点在同一位置，会被忽略） */
        public LineJoin? lineJoin { get; set; }

        /**
        * 设置线的虚线样式，可以指定一个数组。一组描述交替绘制线段和间距（坐标空间单位）长度的数字。 如果数组元素的数量是奇数， 数组的元素会被复制并重复。例如， [5, 15, 25] 会变成 [5, 15, 25, 5, 15, 25]。这个属性取决于浏览器是否支持 setLineDash() 函数。
        */
        public double[]? lineDash { get; set; }

        /** Path 路径 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, object[]>? path { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("path")]
        [Newtonsoft.Json.JsonProperty("path")]
        public object? _path => path?.Value;

        /** 图形坐标点 */
        public object[]? points { get; set; }

        /** 宽度 */
        public double? width { get; set; }

        /** 高度 */
        public double? height { get; set; }

        /** 阴影模糊效果程度 */
        public double? shadowBlur { get; set; }

        /** 阴影颜色 */
        public string? shadowColor { get; set; }

        /** 阴影 x 方向偏移量 */
        public double? shadowOffsetX { get; set; }

        /** 阴影 y 方向偏移量 */
        public double? shadowOffsetY { get; set; }

        /** 设置文本内容的当前对齐方式 */
        public ShapeStyleTextAlign? textAlign { get; set; }

        /** 设置在绘制文本时使用的当前文本基线 */
        public ShapeStyleTextBaseLine? textBaseline { get; set; }

        /** 字体样式 */
        public FontStyle? fontStyle { get; set; }

        /** 文本字体大小 */
        public double? fontSize { get; set; }

        /** 文本字体 */
        public string? fontFamily { get; set; }

        /** 文本粗细 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<FontWeight, double>? fontWeight { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fontWeight")]
        [Newtonsoft.Json.JsonProperty("fontWeight")]
        public object? _fontWeight => fontWeight?.Value;

        /** 字体变体 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<FontVariant, string>? fontVariant { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fontVariant")]
        [Newtonsoft.Json.JsonProperty("fontVariant")]
        public object? _fontVariant => fontVariant?.Value;

        /** 文本行高 */
        public double? lineHeight { get; set; }
    }
}
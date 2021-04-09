using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using G2Plot.Types;
using Newtonsoft.Json;
using OneOf;

namespace G2Plot.Plot
{
    public class GaugeOption : Options
    {
        /** 指标的比例 0 ~ 1 */
        public double percent { get; set; }

        /** 外弧度 0 ~ 1 */
        public double? radius { get; set; }

        /** 内弧度 0 ~ 1 */
        public double? innerRadius { get; set; }

        /** 弧度起始 */
        public double? startAngle { get; set; }

        /** 弧度结束 */
        public double? endAngle { get; set; }

        /** 辅助的 range 组件 */
        public Range? range { get; set; }

        /** 坐标轴配置 */
        public Axis? axis { get; set; }

        /** 指针的配置 */
        public Indicator? indicator { get; set; }

        /** 统计文本 */
        public Statistic? statistic { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_data")]
        [JsonProperty("_omit_data")]
        public new List<Dictionary<string, object>> data { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_tooltip")]
        [JsonProperty("_omit_tooltip")]
        public new TooltipOption? tooltip { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_legend")]
        [JsonProperty("_omit_legend")]
        public new Legend? legend { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_xAxis")]
        [JsonProperty("_omit_xAxis")]
        public new Axis? xAxis { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_yAxis")]
        [JsonProperty("_omit_yAxis")]
        public new Axis? yAxis { get; set; }

        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("_omit_color")]
        [JsonProperty("_omit_color")]
        public new object? _color { get; set; }
    }

    /** 指标指标的配置 */
    public class Indicator
    {
        // 指针
        public IndicatorObject? pointer { get; set; }

        // 圆环
        public IndicatorObject? pin { get; set; }
    };

    public class IndicatorObject
    {
        public ShapeStyle style { get; set; } // 只允许静态的 object
    }

    public class Range
    {
        /** 辅助的刻度值 0 ~ 1 的数字 */
        public double[]? ticks { get; set; }

        /** 辅助刻度的颜色配置 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, string[]>? color { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("color")]
        [Newtonsoft.Json.JsonProperty("color")]
        public object? _color => color?.Value;
    }
}
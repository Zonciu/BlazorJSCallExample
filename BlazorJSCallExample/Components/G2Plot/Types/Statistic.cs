using System.Collections.Generic;
using System.Text.Json.Serialization;
using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    public class Statistic
    {
        public StatisticText? title { get; set; }

        public StatisticText? content { get; set; }
    }

    public class StatisticText
    {
        /// <summary>
        /// 统计文本的样式 <br/>
        /// CSSStyle | ((datum: Datum) => CSSStyle)?
        /// </summary>
        [JsonIgnore]
        public OneOf<Dictionary<string, object>, JSCall>? style { get; set; }

        [JsonPropertyName("style")]
        public object? _style => style?.Value;

        /// <summary>
        /// 文本的格式化 <br/>
        /// (datum?: Datum, data?: Data /** filterData */) => string?
        /// </summary>
        public JSCall formatter { get; set; }

        public double? rotate { get; set; }

        public double? offsetX { get; set; }

        public double? offsetY { get; set; }

        /// <summary>
        /// 自定义中心文本的 html <br/>
        /// (container: HTMLElement, view: View, datum?: Datum, data?: Data /** filterData */) => string?
        /// </summary>
        public JSCall customHtml { get; set; }
    }
}
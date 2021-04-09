using BlazorJSCallExample.Core;

namespace G2Plot.Types
{
    public class TrendCfg
    {
        public double[] data { get; set; }

        public bool? smooth { get; set; }

        public bool? isArea { get; set; }

        public object? backgroundStyle { get; set; }

        public object? lineStyle { get; set; }

        public object? areaStyle { get; set; }
    }

    public class SliderOption
    {
        /** slider 高度 */
        public double? height { get; set; }

        /** 滑块背景区域配置 */
        public TrendCfg? trendCfg { get; set; }

        /** 滑块背景样式 */
        public object? backgroundStyle { get; set; }

        /** 滑块前景样式 */
        public object? foregroundStyle { get; set; }

        /** 滑块两个操作块样式 */
        public object? handlerStyle { get; set; }

        /** 文本样式 */
        public object? textStyle { get; set; }

        /** 允许滑动位置的最小值 */
        public double? minLimit { get; set; }

        /** 允许滑动位置的最大值 */
        public double? maxLimit { get; set; }

        /** 滑块初始化的起始位置 */
        public double? start { get; set; }

        /** 滑块初始化的结束位置 */
        public double? end { get; set; }

        /** 布局的 padding */
        public double[]? padding { get; set; }

        /// <summary>
        /// 滑块文本格式化函数  <br/>
        /// (val: any, datum: Datum, idx: double) => any?
        /// </summary>
        public JSCall formatter { get; set; }
    }
}
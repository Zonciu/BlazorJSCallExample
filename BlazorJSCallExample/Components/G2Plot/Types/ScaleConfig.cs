using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    public class ScaleConfig
    {
        /** 对应的字段id */
        public string? field { get; set; }

        /** 输入域、定义域 */
        public object[]? values { get; set; }

        /** 定义域的最小值，d3为domain，ggplot2为limits，分类型下无效 */
        public object? min { get; set; }

        /** 定义域的最大值，分类型下无效 */
        public object? max { get; set; }

        /** 严格模式下的定义域最小值，设置后会强制 ticks 从最小值开始 */
        public object? minLimit { get; set; }

        /** 严格模式下的定义域最大值，设置后会强制 ticks 已最大值结束 */
        public object? maxLimit { get; set; }

        /** 数据字段的显示别名，scale内部不感知，外部注入 */
        public string? alias { get; set; }

        /** 输出域、值域，默认值为[0, 1] */
        public double[]? range { get; set; }

        /** Log有效，底数 */
        [System.Text.Json.Serialization.JsonPropertyName("base")]
        [Newtonsoft.Json.JsonProperty("base")]
        public double? logBase { get; set; }

        /** Pow有效，指数 */
        public double? exponent { get; set; }

        /** 自动调整min、max */
        public bool? nice { get; set; }

        /** 用于指定tick，优先级最高 */
        public object[]? ticks { get; set; }

        /** tick间隔，只对分类型和时间型适用，优先级高于tickCount */
        public double? tickInterval { get; set; }

        /** tick最小间隔，只对线型适用 */
        public double? minTickInterval { get; set; }

        /** tick个数，默认值为5 */
        public double? tickCount { get; set; }

        /** ticks最大值，默认值为10 */
        public double? maxTickCount { get; set; }

        /// <summary>
        /// tick格式化函数，会影响数据在坐标轴 axis、图例 legend、tooltip 上的显示 <br/>
        /// (v: object, k?: double) => object
        /// </summary>
        public JSCall? formatter { get; set; }

        /// <summary>
        /// 计算 ticks 的算法 <br/>
        /// export declare type TickMethod = (ScaleConfig: any) => any[];
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, JSCall>? tickMethod { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tickMethod")]
        [Newtonsoft.Json.JsonProperty("tickMethod")]
        public object? _tickMethod => tickMethod?.Value;

        /** 时间度量 time, timeCat 时有效 */
        public string? mask { get; set; }
    }
    
    public interface IScaleConfig
    {
        /** 对应的字段id */
        public string? field { get; set; }

        /** 输入域、定义域 */
        public object[]? values { get; set; }

        /** 定义域的最小值，d3为domain，ggplot2为limits，分类型下无效 */
        public object? min { get; set; }

        /** 定义域的最大值，分类型下无效 */
        public object? max { get; set; }

        /** 严格模式下的定义域最小值，设置后会强制 ticks 从最小值开始 */
        public object? minLimit { get; set; }

        /** 严格模式下的定义域最大值，设置后会强制 ticks 已最大值结束 */
        public object? maxLimit { get; set; }

        /** 数据字段的显示别名，scale内部不感知，外部注入 */
        public string? alias { get; set; }

        /** 输出域、值域，默认值为[0, 1] */
        public double[]? range { get; set; }

        /** Log有效，底数 */
        [System.Text.Json.Serialization.JsonPropertyName("base")]
        [Newtonsoft.Json.JsonProperty("base")]
        public double? logBase { get; set; }

        /** Pow有效，指数 */
        public double? exponent { get; set; }

        /** 自动调整min、max */
        public bool? nice { get; set; }

        /** 用于指定tick，优先级最高 */
        public object[]? ticks { get; set; }

        /** tick间隔，只对分类型和时间型适用，优先级高于tickCount */
        public double? tickInterval { get; set; }

        /** tick最小间隔，只对线型适用 */
        public double? minTickInterval { get; set; }

        /** tick个数，默认值为5 */
        public double? tickCount { get; set; }

        /** ticks最大值，默认值为10 */
        public double? maxTickCount { get; set; }

        /// <summary>
        /// tick格式化函数，会影响数据在坐标轴 axis、图例 legend、tooltip 上的显示 <br/>
        /// (v: object, k?: double) => object
        /// </summary>
        public JSCall? formatter { get; set; }

        /// <summary>
        /// 计算 ticks 的算法 <br/>
        /// export declare type TickMethod = (ScaleConfig: any) => any[];
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, JSCall>? tickMethod { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tickMethod")]
        [Newtonsoft.Json.JsonProperty("tickMethod")]
        public object? _tickMethod => tickMethod?.Value;

        /** 时间度量 time, timeCat 时有效 */
        public string? mask { get; set; }
    }
}
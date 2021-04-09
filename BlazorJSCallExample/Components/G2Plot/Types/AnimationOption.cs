using BlazorJSCallExample.Core;
using OneOf;

namespace G2Plot.Types
{
    public class AnimateOption
    {
        /** chart 初始化渲染时的入场动画，false/null 表示关闭入场动画。 */
        public AnimateCfg? appear { get; set; }

        /** chart 发生更新时，新增元素的入场动画，false/null 表示关闭入场动画。 */
        public AnimateCfg? enter { get; set; }

        /** 更新动画配置，false/null 表示关闭更新动画。 */
        public AnimateCfg? update { get; set; }

        /** 销毁动画配置，false/null 表示关闭销毁动画。 */
        public AnimateCfg? leave { get; set; }
    }

    /// <summary>
    /// /** easing 的回调函数， 入参 data 为对应的原始数据记录 */
    /// export declare type AnimateEasingCallback = (data: Datum) => string;
    /// /** delay 的回调函数， 入参 data 为对应的原始数据记录 */
    /// export declare type AnimateDelayCallback = (data: Datum) => number;
    /// /** duration 的回调函数， 入参 data 为对应的原始数据记录 */
    /// export declare type AnimateDurationCallback = (data: Datum) => number;
    /// </summary>
    public class AnimateCfg
    {
        /** 动画缓动函数 */
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<string, JSCall>? easing { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("easing")]
        [Newtonsoft.Json.JsonProperty("easing")]
        public object? _easing => easing?.Value;

        /** 动画执行函数 */
        public string? animation { get; set; }

        /** 动画执行时间 */
        [System.Text.Json.Serialization.JsonIgnore]
        public OneOf<double, JSCall>? duration { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("duration")]
        [Newtonsoft.Json.JsonProperty("duration")]
        public object? _duration => duration?.Value;

        /** 动画延迟时间 */
        [System.Text.Json.Serialization.JsonIgnore]
        public OneOf<double, JSCall>? delay { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("delay")]
        [Newtonsoft.Json.JsonProperty("delay")]
        public object? _delay => delay?.Value;

        /** 动画执行结束后的回调函数 () => any? */
        public JSCall callback { get; set; }
    }
}

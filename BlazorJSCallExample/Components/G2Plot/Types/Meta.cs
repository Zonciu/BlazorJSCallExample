using OneOf;

namespace G2Plot.Types
{
    public class Meta : ScaleConfig
    {
        /// <summary>
        /// scale 的 type 类型
        /// 对于连续的，一般是 linear，对于分类一般为 cat。
        /// 当然也有 log, pow, time 等类型，或者通过 tickMethod 自定义自己的 scale
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 是否进行 scale 的同步。
        /// - 设置为 false 则不同步
        /// - 设置为 true 则以 field 为 key 进行同步
        /// - 设置为 string，则以这个 string 为 key 进行同步
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, string>? sync { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sync")]
        [Newtonsoft.Json.JsonProperty("sync")]
        public object? _sync => sync?.Value;
    }
    public interface IMeta : IScaleConfig
    {
        /// <summary>
        /// scale 的 type 类型
        /// 对于连续的，一般是 linear，对于分类一般为 cat。
        /// 当然也有 log, pow, time 等类型，或者通过 tickMethod 自定义自己的 scale
        /// </summary>
        public string? type { get; set; }

        /// <summary>
        /// 是否进行 scale 的同步。
        /// - 设置为 false 则不同步
        /// - 设置为 true 则以 field 为 key 进行同步
        /// - 设置为 string，则以这个 string 为 key 进行同步
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public OneOf<bool, string>? sync { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sync")]
        [Newtonsoft.Json.JsonProperty("sync")]
        public object? _sync => sync?.Value;
    }
}
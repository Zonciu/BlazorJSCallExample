using System;
using System.Text.Json.Serialization;

namespace G2Plot.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ScrollbarType
    {
        [System.Text.Json.Serialization.JsonPropertyName("horizontal")]
        [Newtonsoft.Json.JsonProperty("horizontal")]
        horizontal,

        [System.Text.Json.Serialization.JsonPropertyName("vertical")]
        [Newtonsoft.Json.JsonProperty("vertical")]
        vertical
    }

    public class ScrollbarPadding
    {
        public double Up { get; set; }

        public double Right { get; set; }

        public double Down { get; set; }

        public double Left { get; set; }

        public double this[int index]
        {
            get => index switch
            {
                0 => Up,
                1 => Right,
                2 => Down,
                3 => Left,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (index)
                {
                case 0:
                    Up = value;
                    break;
                case 1:
                    Right = value;
                    break;
                case 2:
                    Down = value;
                    break;
                case 3:
                    Left = value;
                    break;
                default:
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public class ScrollbarOption
    {
        /** 滚动条类型，默认 horizontal  */
        public ScrollbarType? type { get; set; }

        /** 宽度，在 vertical 下生效 */
        public double? width { get; set; }

        /** 高度，在 horizontal 下生效 */
        public double? height { get; set; }

        /** 可选 padding */
        public ScrollbarPadding? padding { get; set; }

        /** 对应水平滚动条，为 X 轴每个分类字段的宽度；对于垂直滚动条，为 X 轴每个分类字段的高度 */
        public double? categorySize { get; set; }

        /** 滚动的时候是否开启动画，默认跟随 view 中 animate 配置 */
        public bool? animate { get; set; }
    }
}
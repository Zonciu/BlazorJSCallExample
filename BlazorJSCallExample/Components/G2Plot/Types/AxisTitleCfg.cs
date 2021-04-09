namespace G2Plot.Types
{
    public class AxisTitleCfg
    {
        /**
     * 标题距离坐标轴的距离
     * @type {number}
     */
        public double? offset { get; set; }

        /**
     * 标题距离坐标轴文本的距离
     */
        public double? spacing { get; set; }

        /**
     * 标题文本配置项
     * @type {ShapeAttrs}
     */
        public ShapeStyle? style { get; set; }

        /**
     * 是否自动旋转
     * @type {boolean}
     */
        public bool? autoRotate { get; set; }

        /**
     * 设置文本
     * @type {string}
     */
        public string? text { get; set; }
    }
}
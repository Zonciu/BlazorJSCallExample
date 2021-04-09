namespace G2Plot.Types
{
    public class AxisSubTickLineCfg
    {
        /// <Summary>
        /// 坐标轴刻度线的配置项
        /// @type {ShapeAttrs}
        /// ShapeAttrs | ShapeAttrsCallback
        /// declare type ShapeAttrsCallback = (item: any, index: number, items: any[]) => ShapeAttrs;
        /// </Summary>
        public ShapeStyle? style { get; set; }

        /// <Summary>
        /// 子刻度个数
        /// @type {number}
        /// </Summary>
        public double? count { get; set; }

        /// <Summary>
        /// 子刻度线长度
        /// @type {number}
        /// </Summary>
        public double? length { get; set; }
    }
}
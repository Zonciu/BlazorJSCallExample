namespace G2Plot.Types
{
    public class AxisTickLineCfg
    {
        /// <Summary>
        /// 坐标轴刻度线的配置项
        /// @type {ShapeAttrs}
        /// ShapeAttrs | ShapeAttrsCallback
        /// declare type ShapeAttrsCallback = (item: any, index: number, items: any[]) => ShapeAttrs;
        /// </Summary>
        public ShapeStyle? style { get; set; }

        /// <Summary>
        /// 是否同 tick 对齐
        /// @type {boolean}
        /// </Summary>
        public bool? alignTick { get; set; }

        /// <Summary>
        /// 长度
        /// @type {number}
        /// </Summary>
        public double? length { get; set; }
    }
}
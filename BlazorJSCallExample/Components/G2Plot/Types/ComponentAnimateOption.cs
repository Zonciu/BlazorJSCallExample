namespace G2Plot.Types
{
    public class ComponentAnimateOption
    {
       
        /** 初入场动画配置 */
        public ComponentAnimateCfg? appear { get; set; }
        /** 更新动画配置 */
        public ComponentAnimateCfg? update { get; set; }
        /** 更新后新入场的动画配置 */
        public ComponentAnimateCfg? enter { get; set; }
        /** 离场动画配置 */
        public ComponentAnimateCfg? leave { get; set; }
       
    }

    public class ComponentAnimateCfg
    {
        /** 动画执行时间 */
        public double? duration { get; set; }
        /** 动画缓动函数 */
        public string? easing { get; set; }
        /** 动画延迟时间 */
        public double? delay { get; set; }
    }
}
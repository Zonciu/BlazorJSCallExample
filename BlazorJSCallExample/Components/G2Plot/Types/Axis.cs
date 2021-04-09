using System;
using BlazorJSCallExample.Core;
using Newtonsoft.Json;
using OneOf;

namespace G2Plot.Types
{
    public class Axis : IAxisCfg, IMeta
    {
        /// <inheritdoc />
        public AxisPosition? position { get; set; }

        /// <inheritdoc />
        public AxisLineCfg? line { get; set; }

        /// <inheritdoc />
        public AxisTickLineCfg? tickLine { get; set; }

        /// <inheritdoc />
        public AxisSubTickLineCfg? subTickLine { get; set; }

        /// <inheritdoc />
        public AxisTitleCfg? title { get; set; }

        /// <inheritdoc />
        public AxisLabelCfg? label { get; set; }

        /// <inheritdoc />
        public AxisGridCfg? grid { get; set; }

        /// <inheritdoc />
        public bool? animate { get; set; }

        /// <inheritdoc />
        public ComponentAnimateOption? animateOption { get; set; }

        /// <inheritdoc />
        public double? verticalFactor { get; set; }

        /// <inheritdoc />
        public double? verticalLimitLength { get; set; }

        /// <inheritdoc />
        public string? field { get; set; }

        /// <inheritdoc />
        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        public object[]? values { get; set; }

        /// <inheritdoc />
        public object? min { get; set; }

        /// <inheritdoc />
        public object? max { get; set; }

        /// <inheritdoc />
        public object? minLimit { get; set; }

        /// <inheritdoc />
        public object? maxLimit { get; set; }

        /// <inheritdoc />
        public string? alias { get; set; }

        /// <inheritdoc />
        public double[]? range { get; set; }

        /// <inheritdoc />
        public double? logBase { get; set; }

        /// <inheritdoc />
        public double? exponent { get; set; }

        /// <inheritdoc />
        public bool? nice { get; set; }

        /// <inheritdoc />
        public object[]? ticks { get; set; }

        /// <inheritdoc />
        public double? tickInterval { get; set; }

        /// <inheritdoc />
        public double? minTickInterval { get; set; }

        /// <inheritdoc />
        public double? tickCount { get; set; }

        /// <inheritdoc />
        public double? maxTickCount { get; set; }

        /// <inheritdoc />
        [Obsolete("Omitted property", true)]
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        public JSCall? formatter { get; set; }

        /// <inheritdoc />
        public OneOf<string, JSCall>? tickMethod { get; set; }

        /// <inheritdoc />
        public string? mask { get; set; }

        /// <inheritdoc />
        public string? type { get; set; }

        /// <inheritdoc />
        public OneOf<bool, string>? sync { get; set; }
    }
}
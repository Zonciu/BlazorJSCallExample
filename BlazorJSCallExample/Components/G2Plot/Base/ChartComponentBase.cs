using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace G2Plot.Base
{
    public abstract class ChartComponentBase<TData, TOption> : ComponentBase, IChartComponent, IDisposable
        where TOption : class, new()
    {
        protected string ChartType { get; set; }

        public ChartComponentBase(string chartType, bool isNoDataRender = false)
        {
            ChartType = chartType;
            IsNoDataRender = isNoDataRender;
        }

        #region JS交互

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected ElementReference Ref;

        protected const string ChartsPrefix = "demo.charts.";

        protected const string InteropPrefix = ChartsPrefix + "interop.";

        protected const string InteropInit = ChartsPrefix + "init";

        protected const string InteropCreate = InteropPrefix + "create";

        protected const string InteropDestroy = InteropPrefix + "destroy";

        protected const string InteropRender = InteropPrefix + "render";

        protected const string InteropUpdate = InteropPrefix + "update";

        protected const string InteropChangeData = InteropPrefix + "changeData";

        protected const string InteropChangeSize = InteropPrefix + "changeSize";

        protected const string InteropSetEvent = InteropPrefix + "setEvent";

        protected const string InteropSetEventOnce = InteropPrefix + "setEventOnce";

        protected const string InteropRemoveEvent = InteropPrefix + "removeEvent";

        protected const string InteropSetState = InteropPrefix + "setState";

        protected const string InteropGetState = InteropPrefix + "getState";

        private DotNetObjectReference<ChartComponentBase<TData, TOption>> chartRef;

        #endregion

        #region 图表属性

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public TData Data { get; set; }

        //设置当Data没有数据时，图表是否允许要进行初始化绘制,为了结局某些图表当没有数据时，绘制会发生异常的问题
        protected bool IsNoDataRender { get; set; } = false;

        [Parameter]
        public TOption? Option { get; set; }

        [Parameter]
        public object OtherOption { get; set; }

        #endregion

        #region 图表事件

        [Parameter]
        public EventCallback<IChartComponent> OnCreateAfter { get; set; }

        #endregion

        /// <summary>
        /// 图表是否已经创建
        /// </summary>
        private bool IsCreated = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync(InteropInit);
                if (Option == null)
                {
                    Option = new TOption();
                }

                if (Data != null || IsNoDataRender == true)
                {
                    await Create();
                }
            }
        }

        public async void Dispose()
        {
            try
            {
                if (IsCreated)
                {
                    await JS.InvokeVoidAsync(InteropDestroy, Ref.Id);
                }
                chartRef?.Dispose();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        /// <summary>
        /// 创建图表控件
        /// </summary>
        /// <returns></returns>
        private async Task Create()
        {
            await JS.InvokeVoidAsync(InteropCreate, ChartType, Ref, Ref.Id, Option, OtherOption, Data);
            IsCreated = true;

            if (OnCreateAfter.HasDelegate)
            {
                await OnCreateAfter.InvokeAsync(this);
            }

            chartRef = DotNetObjectReference.Create(this);

            if (OnTitleClick.HasDelegate)
            {
                await SetEvent("title:click", nameof(JsTitleClick));
            }
        }

        #region 图表操作

        /// <summary>
        /// 通过图表构造方法创建实例之后，调用这个方法，可以将图表渲染到指定的 DOM 容器中。
        /// </summary>
        /// <returns></returns>
        public async Task Render()
        {
            await JS.InvokeVoidAsync(InteropRender, Ref.Id);
        }

        /// <summary>
        /// 通过这个方法，可以增量的更新图表配置，方法会自动将传入的增量配置合并到当前的配置项中，并自动调用 render 方法，无需手动调用。
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task Update(object option)
        {
            OtherOption = option;
            await JS.InvokeVoidAsync(InteropUpdate, Ref.Id, option);
        }

        /// <summary>
        /// 通过这个方法，可以修改图表的数据，并自动重新渲染，大部分图表的数据都是二维数组，而部分图表可能数据结构不一样，比如：<br />
        /// 仪表盘、水波图 等指标类的，直接传入更新的 percent 数值<br />
        /// 双轴图等复合类图表，直接传入自己的 data 数据结构<br />
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task ChangeData(object data)
        {
            Data = (TData)data;

            //根据图表是否已经状态决定调用的函数
            if (IsCreated)
            {
                await JS.InvokeVoidAsync(InteropChangeData, Ref.Id, Data);
            }
            else
            {
                await Create();
            }
        }

        /// <summary>
        /// 通过这个方法，手动指定图表的大小。当前如果图表配置 autoFit = true 的时候，图表大小会自动跟随容器的大小，只需要使用 css 约定外层 DOM 容器大小，图表即可自动 跟随 resize；如果 autoFit = false，那么可以使用 changeSize 这个方法，自定义图表的宽高大小。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public async Task ChangeSize(double width, double height)
        {
            await JS.InvokeVoidAsync(InteropRender, Ref.Id, width, height);
        }

        public async Task<string> SetEvent(string eventName, string invokableFunctionName)
        {
            var callbackId = Guid.NewGuid().ToString();
            await JS.InvokeVoidAsync(InteropSetEvent, Ref.Id, eventName, chartRef, invokableFunctionName, callbackId);
            return callbackId;
        }

        public async Task<string> SetEventOnce(string eventName, string invokableFunctionName)
        {
            var callbackId = Guid.NewGuid().ToString();
            await JS.InvokeVoidAsync(InteropSetEventOnce, Ref.Id, eventName, chartRef, invokableFunctionName, callbackId);
            return callbackId;
        }

        public async Task RemoveEvent(string eventName, string callbackId)
        {
            await JS.InvokeVoidAsync(InteropSetEvent, Ref.Id, eventName, chartRef, callbackId);
        }

        public async Task SetState(object state)
        {
            await JS.InvokeVoidAsync(InteropSetState, Ref.Id, state);
        }

        public async Task<JsonElement> GetState(object state)
        {
            return await JS.InvokeAsync<JsonElement>(InteropGetState, Ref.Id);
        }

        #endregion

        #region 图表交互事件

        /// <summary>
        /// 标题点击事件
        /// </summary>
        [Parameter]
        public EventCallback<ChartEvent> OnTitleClick { get; set; }

        [JSInvokable]
        public async Task JsTitleClick(JsonElement ev)
        {
            if (OnTitleClick.HasDelegate)
            {
                await OnTitleClick.InvokeAsync(new ChartEvent(this, ev));
            }
        }

        #endregion
    }
}

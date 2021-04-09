namespace BlazorJSCallExample.Core
{
    /// <summary>
    /// JS调用类型
    /// </summary>
    public enum JSCallType
    {
        /// <summary>
        /// 调用JS原生函数
        /// Call native js function
        /// </summary>
        NativeCall = 1,

        /// <summary>
        /// 动态生成JS函数然后调用
        /// Create function dynamically and call
        /// </summary>
        DynamicFunction = 2,

        /// <summary>
        /// 同步调用.NET方法(只能在wasm模式使用)
        /// Invoke .NET method synchronously (Can only be used in wasm mode)
        /// </summary>
        DotNetInvoke = 3,

        /// <summary>
        /// 异步调用.NET方法
        /// Invoke .NET method asynchronously
        /// </summary>
        DotNetInvokeAsync = 4
    }
}
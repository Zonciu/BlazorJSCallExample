using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace BlazorJSCallExample.Core
{
    public class JSCall
    {
        [JsonPropertyName("__jsCall")]
        [JsonProperty("__jsCall")]
        public JSCallType CallType { get; set; }

        [JsonPropertyName("__jsCallData")]
        [JsonProperty("__jsCallData")]
        public object Data { get; set; }

        #region Navice Call

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string NativeFunctionPath
        {
            get => CallType == JSCallType.NativeCall ? (string)Data : throw new InvalidCastException();
            set => Data = CallType == JSCallType.NativeCall ? value : throw new InvalidCastException();
        }

        public static JSCall Native(string functionPath)
        {
            return new JSCall
            {
                CallType = JSCallType.NativeCall,
                Data = functionPath
            };
        }

        #endregion

        #region DynamicFunction

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string DynamicFunction
        {
            get => CallType == JSCallType.DynamicFunction ? (string)Data : throw new InvalidCastException();
            set => Data = CallType == JSCallType.DynamicFunction ? value : throw new InvalidCastException();
        }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public object DotNetObjectRef
        {
            get => CallType == JSCallType.DotNetInvoke || CallType == JSCallType.DotNetInvokeAsync ? Data : throw new InvalidCastException();
            set => Data = CallType == JSCallType.DotNetInvoke || CallType == JSCallType.DotNetInvokeAsync ? value : throw new InvalidCastException();
        }

        public static JSCall Dynamic(string function)
        {
            return new JSCall
            {
                CallType = JSCallType.DynamicFunction,
                Data = function
            };
        }

        #endregion

        #region DotNet Call

        public static JSCall DotNet(Func<Task> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper(callback))
            };
            return res;
        }

        public static JSCall DotNet<T>(Func<T, Task> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, TR>(Func<T1, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, T2, TR>(Func<T1, T2, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, T2, T3, TR>(Func<T1, T2, T3, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, T2, T3, T4, T5, TR>(Func<T1, T2, T3, T4, T5, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, T5, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNet<T1, T2, T3, T4, T5, T6, TR>(Func<T1, T2, T3, T4, T5, T6, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvoke,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, T5, T6, TR>(callback))
            };
            return res;
        }

        #endregion DotNet Call

        #region DotNet Async Call

        public static JSCall DotNetAsync(Func<Task> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T>(Func<T, Task> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, TR>(Func<T1, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, T2, TR>(Func<T1, T2, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, T2, T3, TR>(Func<T1, T2, T3, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, T2, T3, T4, T5, TR>(Func<T1, T2, T3, T4, T5, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, T5, TR>(callback))
            };
            return res;
        }

        public static JSCall DotNetAsync<T1, T2, T3, T4, T5, T6, TR>(Func<T1, T2, T3, T4, T5, T6, Task<TR>> callback)
        {
            var res = new JSCall
            {
                CallType = JSCallType.DotNetInvokeAsync,
                Data = DotNetObjectReference.Create(new JSInteropActionWrapper<T1, T2, T3, T4, T5, T6, TR>(callback))
            };
            return res;
        }

        #endregion DotNet Async Call

        #region JSInteropActionWrapper

        private class JSInteropActionWrapper
        {
            private readonly Func<Task> _callback;

            internal JSInteropActionWrapper(Func<Task> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task Invoke()
            {
                await _callback.Invoke();
            }
        }

        private class JSInteropActionWrapper<T>
        {
            private readonly Func<T, Task> _callback;

            internal JSInteropActionWrapper(Func<T, Task> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task Invoke(T arg1)
            {
                await _callback.Invoke(arg1);
            }
        }

        private class JSInteropActionWrapper<T1, TR>
        {
            private readonly Func<T1, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1)
            {
                return await _callback.Invoke(arg1);
            }
        }

        private class JSInteropActionWrapper<T1, T2, TR>
        {
            private readonly Func<T1, T2, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, T2, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1, T2 arg2)
            {
                return await _callback.Invoke(arg1, arg2);
            }
        }

        private class JSInteropActionWrapper<T1, T2, T3, TR>
        {
            private readonly Func<T1, T2, T3, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, T2, T3, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1, T2 arg2, T3 arg3)
            {
                return await _callback.Invoke(arg1, arg2, arg3);
            }
        }

        private class JSInteropActionWrapper<T1, T2, T3, T4, TR>
        {
            private readonly Func<T1, T2, T3, T4, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, T2, T3, T4, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                return await _callback.Invoke(arg1, arg2, arg3, arg4);
            }
        }

        private class JSInteropActionWrapper<T1, T2, T3, T4, T5, TR>
        {
            private readonly Func<T1, T2, T3, T4, T5, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, T2, T3, T4, T5, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                return await _callback.Invoke(arg1, arg2, arg3, arg4, arg5);
            }
        }

        private class JSInteropActionWrapper<T1, T2, T3, T4, T5, T6, TR>
        {
            private readonly Func<T1, T2, T3, T4, T5, T6, Task<TR>> _callback;

            internal JSInteropActionWrapper(Func<T1, T2, T3, T4, T5, T6, Task<TR>> callback)
            {
                this._callback = callback;
            }

            [JSInvokable]
            public async Task<TR> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
                return await _callback.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        #endregion
    }
}

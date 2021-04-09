function setup() {
    const jsCallType = {
        // JS原生函数调用
        // Call native js function 
        NativeCall: 1,


        // 动态生成JS函数
        // Create function dynamically and call
        DynamicFunction: 2,


        // 同步调用.NET方法(只能在wasm模式使用)
        // Invoke .NET method synchronously (Can only be used in wasm mode)
        DotNetInvoke: 3,


        // 异步调用.NET方法
        // Invoke .NET method asynchronously
        DotNetInvokeAsync: 4
    }
    const demoInterop = {
        speak(text) {
            let msg = new SpeechSynthesisUtterance(text);
            msg.rate = 1.5
            window.speechSynthesis.speak(msg)
        }
    }

    const chartsContainer = {}

    const chartInterop = {
        create: (type, domRef, domId, option, otherOption) => {
            domRef.innerHTML = '';

            removeNullItem(option);
            deepObjectMerge(option, otherOption);
            try {
                const plot = new G2Plot[type](domRef, option);
                plot.__antb_callback = {}
                plot.render();
                chartsContainer[domId] = plot;
            } catch (err) {
                console.error(err, option);
            }
        },
        /** plot.destroy(); */
        destroy(domId) {
            if (chartsContainer[domId] === undefined) return;
            chartsContainer[domId].destroy();
            delete chartsContainer[domId];
        },
        /** plot.render(); */
        render(domId) {
            if (chartsContainer[domId] === undefined) return;
            chartsContainer[domId].render();
        },
        /** plot.update(options: Partial<PlotOptions>); */
        update(domId, option) {
            if (chartsContainer[domId] === undefined) return;
            chartsContainer[domId].update(option);
        },
        /** plot.changeData(data: object[] | number); */
        changeData(domId, data) {
            if (chartsContainer[domId] === undefined) return;
            chartsContainer[domId].changeData(data);
        },
        /** plot.changeSize(width: number, height: number); */
        changeSize(domId, width, height) {
            if (chartsContainer[domId] === undefined) return;
            chartsContainer[domId].changeSize(width, height)
        },
        /** plot.on(event: string, callback: Function); */
        setEvent(domId, event, dotnetHelper, func, funcId) {
            if (chartsContainer[domId] === undefined) return;
            const callback = ev => {
                let e = {};
                for (let attr in ev) {
                    if (typeof ev[attr] !== "function" && typeof ev[attr] !== "object") {
                        e[attr] = ev[attr];
                    }
                }
                dotnetHelper.invokeMethodAsync(func, e);
            }
            chartsContainer[domId].__antb_callback[funcId] = callback;
            chartsContainer[domId].chart.on(event, callback);
        },
        /** plot.once(event: string, callback: Function); */
        setEventOnce(domId, event, dotnetHelper, func, funcId) {
            if (chartsContainer[domId] === undefined) return;
            const callback = ev => {
                let e = {};
                for (let attr in ev) {
                    if (typeof ev[attr] !== "function" && typeof ev[attr] !== "object") {
                        e[attr] = ev[attr];
                    }
                }
                if (chartsContainer[domId].__antb_callback[funcId] !== undefined) {
                    delete chartsContainer[domId].__antb_callback[funcId]
                }
                dotnetHelper.invokeMethodAsync(func, e);
            };
            chartsContainer[domId].__antb_callback[funcId] = callback;
            chartsContainer[domId].chart.once(event, callback);
        },
        /** plot.off(event?: string, callback?: Function); */
        removeEvent(domId, event, funcId) {
            if (chartsContainer[domId] === undefined) return;
            const callback = chartsContainer[domId].__antb_callback[funcId]
            if (callback) {
                chartsContainer[domId].chart.off(event, callback);
            }
        },
        /** plot.setState(state?: 'active' | 'inactive' | 'selected', condition?: Function, status: boolean = true); */
        setState(domId, state, conditionFunc, status) {
            if (chartsContainer[domId] === undefined) return null;
            chartsContainer[domId].setState(state, conditionFunc, status)
        },
        getState(domId) {
            if (chartsContainer[domId] === undefined) return null;
            return chartsContainer[domId].getState()
        }
    }

    let initialized = false;

    function init() {
        if (initialized) {
            return;
        }
        console.log("setup g2plot interop");
        if (!window.hasOwnProperty("DotNet")) {
            throw new Error("DotNet not found, please invoke 'init' asynchronous in 'OnAfterRenderAsync(bool firstRender)' when 'firstRender' == true");
        }
        DotNet.attachReviver(function (key, value) {
                if (value && typeof value === "object" && value.hasOwnProperty("__jsCall") && Number.isInteger(value.__jsCall)) {
                    const callType = value.__jsCall;
                    switch (callType) {
                        case jsCallType.NativeCall: {
                            const functionPath = value.__jsCallData;
                            const func = getJsMember(functionPath.trim(), globalThis)
                            const callback = function () {
                                return func(...arguments);
                            }
                            callback.__jsCallData = value.__jsCallData;
                            callback.__jsCall = value.__jsCall;
                            return callback;
                        }
                        case jsCallType.DynamicFunction: {
                            const method = value.__jsCallData;
                            const funcStr = `"use strict";return ${method.trim()}`;
                            try {
                                const func = window.Function(funcStr)();
                                const callback = function () {
                                    return func(...arguments);
                                }
                                callback.__jsCallData = value.__jsCallData;
                                callback.__jsCall = value.__jsCall;
                                return callback;
                            } catch (e) {
                                console.error('create function failed', funcStr)
                                return undefined;
                            }
                        }
                        case jsCallType.DotNetInvoke: {
                            const netObjectRef = value.__jsCallData;
                            const callback = function () {
                                return netObjectRef.invokeMethod("Invoke", ...arguments);
                            };
                            callback.__jsCallData = value.__jsCallData;
                            callback.__jsCall = value.__jsCall;
                            return callback;
                        }
                        case jsCallType.DotNetInvokeAsync: {
                            const netObjectRef = value.__jsCallData;
                            const callback = function () {
                                return netObjectRef.invokeMethodAsync("Invoke", ...arguments);
                            };
                            callback.__jsCallData = value.__jsCallData;
                            callback.__jsCall = value.__jsCall;
                            return callback;
                        }
                        default: {
                            return value;
                        }
                    }
                } else {
                    return value;
                }
            }
        );
        initialized = true;
    }

    function getJsMember(path, base) {
        return path.split(".").reduce((s, c) => s[c], base)
    }

    function isEmptyObj(o) {
        for (let attr in o) return !1;
        return !0
    }

    function processArray(arr) {
        for (let i = arr.length - 1; i >= 0; i--) {
            if (arr[i] === null || arr[i] === undefined) arr.splice(i, 1);
            else if (typeof arr[i] === "object") removeNullItem(arr[i], arr, i);
        }
        return arr.length === 0
    }

    function proccessObject(o) {
        for (const attr in o) {
            if (o[attr] === null || o[attr] === undefined) delete o[attr];
            else if (typeof o[attr] === "object") {
                removeNullItem(o[attr]);
                if (isEmptyObj(o[attr])) delete o[attr];
            }
        }
    }

    function removeNullItem(o, arr, i) {
        let s = ({}).toString.call(o);
        if (s === "[object Array]") {
            if (processArray(o) === true) { //o也是数组，并且删除完子项，从所属数组中删除
                if (arr) arr.splice(i, 1);
            }
        } else if (s === "[object Object]") {
            proccessObject(o);
            if (arr && isEmptyObj(o)) arr.splice(i, 1);
        }
    }

    function deepObjectMerge(source, target) {
        for (const key in target) {
            if (source[key] && source[key].toString() === "[object Object]") {
                deepObjectMerge(source[key], target[key])
            } else {
                source[key] = target[key]
            }
        }
        return source;
    }

    window.demo = {
        interop: demoInterop,
        charts: {
            init: init,
            chartsContainer: chartsContainer,
            interop: chartInterop
        }
    }

}

setup();

const temp = document.createElement("script");
temp.src = "/demo.js";
document.body.appendChild(temp);
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorUtils.Interfaces.Invokers
{
    public static class JsInvoke
    {
        private static IJSRuntime _JSRuntime;
        private const string _NullExceptionMsg = "BlazorUtils.Interfaces: Please call JsInvoke.UseRuntime before using JsInvoke or any of its' dependencies.";

        public static void UseRuntime(IJSRuntime iJSRuntime, bool overrideRuntime = false)
        {
            if (!overrideRuntime && _JSRuntime != null)
            {
                Console.WriteLine("BlazorUtils.Interfaces: IJSRuntime has been set already.");
                return;
            }
            _JSRuntime = iJSRuntime;
        }

        public static T Invoke<T>(string funcName, params object[] parameters)
        {
            if (_JSRuntime == null)
            {
                Console.WriteLine(_NullExceptionMsg);
                return default;
            }
            return (_JSRuntime as IJSInProcessRuntime).Invoke<T>(
$"blazorUtils.core.funcs.{funcName}", parameters);
        }

        public static Task<T> InvokeAsync<T>(string funcName, params object[] parameters)
        {
            if (_JSRuntime == null)
            {
                Console.WriteLine(_NullExceptionMsg);
                return default;
            }
            return _JSRuntime.InvokeAsync<T>($"blazorUtils.core.funcs.{funcName}", parameters);
        }
    }
}

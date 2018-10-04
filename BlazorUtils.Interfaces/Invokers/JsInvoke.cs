using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorUtils.Interfaces.Invokers
{
    public static class JsInvoke
    {
        public static T Invoke<T>(string funcName, params object[] parameters) =>  (JSRuntime.Current as IJSInProcessRuntime).Invoke<T>(
            $"blazorUtils.core.funcs.{funcName}", parameters);

        public static Task<T> InvokeAsync<T>(string funcName, params object[] parameters) => JSRuntime.Current.InvokeAsync<T>($"blazorUtils.core.funcs.{funcName}", parameters);
    }
}

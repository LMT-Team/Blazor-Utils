using Microsoft.JSInterop;

namespace BlazorUtils.Interfaces.Invokers
{
    public static class JsInvoke
    {
        public static T Invoke<T>(string funcName, params object[] parameters) =>  (JSRuntime.Current as IJSInProcessRuntime).Invoke<T>(
            $"blazorUtils.core.funcs.{funcName}", parameters);
    }
}

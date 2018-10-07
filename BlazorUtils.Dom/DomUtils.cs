using BlazorUtils.Dom.Storages;
using BlazorUtils.Interfaces;
using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

// ReSharper disable InconsistentNaming
namespace BlazorUtils.Dom
{
    /// <summary>
    /// Dom Utilities box
    /// </summary>
    public static class DomUtils
    {
        /// <summary>
        /// Initialize DOM with a selector string.
        /// </summary>
        /// <param name="selector">DOM Selector string.</param>
        public static IDom _(string selector) => DomPool.GetDom(selector);

        /// <summary>
        /// Evaluate JavaScript code as string
        /// </summary>
        /// <param name="jsCode"></param>
        public static void Eval(string jsCode) => Invoke<object>("LMTDomEval", jsCode);

        /// <summary>
        /// Evaluate JavaScript code as string
        /// </summary>
        /// <param name="jsCode"></param>
        public static async Task EvalAsync(string jsCode) => await InvokeAsync<object>("LMTDomEval", jsCode);

        /// <summary>
        /// Evaluate JavaScript code as string
        /// </summary>
        /// <param name="jsCode"></param>
        public static T Eval<T>(string jsCode) => Invoke<T>("LMTDomEval", jsCode);

        /// <summary>
        /// Evaluate JavaScript code as string
        /// </summary>
        /// <param name="jsCode"></param>
        public static async Task<T> EvalAsync<T>(string jsCode) => await InvokeAsync<T>("LMTDomEval", jsCode);

        /// <summary>
        /// Inject behaviour attribute service to Blazor component
        /// </summary>
        public static void LMTBehaviours() => Invoke<object>("LMTBehavioursBoot");

        /// <summary>
        /// Inject behaviour attribute service to Blazor component
        /// </summary>
        public static async Task LMTBehavioursAsync() => await InvokeAsync<object>("LMTBehavioursBoot");

        /// <summary>
        /// Navigate to specific URL
        /// </summary>
        /// <param name="url"></param>
        public static void NavigateTo(string url) => Microsoft.AspNetCore.Blazor.Browser.Services.BrowserUriHelper.Instance.NavigateTo(url);
    }
}
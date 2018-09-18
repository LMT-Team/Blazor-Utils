using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

// ReSharper disable InconsistentNaming
namespace BlazorUtils.Dom
{
    /// <summary>
    /// Dom Utilities box
    /// </summary>
    public static class DomUtil
    {
        public static Dom _(string selector) => new Dom(selector);

        /// <summary>
        /// Evaluate JavaScript code as string
        /// </summary>
        /// <param name="jsCode"></param>
        public static void Eval(string jsCode) => Invoke<object>("LMTDomEval", jsCode);
        /// <summary>
        /// Inject behaviour attribute service to Blazor component
        /// </summary>
        public static void LMTBehaviours() => Invoke<object>("LMTBehavioursBoot");

        /// <summary>
        /// Navigate to specific URL
        /// </summary>
        /// <param name="url"></param>
        public static void NavigateTo(string url) => Microsoft.AspNetCore.Blazor.Browser.Services.BrowserUriHelper.Instance.NavigateTo(url);
    }
}

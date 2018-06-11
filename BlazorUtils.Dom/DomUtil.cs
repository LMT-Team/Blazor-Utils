using System;
using static Microsoft.AspNetCore.Blazor.Browser.Interop.RegisteredFunction;
namespace BlazorUtils.Dom
{
    public static class DomUtil
    {
        public static Dom _(string selector) => new Dom(selector);

        public static void Eval(string jsCode) => Invoke<object>("LMTDomEval", jsCode);
    }
}

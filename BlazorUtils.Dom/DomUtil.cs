using static Microsoft.AspNetCore.Blazor.Browser.Interop.RegisteredFunction;
// ReSharper disable InconsistentNaming
namespace BlazorUtils.Dom
{
    public static class DomUtil
    {
        public static Dom _(string selector) => new Dom(selector);

        public static void Eval(string jsCode) => Invoke<object>("LMTDomEval", jsCode);
        /// <summary>
        /// Inject behaviour attribute service to Blazor component
        /// </summary>
        public static void LMTBehaviours() => Invoke<object>("LMTBehavioursBoot");
    }
}

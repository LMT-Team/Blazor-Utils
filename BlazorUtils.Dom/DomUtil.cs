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
    }
}

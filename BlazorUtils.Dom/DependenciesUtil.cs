using static BlazorUtils.Dom.DomUtil;

namespace BlazorUtils.Dom
{
    /// <summary>
    /// Use internally. Should not be used in your project.
    /// </summary>
    public static class DependenciesUtil
    {
        /// <summary>
        /// Use internally. Should not be used in your project.
        /// </summary>
        public static void GetFeatherlight()
        {
            //Get Css and Js over CDN
            Eval("if(window.LMTCDNFeatherlightDone == undefined){let lmtCssNode3 = document.createElement(\"link\");lmtCssNode3.href = \"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.css\";lmtCssNode3.rel = \"stylesheet\";document.head.appendChild(lmtCssNode3);$.getScript(\"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.js\").done(() => {LMTCDNFeatherlightDone = true;});}");
        }
    }
}

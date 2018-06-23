using static BlazorUtils.Dom.DomUtil;

namespace BlazorUtils.Dom
{
    internal static class DependenciesUtil
    {
        internal static void GetFeatherlight()
        {
            //Get Css and Js over CDN
            Eval("if(window.LMTCDNFeatherlightDone == undefined){let lmtCssNode3 = document.createElement(\"link\");lmtCssNode3.href = \"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.css\";lmtCssNode3.rel = \"stylesheet\";document.head.appendChild(lmtCssNode3);$.getScript(\"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.js\").done(() => {LMTCDNFeatherlightDone = true;});}");
        }
    }
}

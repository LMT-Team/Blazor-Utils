using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dom
{
    /// <summary>
    /// Use internally. Should not be used in your project.
    /// </summary>
    public static class DependenciesUtils
    {
        /// <summary>
        /// Use internally. Should not be used in your project.
        /// </summary>
        public static async Task GetFeatherlight()
        {
            //Get Css and Js over CDN
            await EvalAsync("if(window.LMTCDNFeatherlightDone == undefined){let lmtCssNode3 = document.createElement(\"link\");lmtCssNode3.href = \"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.css\";lmtCssNode3.rel = \"stylesheet\";document.head.appendChild(lmtCssNode3);$.getScript(\"https://cdn.jsdelivr.net/gh/noelboss/featherlight/release/featherlight.min.js\").done(() => {LMTCDNFeatherlightDone = true;});}");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dom.UnitTest
{
    [TestClass]
    public class GlobalDataTest
    {
        [TestMethod]
        public void MainTest()
        {
            GlobalData.SetToStrict("Name");

            GlobalData["Name"] = "Rogger Tan";

            Assert.AreEqual(GlobalData["Name"], "Rogger Tan");
        }
    }
}

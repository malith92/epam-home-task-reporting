using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HomeTaskWebDriverAdvanced.Driver
{
    public class PageLoadWaitEnabledWebDriver : WebDriverDecorator
    {
        private WebDriverWait _webDriverWait;

        public PageLoadWaitEnabledWebDriver(IWebDriver webDriver) : base(webDriver)
        {
            _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            WaitUntilPageLoads();
        }
        private void WaitUntilPageLoads()
        {
            _webDriverWait.Until((IWebDriver driver) =>
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;

                string script = "return document.readyState";

                bool scriptOutput = javaScriptExecutor.ExecuteScript(script).Equals("complete");

                return scriptOutput;
            });
        }
    }
}

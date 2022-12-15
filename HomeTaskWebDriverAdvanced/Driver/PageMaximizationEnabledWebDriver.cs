using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.Driver
{
    public class PageMaximizationEnabledWebDriver : WebDriverDecorator
    {
        public PageMaximizationEnabledWebDriver(IWebDriver webDriver) : base(webDriver)
        {
            base.Driver.Manage().Window.Maximize();
        }
    }
}

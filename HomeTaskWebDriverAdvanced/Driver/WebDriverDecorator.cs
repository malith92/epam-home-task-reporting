using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HomeTaskWebDriverAdvanced.Driver
{
    public abstract class WebDriverDecorator : IWebDriver, IActionExecutor, IJavaScriptExecutor
    {
        private IWebDriver _driver;
        private IActionExecutor _actionExecutor;
        private IJavaScriptExecutor _javascriptExecutor;

        public WebDriverDecorator(Object driver)
        {
            this._driver = (IWebDriver) driver;
            this._actionExecutor = (IActionExecutor) driver;
            this._javascriptExecutor = (IJavaScriptExecutor) driver;
        }
        public IWebDriver Driver { get => _driver; set => _driver = value; }

        public string Url { get => _driver.Url; set => _driver.Url = value; }

        public string Title => _driver.Title;

        public string PageSource => _driver.PageSource;

        public string CurrentWindowHandle => _driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public bool IsActionExecutor => _actionExecutor.IsActionExecutor;

        public void Close()
        {
            _driver.Close();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return _javascriptExecutor.ExecuteAsyncScript(script, args);
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return _javascriptExecutor.ExecuteScript(script, args);
        }

        public object ExecuteScript(PinnedScript script, params object[] args)
        {
            return _javascriptExecutor.ExecuteScript(script, args);
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public void PerformActions(IList<ActionSequence> actionSequenceList)
        {
            _actionExecutor.PerformActions(actionSequenceList);
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void ResetInputState()
        {
            _actionExecutor.ResetInputState();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }
    }
}

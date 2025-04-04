﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using log4net;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public abstract class BasePageObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(BasePageObject));

        private IWebDriver _driver;
        private DefaultWait<IWebDriver> _defaultWait;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;

            // Initialize defaultWait
            _defaultWait = new DefaultWait<IWebDriver>(driver);
            _defaultWait.Timeout = TimeSpan.FromSeconds(5);
            _defaultWait.PollingInterval = TimeSpan.FromMilliseconds(5000);
            _defaultWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _defaultWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            _defaultWait.Message = "Element to be searched not found";

            log.Debug("Default wait initilized in BasePageObject class");
        }

        public IWebDriver Driver { get => _driver; set => _driver = value; }
        public DefaultWait<IWebDriver> DefaultWait { get => _defaultWait; set => _defaultWait = value; }

        public IWebElement HighLightElement(IWebElement element)
        {
            log.Debug("Element Highlighter method called");

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) _driver;

            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", element);

            return element;
        }

        public IWebElement JSExecutorClick(IWebElement element)
        {
            log.Debug("JSExecutor method called");

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

            jsExecutor.ExecuteScript("arguments[0].click();", element);

            return element;
        }
    }
}

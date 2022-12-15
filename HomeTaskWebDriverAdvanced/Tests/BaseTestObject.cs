using HomeTaskWebDriverAdvanced.Driver;
using HomeTaskWebDriverAdvanced.Utilities;
using HomeTaskWebDriverAdvanced.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using log4net;
using log4net.Config;

namespace HomeTaskWebDriverAdvanced.Tests
{
    public class BaseTestObject
    {
        protected ConfigurationFileReader configurationFileReader;
        protected IWebDriver webDriver;

        private readonly ILog log = LogManager.GetLogger(typeof(BaseTestObject));

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlConfigurator.Configure(new FileInfo("Resources\\log4net.config"));

            log.Info("log4net initialized");

            configurationFileReader = ConfigurationFileReader.GetInstance();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() { }

        [SetUp]
        public void SetUp()
        {
            webDriver = WebDriverFactory.CreateWebDriver(configurationFileReader.ConfigData!.Browser!);

            log.Info("Browser opened");

            webDriver = new PageLoadWaitEnabledWebDriver(webDriver);
            webDriver = new PageMaximizationEnabledWebDriver(webDriver);

            webDriver.Navigate().GoToUrl(configurationFileReader.ConfigData.AppUrl);

            log.Info("Navigated to Url");
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
            log.Info("Browser closed");
        }
    }
}

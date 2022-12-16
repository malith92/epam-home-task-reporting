using HomeTaskWebDriverAdvanced.Driver;
using HomeTaskWebDriverAdvanced.Utilities;
using HomeTaskWebDriverAdvanced.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using log4net;
using log4net.Config;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Security.Policy;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace HomeTaskWebDriverAdvanced.Tests
{
    public class BaseTestObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(BaseTestObject));

        protected ExtentReports _extent;
        protected ExtentTest _test;

        protected ConfigurationFileReader configurationFileReader;
        protected IWebDriver webDriver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            XmlConfigurator.Configure(new FileInfo("Resources\\log4net.config"));

            log.Info("log4net initialized");

            configurationFileReader = ConfigurationFileReader.GetInstance();

            string dir = TestContext.CurrentContext.TestDirectory + "\\";
            string fileName = this.GetType().ToString() + ".html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dir + fileName);

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extent.Flush();
        }
    }
}

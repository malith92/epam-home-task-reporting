using NUnit.Framework;
using HomeTaskWebDriverAdvanced.PageObjects;
using HomeTaskWebDriverAdvanced.Driver;
using log4net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace HomeTaskWebDriverAdvanced.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginPageTests : BaseTestObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(LoginPageTests));

        private LoginPage? _loginPage;
        private GoogleDriveHomePage? _emailAccountPage;

        [Test]
        public void LoginTest()
        {
            log.Info("Login Test Started");

            _loginPage = new LoginPage(webDriver);

            _emailAccountPage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _emailAccountPage.DriveLinkIsDisplayed();

            Assert.IsTrue(loginSuccessful);

            log.Info("Login Test Ended");
        }

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            ChromeOptions chromeOptions = new ChromeOptions();
            webDriver = new RemoteWebDriver(new Uri("http://localhost:4444"), chromeOptions);

            webDriver = new PageLoadWaitEnabledWebDriver(webDriver);
            webDriver = new PageMaximizationEnabledWebDriver(webDriver);

            log.Info("Browser opened");

            webDriver.Navigate().GoToUrl(configurationFileReader.ConfigData.AppUrl);

            log.Info("Navigated to Url");
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
            log.Info("Browser closed");

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }
    }
}
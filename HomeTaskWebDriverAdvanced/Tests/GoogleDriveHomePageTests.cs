using NUnit.Framework;
using HomeTaskWebDriverAdvanced.PageObjects;
using HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections;
using log4net;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace HomeTaskWebDriverAdvanced.Tests
{
    [Ignore("Ignoring to prioratize other tests")]
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GoogleDriveHomePageTests : BaseTestObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GoogleDriveHomePageTests));

        private LoginPage? _loginPage;
        private GoogleDriveHomePage? _driveHomePage;

        private MyDriveSection? _myDriveSection;

        [Test, Order(1)]
        public void TextFileMove()
        {
            log.Info("Text File Move Test Started");

            _loginPage = new LoginPage(webDriver);

            _driveHomePage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _driveHomePage.DriveLinkIsDisplayed();

            Assert.IsTrue(loginSuccessful);

            _myDriveSection = _driveHomePage.ClickMyDriveLink();
            _myDriveSection.MoveTextFile("TextFile_3.txt");

            bool fileMoveStatus = _myDriveSection.MovedFileStatusIsDisplayed();

            Assert.IsTrue(fileMoveStatus);

            log.Info("Text File Move Test Ended");
        }

        [Test, Order(2)]
        public void TextFileDelete()
        {
            log.Info("Text File Delete Test Started");

            _loginPage = new LoginPage(webDriver);

            _driveHomePage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _driveHomePage.DriveLinkIsDisplayed();

            Assert.IsTrue(loginSuccessful);

            _myDriveSection = _driveHomePage.ClickMyDriveLink();
            _myDriveSection.DeleteFile("TextFile_1.txt");

            bool deleteSuccessful = _myDriveSection.DeleteFileStatusIsDisplayed();

            Assert.IsTrue(deleteSuccessful);

            log.Info("Text File Delete Test Ended");
        }

        [SetUp]
        public void SetUp()
        {
            FirefoxOptions filrefoxOptions = new FirefoxOptions();

            filrefoxOptions.BrowserExecutableLocation = "C:\\Users\\UWANNMA\\AppData\\Local\\Mozilla Firefox\\firefox.exe";
            webDriver = new RemoteWebDriver(new Uri("http://localhost:4444"), filrefoxOptions);

            log.Info("Browser opened");

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
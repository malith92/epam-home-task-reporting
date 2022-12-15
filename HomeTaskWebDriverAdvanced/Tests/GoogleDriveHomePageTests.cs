using NUnit.Framework;
using HomeTaskWebDriverAdvanced.PageObjects;
using HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections;
using log4net;

namespace HomeTaskWebDriverAdvanced.Tests
{
    [Ignore("Ignoring to prioratize other tests")]
    [TestFixture]
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
            _loginPage = new LoginPage(webDriver);

            _driveHomePage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _driveHomePage.DriveLinkIsDisplayed();

            Assert.IsTrue(loginSuccessful);

            _myDriveSection = _driveHomePage.ClickMyDriveLink();
            _myDriveSection.DeleteFile("TextFile_1.txt");

            bool deleteSuccessful = _myDriveSection.DeleteFileStatusIsDisplayed();

            Assert.IsTrue(deleteSuccessful);
        }
    }
}
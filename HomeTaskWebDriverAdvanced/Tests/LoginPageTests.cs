using NUnit.Framework;
using HomeTaskWebDriverAdvanced.PageObjects;

namespace HomeTaskWebDriverAdvanced.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTestObject
    {
        private LoginPage? _loginPage;
        private GoogleDriveHomePage? _emailAccountPage;

        //[Ignore("Dissabled to prioratize other tests")]
        [Test]
        public void LoginTest()
        {
            _loginPage = new LoginPage(webDriver);

            _emailAccountPage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _emailAccountPage.DriveLinkIsDisplayed();

            Assert.IsTrue(loginSuccessful);
        }
    }
}
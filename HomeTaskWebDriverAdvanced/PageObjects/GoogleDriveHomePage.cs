using HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections;
using log4net;
using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class GoogleDriveHomePage : BasePageObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GoogleDriveHomePage));

        private readonly By _googleDriveLinkLocator = By.XPath("//a[@title='_Drive']/img");
        private readonly By _myDriveLinkLocator = By.XPath("//span[@aria-label='My Drive']/parent::div");
        private readonly By _accountAvatarLinkLocator = By.XPath("//a[contains(@aria-label,'Google Account: Test Account')]");

        public GoogleDriveHomePage(IWebDriver driver) : base(driver) { }

        public bool DriveLinkIsDisplayed()
        {
            bool driveLinkDisplayed;
            try
            {
                driveLinkDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_googleDriveLinkLocator)).Displayed;

                log.Info("Drive link displayed : " + driveLinkDisplayed);
            }
            catch (NoSuchElementException e)
            {
                Screenshot screenShot = ((ITakesScreenshot)base.Driver).GetScreenshot();
                screenShot.SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + "//DriveLink.png", ScreenshotImageFormat.Png);

                driveLinkDisplayed = false;
                log.Error(e);
            }

            return driveLinkDisplayed;
        }

        public MyDriveSection ClickMyDriveLink()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_myDriveLinkLocator)).Click();

            log.Info("MyDrive link clicked");

            return new MyDriveSection(base.Driver);
        }
    }
}

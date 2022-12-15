using HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections;
using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class GoogleDriveHomePage : BasePageObject
    {
        private readonly By _googleDriveLinkLocator = By.XPath("//a[@title='Drive']/img");
        private readonly By _myDriveLinkLocator = By.XPath("//span[@aria-label='My Drive']/parent::div");
        private readonly By _trashLinkLocator = By.XPath("//span[@aria-label='Trashed items']/parent");
        private readonly By _accountAvatarLinkLocator = By.XPath("//a[contains(@aria-label,'Google Account: Test Account')]");

        public GoogleDriveHomePage(IWebDriver driver) : base(driver) { }

        public bool DriveLinkIsDisplayed()
        {
            bool driveLinkDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_googleDriveLinkLocator)).Displayed;

            return driveLinkDisplayed;
        }

        public MyDriveSection ClickMyDriveLink()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_myDriveLinkLocator)).Click();
            return new MyDriveSection(base.Driver);
        }
    }
}

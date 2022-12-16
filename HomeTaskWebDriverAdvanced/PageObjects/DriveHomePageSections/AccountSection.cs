using log4net;
using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects.EmailAccountPageSections
{
    public class AccountSection : BasePageObject
    {

        private readonly ILog log = LogManager.GetLogger(typeof(AccountSection));

        private readonly By _signOutElementLocator = By.XPath("//div[text()='Sign out']");

        public AccountSection(IWebDriver driver) : base(driver) { }

        private void SwitchFrame()
        {
            base.Driver.SwitchTo().Frame("account");

            log.Info("Frame switched");
        }

        private void ClickSignOut()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_signOutElementLocator)).Click();

            log.Info("Sign out clicked");
        }

        public AccountChooserPage SignOut()
        {
            this.SwitchFrame();
            this.ClickSignOut();

            return new AccountChooserPage(base.Driver);
        }
    }
}

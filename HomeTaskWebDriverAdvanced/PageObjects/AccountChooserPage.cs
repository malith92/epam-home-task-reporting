using log4net;
using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class AccountChooserPage : BasePageObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(AccountChooserPage));

        private readonly By _chooseAccountElementLocator = By.PartialLinkText("Choose an account");
        public AccountChooserPage(IWebDriver driver) : base(driver) { }

        public bool ChooseAccountTextIsDisplayed()
        {
            bool chooseAccountTextIsDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_chooseAccountElementLocator)).Displayed;

            log.Info("Choose Account Text displayed : " + chooseAccountTextIsDisplayed);

            return chooseAccountTextIsDisplayed;
        }
    }
}

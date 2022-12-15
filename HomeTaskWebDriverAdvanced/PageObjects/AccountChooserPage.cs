using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class AccountChooserPage : BasePageObject
    {
        private readonly By _chooseAccountElementLocator = By.PartialLinkText("Choose an account");
        public AccountChooserPage(IWebDriver driver) : base(driver) { }

        public bool ChooseAccountTextIsDisplayed()
        {
            bool gmailLinkDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_chooseAccountElementLocator)).Displayed;

            return gmailLinkDisplayed;
        }
    }
}

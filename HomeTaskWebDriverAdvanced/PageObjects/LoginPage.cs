using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class LoginPage : BasePageObject
    {
        private readonly By _emailAddressFieldLocator = By.Id("identifierId");
        private readonly By _emailAddressNextButtonLocator = By.XPath("//div[@id='identifierNext']/div/button");
        private readonly By _passwordFieldLocator = By.Name("Passwd");
        private readonly By _passwordNextButtonLocator = By.XPath("//div[@id='passwordNext']/div/button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterUserName(string userName)
        {
            base.HighLightElement(base.DefaultWait.Until(_driver => _driver.FindElement(_emailAddressFieldLocator))).SendKeys(userName);
        }

        public void ClickNextAfterEnteringUserName()
        {
            base.JSExecutorClick(base.DefaultWait.Until(_driver => _driver.FindElement(_emailAddressNextButtonLocator)));
        }

        public void EnterPassword(string password)
        {
            base.HighLightElement(base.DefaultWait.Until(_driver => _driver.FindElement(_passwordFieldLocator))).SendKeys(password);
        }

        public void ClickNextAfterEnteringPassword()
        {
            base.JSExecutorClick(base.DefaultWait.Until(_driver => _driver.FindElement(_passwordNextButtonLocator)));
        }

        public GoogleDriveHomePage Login(string userName, string password)
        {
            this.EnterUserName(userName);
            this.ClickNextAfterEnteringUserName();
            this.EnterPassword(password);
            this.ClickNextAfterEnteringPassword();

            return new GoogleDriveHomePage(base.Driver);
        }
    }
}

using log4net;
using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects
{
    public class LoginPage : BasePageObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(LoginPage));

        private readonly By _emailAddressFieldLocator = By.Id("identifierId");
        private readonly By _emailAddressNextButtonLocator = By.XPath("//div[@id='identifierNext']/div/button");
        private readonly By _passwordFieldLocator = By.Name("Passwd");
        private readonly By _passwordNextButtonLocator = By.XPath("//div[@id='passwordNext']/div/button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterUserName(string userName)
        {
            base.HighLightElement(base.DefaultWait.Until(_driver => _driver.FindElement(_emailAddressFieldLocator))).SendKeys(userName);

            log.Info("User name entered");
        }

        public void ClickNextAfterEnteringUserName()
        {
            base.JSExecutorClick(base.DefaultWait.Until(_driver => _driver.FindElement(_emailAddressNextButtonLocator)));

            log.Info("Next button clicked after entering user name");
        }

        public void EnterPassword(string password)
        {
            base.HighLightElement(base.DefaultWait.Until(_driver => _driver.FindElement(_passwordFieldLocator))).SendKeys(password);

            log.Info("Password entered");
        }

        public void ClickNextAfterEnteringPassword()
        {
            base.JSExecutorClick(base.DefaultWait.Until(_driver => _driver.FindElement(_passwordNextButtonLocator)));

            log.Info("Next clicked after entering password");
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

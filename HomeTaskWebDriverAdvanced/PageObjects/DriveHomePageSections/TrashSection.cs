using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections
{
    public class TrashSection : BasePageObject
    {
        private readonly By _textFilelementLocator = By.XPath("//div[text()='TextFile_3.txt']");

        public TrashSection(IWebDriver driver) : base(driver) { }

    }
}

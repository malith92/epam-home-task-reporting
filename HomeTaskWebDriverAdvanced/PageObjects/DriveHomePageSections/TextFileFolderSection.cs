using OpenQA.Selenium;

namespace HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections
{
    public class TextFileFolderSection : BasePageObject
    {
        private readonly By _textFilelementLocator = By.XPath("//div[text()='TextFile_3.txt']");

        public TextFileFolderSection(IWebDriver driver) : base(driver) { }

        public bool MovedFileIsDisplayed()
        {
            bool movedFileIsDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_textFilelementLocator)).Displayed;

            return movedFileIsDisplayed;
        }
    }
}

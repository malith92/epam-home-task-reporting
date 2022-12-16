using HomeTaskWebDriverAdvanced.Tests;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HomeTaskWebDriverAdvanced.PageObjects.DriveHomePageSections
{
    public class MyDriveSection : BasePageObject
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GoogleDriveHomePageTests));

        private readonly By _textFilesFolderElementLocator = By.XPath("//div[@aria-label='TextFilesFolder']");
        private By _textFilelementLocator (string fileName) => By.XPath("//div[text()='"+ fileName + "' and @data-tooltip-unhoverable='true']/parent::div");

        private readonly By _undoSpanLocator = By.XPath("//span[@aria-label='Undo move item']");
        private readonly By _undoButtonLocator = By.XPath("//button[@data-target='undo']");

        public MyDriveSection(IWebDriver driver) : base(driver) { }

        public void MoveTextFile(string fileName)
        {
            Actions builder = new Actions(Driver);

            IWebElement textFilesFolder = base.DefaultWait.Until(_driver => _driver.FindElement(_textFilesFolderElementLocator));
            IWebElement textFile = base.DefaultWait.Until(_driver => _driver.FindElement(_textFilelementLocator(fileName)));

            builder.ClickAndHold(textFile).MoveToElement(textFilesFolder).Pause(TimeSpan.FromSeconds(1)).Release().Build().Perform();

            log.Info("Text file move action sequence performed");
        }

        public bool MovedFileStatusIsDisplayed()
        {
            bool movedFileStatusIsDisplayed;
            try
            {
                movedFileStatusIsDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_undoSpanLocator)).Displayed;

                log.Info("Moved File Status displayed : " + movedFileStatusIsDisplayed);
            }
            catch(NoSuchElementException e)
            {
                Screenshot screenShot = ((ITakesScreenshot)base.Driver).GetScreenshot();
                screenShot.SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + "//MoveFileStatusError.png", ScreenshotImageFormat.Png);

                movedFileStatusIsDisplayed = false;

                log.Error(e);
            }
            
            return movedFileStatusIsDisplayed;
        }

        public void DeleteFile(string fileName)
        {
            Actions builder = new Actions(Driver);

            IWebElement textFile = base.DefaultWait.Until(_driver => _driver.FindElement(_textFilelementLocator(fileName)));

            builder.Click(textFile).SendKeys(Keys.Delete).Build().Perform();

            log.Info("Text file delete action sequence performed");
        }

        public bool DeleteFileStatusIsDisplayed()
        {
            bool deleteFileStatusIsDisplayed;
            try
            {
                deleteFileStatusIsDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_undoButtonLocator)).Displayed;

                log.Info("File Delete Status displayed : " + deleteFileStatusIsDisplayed);
            }
            catch (NoSuchElementException e)
            {
                Screenshot screenShot = ((ITakesScreenshot)base.Driver).GetScreenshot();
                screenShot.SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + "//DeleteFileStatusError.png", ScreenshotImageFormat.Png);

                deleteFileStatusIsDisplayed = false;
                log.Error(e);
            }

            return deleteFileStatusIsDisplayed;
        }
    }
}

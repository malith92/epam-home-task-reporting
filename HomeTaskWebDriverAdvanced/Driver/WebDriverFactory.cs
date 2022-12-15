using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HomeTaskWebDriverAdvanced.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserType)
        {
            if(browserType != null)
            {
                switch (browserType.ToUpper())
                {
                    case "CHROME":
                        return new ChromeDriver();
                    case "FIREFOX":
                        return new FirefoxDriver();
                    case "EDGE":
                        return new EdgeDriver();
                    default:
                        throw new ArgumentException("Unsupported WebDriver : "+ browserType);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}

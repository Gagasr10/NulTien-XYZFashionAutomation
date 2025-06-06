using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace NulTien_XYZFashionAutomation.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            string browser = ConfigReader.Browser.ToLower();

            return browser switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
            };
        }
    }
}

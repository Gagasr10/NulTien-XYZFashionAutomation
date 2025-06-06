using NUnit.Framework ;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NulTien_XYZFashionAutomation.Utilities;
using System;
using System.Threading;

namespace NulTien_XYZFashionAutomation.Tests
{
    public class BaseTest
    {
        private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
        protected WebDriverWait;

        [SetUp]
        public void SetUp()
        {
            IWebDriver driver = DriverFactory.CreateDriver();
            threadDriver.Value = driver;

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigReader.ExplicitWait));
        }

        public IWebDriver GetDriver()
        {
            return threadDriver.Value;
        }

        [TearDown]
    public void TearDown()
{
    var driver = GetDriver();
    if (driver != null)
    {
        driver.Quit();
        threadDriver.Value = null;
    }
}


    }
}
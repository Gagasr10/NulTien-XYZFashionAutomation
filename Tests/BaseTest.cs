using NUnit.Framework;
using OpenQA.Selenium;
using NulTien_XYZFashionAutomation.Utilities;
using NulTien_XYZFashionAutomation.Pages;
using System.Threading;

namespace NulTien_XYZFashionAutomation.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class BaseTest
    {
        private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
        protected IWebDriver Driver => threadDriver.Value!;

        [SetUp]
        public void SetUp()
        {
            threadDriver.Value = DriverFactory.CreateDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            new BasePage(Driver).acceptCookiesFromShadowDOM();
            Thread.Sleep(2000);



            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginForm();
            loginPage.Login("wagas44949@adrewire.com", "JohnEng0");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            threadDriver.Dispose();
 
        }
    }
}

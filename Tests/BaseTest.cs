using NUnit.Framework;
using OpenQA.Selenium;
using NulTien_XYZFashionAutomation.Utilities;
using NulTien_XYZFashionAutomation.Pages;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;
using System.IO;




namespace NulTien_XYZFashionAutomation.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class BaseTest
    {
        private static ThreadLocal<IWebDriver>? threadDriver;
        protected IWebDriver Driver => threadDriver!.Value!;

        [SetUp]
        public void SetUp()
        {
            LoggerManager.Info("Starting test: " + TestContext.CurrentContext.Test.Name);

            threadDriver = new ThreadLocal<IWebDriver>();
            threadDriver.Value = DriverFactory.CreateDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            new BasePage(Driver).acceptCookiesFromShadowDOM();
            Thread.Sleep(2000);

            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginForm();
            loginPage.Login("wagas44949@adrewire.com", "JohnEng0");
        }

        public static IWebDriver GetDriver()
        {
            return threadDriver!.Value!;
        }

        [TearDown]
        public void TearDown()
        {
            LoggerManager.Info("Ending test: " + TestContext.CurrentContext.Test.Name);

            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

                    string screenshotsDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Screenshots"));
                    Directory.CreateDirectory(screenshotsDir);

                    string testName = TestContext.CurrentContext.Test.Name;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string screenshotPath = Path.Combine(screenshotsDir, $"{testName}_{timestamp}.png");

                    File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);
                    TestContext.AddTestAttachment(screenshotPath, "Screenshot on failure");
                }
                catch (Exception ex)
                {
                    LoggerManager.Error("Screenshot capture failed: " + ex.Message);
                }
            }

            Driver.Quit();
            threadDriver!.Dispose();
        }


    }
}

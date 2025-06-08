using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using NulTien_XYZFashionAutomation.Tests;
using OpenQA.Selenium.Support.Extensions;


namespace NulTien_XYZFashionAutomation.Utilities
{
    public class TestListener : ITestListener
    {
        public void TestFinished(ITestResult result)
        {
            if (result.ResultState.Status == TestStatus.Failed)
            {
                var driver = BaseTest.GetDriver();
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                string screenshotsDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Screenshots"));


                string screenshotPath = Path.Combine(screenshotsDir, $"{result.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);




                TestContext.AddTestAttachment(screenshotPath, "Screenshot on failure");
            }
        }


        public void TestStarted(ITest test) { }
        public void TestOutput(TestOutput output) { }
        public void SendMessage(TestMessage message) { }
    }
}

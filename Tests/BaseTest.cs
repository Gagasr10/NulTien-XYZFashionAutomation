using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NulTien_XYZFashionAutomation.Pages; // obavezno importuj LoginPage
using System.Threading;

public class BaseTest
{
    private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
    protected IWebDriver Driver => threadDriver.Value;

    [SetUp]
    public void SetUp()
    {
        threadDriver.Value = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl("https://rs.shop.xyz.fashion/"); // URL sajta

        //Calling login method 
        var loginPage = new LoginPage(Driver);
        loginPage.Login("kixiwa5736@cigidea.com", "JohnEng0 ");
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        threadDriver.Dispose();
    }
}

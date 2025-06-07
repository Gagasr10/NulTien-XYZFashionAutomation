using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class BasePage
    {
        // Protected members to be accessible by derived page classes
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;

        // Constructor initializes driver, wait and actions
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }

        public void acceptCookiesFromShadowDOM()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                js.ExecuteScript(@"
            const host = document.querySelector('#cmpwrapper');
            const shadow = host.shadowRoot;
            const btn = shadow.querySelector('#cmpwelcomebtnyes > a');
            if (btn) btn.click();
        ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Force-click on cookies failed: " + ex.Message);
            }
        }





    }
}


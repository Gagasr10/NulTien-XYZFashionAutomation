using OpenQA.Selenium;
using System.Collections.Generic;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class ProductPage : BasePage
    {
        private By muskarciLink => By.XPath("//a[text()='Muškarci']");
        private By odecaHoverElement => By.XPath("//span[text()='Odeća']");
        private By majiceLink => By.XPath("//span[text()='Majice']/ancestor::a");
        private By armaniMajicaImage => By.XPath("//img[contains(@class, 'athena-product-image-29929')]");
        private By cartIcon => By.CssSelector("a.action.showcart");


        public ProductPage(IWebDriver driver) : base(driver) { }

        public void NavigateToMajice()
        {
            // Click on "Muškarci"
            driver.FindElement(muskarciLink).Click();

            // Hover on "Odeća"
            var odeca = driver.FindElement(odecaHoverElement);
            actions.MoveToElement(odeca).Perform();

            // Click on "Majice"
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(majiceLink)).Click();
        }

        public void ClickOnArmaniMajica()
        {
            var majicaElement = driver.FindElement(armaniMajicaImage);

            // Scroll to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", majicaElement);

            // Wait until the element is clickable and then click it
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(armaniMajicaImage)).Click();
        }
        
        public void ClickOnCart()
        {
         wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(cartIcon)).Click();
        }


    }
}


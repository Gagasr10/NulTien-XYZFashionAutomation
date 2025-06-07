using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;


namespace NulTien_XYZFashionAutomation.Pages
{
    public class ProductPage : BasePage
    {
        private By muskarciLink => By.XPath("//a[text()='Muškarci']");
        private By odecaHoverElement => By.CssSelector("a[href*='/rs/muskarci/odeca/']");
        private By majiceLink => By.XPath("//span[text()='Majice']/ancestor::a");
        private By armaniMajicaImage => By.XPath("//img[contains(@class, 'athena-product-image-29929')]");

        private By sizeOptions => By.CssSelector("div.swatch-attribute.size div.swatch-option");
        private By addToCartButton => By.CssSelector("button[id='product-addtocart-button']");
        private By cartIcon => By.CssSelector("a.action.showcart");
        private By productName = By.CssSelector("h1.product-name");

        private By miniCartPanel => By.CssSelector("div.block.block-minicart");
        private By miniCartProductName => By.CssSelector("strong.product-item-name");
        private By proceedToCheckoutButton => By.CssSelector("button.checkout");
        private By productPrice => By.CssSelector("span.price");
        private By oldPrice => By.CssSelector("span.crossed.price del.crossed-price-configurable");
        private By discountedPrice => By.CssSelector("span.special-price span.price");



        public ProductPage(IWebDriver driver) : base(driver) { }

        public void navigateToMajice()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(muskarciLink)).Click();

            IWebElement odecaElement = wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("a[href*='/rs/muskarci/odeca/']")));
            actions.MoveToElement(odecaElement).Perform();

            By majiceLinkBy = By.CssSelector("a[href='https://xyzfashionstore.com/rs/muskarci/odeca/majice/']");
            IWebElement majiceLink = wait.Until(ExpectedConditions.ElementIsVisible(majiceLinkBy));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", majiceLink);
            actions.MoveToElement(majiceLink).Click().Perform();
        }

        public void clickOnArmaniMajica()
        {
            var majicaElement = driver.FindElement(armaniMajicaImage);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", majicaElement);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(armaniMajicaImage)).Click();
        }

        public void selectSize(string size)
        {
            var sizeElements = driver.FindElements(sizeOptions);
            foreach (var element in sizeElements)
            {
                if (element.Text.Trim().Equals(size, StringComparison.OrdinalIgnoreCase))
                {
                    element.Click();
                    break;
                }
            }
        }

        public void clickAddToCart()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addToCartButton)).Click();
        }

        public void clickOnCartIcon()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(cartIcon)).Click();
        }

        public bool isMiniCartVisible()
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(miniCartPanel)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string getMiniCartProductName()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(miniCartProductName)).Text.Trim();
        }

        public void clickOnProceedToCheckout()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(proceedToCheckoutButton)).Click();
        }

        public string getProductPrice()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(productPrice)).Text.Trim();
        }

        public string getOldPrice()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(oldPrice)).Text.Trim();
        }

        public string getDiscountedPrice()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(discountedPrice)).Text.Trim();
        }

        public string getProductName()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(productName)).Text;
        }

    }
}

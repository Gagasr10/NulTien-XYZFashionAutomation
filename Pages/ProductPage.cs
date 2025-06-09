using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;
using NulTien_XYZFashionAutomation.Utilities;

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
        private By miniCartButton = By.CssSelector("a.action.showcart");
        private By productName = By.CssSelector("h1.product-name");
        private By cartIcon = By.CssSelector("a.action.showcart");
        private By miniCartContent = By.CssSelector("div.block.block-minicart");
        private By proceedToCheckoutButton => By.CssSelector("button.checkout");
        private By productPrice => By.CssSelector("span.price");
        private By oldPrice => By.CssSelector("span.crossed.price del.crossed-price-configurable");
        private By discountedPrice => By.CssSelector("span.special-price span.price");
        private By versaceMajica = By.XPath("//img[@class='product-image-photo img-thumbnail athena-product-image-29844']");
        private By miniCartCounter = By.CssSelector("span.counter-number");
        private By miniCartProductName => By.CssSelector("strong.product-item-name a");
        private By productNameInMiniCart => By.CssSelector("strong.product-item-name a");
        private By removeIcon => By.CssSelector("a.action.delete");
        private By confirmRemoveButton => By.CssSelector("button.action-accept");
        private By emptyCartMessage => By.CssSelector("strong.subtitle.empty");
        private By quantityInput => By.CssSelector("input.item-qty.cart-item-qty");
        private By totalPrice => By.CssSelector("span.price-wrapper > span.price");
        private By updateQuantityButton => By.CssSelector("button.update-cart-item");
        private By hamburgerMenu => By.XPath("//img[@alt='Menu']");
        private By muskarciLinkMobile => By.XPath("//a[@id='ui-id-4']//span[text()='Muškarci']");
        private By odecaLinkMobile => By.XPath("//a[contains(@href, '/odeca/') and span[text()='Odeća']]");
        private By majiceLinkMobile => By.XPath("//a[contains(@href, '/odeca/majice/') and span[text()='Majice']]");
        private By filterColorButton => By.XPath("//div[@data-role='title' and text()='Boja']");
        private By tegetColorOption => By.XPath("//div[@option-label='Teget']");
        private By productImageAlts => By.XPath("//img[contains(@class, 'product-image-photo')]");

        public ProductPage(IWebDriver driver) : base(driver) { }

        public void navigateToMajice()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(muskarciLink)).Click();
            IWebElement odecaElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='/rs/muskarci/odeca/']")));
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
            wait.Until(ExpectedConditions.ElementToBeClickable(armaniMajicaImage)).Click();
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
            wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton)).Click();
        }

        public void clickOnCartIcon()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cartIcon)).Click();
        }

        public bool IsMiniCartVisible()
        {
            try
            {
                return wait.Until(driver => driver.FindElement(miniCartContent).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string getMiniCartProductName()
        {
            try
            {
                return wait.Until(driver =>
                {
                    var element = driver.FindElement(miniCartProductName);
                    var text = element.Text.Trim();
                    return !string.IsNullOrEmpty(text) ? text : null;
                });
            }
            catch
            {
                return "";
            }
        }

        public void clickOnProceedToCheckout()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(proceedToCheckoutButton)).Click();
        }

        public string getProductPrice()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(productPrice)).Text.Trim();
        }

        public string getOldPrice()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(oldPrice)).Text.Trim();
        }

        public string getDiscountedPrice()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(discountedPrice)).Text.Trim();
        }

        public string getProductName()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(productName)).Text;
        }

        public IWebElement getVersaceMajica()
        {
            return wait.Until(driver =>
            {
                var element = driver.FindElement(versaceMajica);
                return element.Displayed ? element : null;
            });
        }

        public void clickOnVersaceMajica()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
            wait.Until(ExpectedConditions.ElementIsVisible(versaceMajica));
            IWebElement versaceMajicaElement = driver.FindElement(versaceMajica);
            actions.MoveToElement(versaceMajicaElement).Click().Perform();
        }

        public string GetMiniCartItemCount()
        {
            return driver.FindElement(miniCartCounter).Text;
        }

        public void removeProductFromMiniCart()
        {
            var productElement = wait.Until(driver => driver.FindElement(productNameInMiniCart));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", productElement);
            var removeBtn = wait.Until(driver => driver.FindElement(removeIcon));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", removeBtn);
            var confirmBtn = wait.Until(driver => driver.FindElement(confirmRemoveButton));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", confirmBtn);
        }

        public string GetEmptyCartMessage()
        {
            return wait.Until(driver => driver.FindElement(emptyCartMessage)).Text.Trim();
        }

        public void changeQuantityInMiniCart(string quantity)
        {
            var qtyInput = wait.Until(ExpectedConditions.ElementIsVisible(quantityInput));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", qtyInput);
            qtyInput.Click();
            qtyInput.SendKeys(Keys.Control + "a");
            qtyInput.SendKeys(Keys.Backspace);
            qtyInput.SendKeys(quantity);
        }

        public string getTotalPriceFromMiniCart()
        {
            return wait.Until(driver => driver.FindElement(totalPrice)).Text.Trim();
        }

        public void clickUpdateCartButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(updateQuantityButton)).Click();
        }

        public void ClickFilterColor()
        {
            LoggerManager.Info("Clicking on filter 'Boja'.");

            var colorFilter = wait.Until(driver =>
            {
                var element = driver.FindElement(filterColorButton);
                return (element.Displayed && element.Enabled) ? element : null;
            });

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", colorFilter);

            Thread.Sleep(500);

            colorFilter.Click();
        }

        public void SelectTegetColor()
        {
            LoggerManager.Info("Selecting 'Teget' color.");
            var tegetColor = wait.Until(driver =>
            {
                var element = driver.FindElement(tegetColorOption);
                return element.Displayed && element.Enabled ? element : null;
            });

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", tegetColor);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tegetColor);
        }


        public List<string> GetAllProductAlts()
        {
            LoggerManager.Info("Collecting all visible product image alt texts.");
            var images = wait.Until(driver => driver.FindElements(productImageAlts));
            return images.Select(img => img.GetAttribute("alt")).ToList();
        }

    

        public void WaitForFilteredProducts()
        {
            LoggerManager.Info("Waiting for product grid to refresh after filter.");

            wait.Until(driver =>
            {
                var images = driver.FindElements(productImageAlts);
                return images.Count > 1 && images.Any(img =>
                {
                    try
                    {
                        return img.Displayed && !string.IsNullOrEmpty(img.GetAttribute("alt"));
                    }
                    catch { return false; }
                });
            });

            Thread.Sleep(1500); // slight buffer to stabilize the view
        }



    }
}

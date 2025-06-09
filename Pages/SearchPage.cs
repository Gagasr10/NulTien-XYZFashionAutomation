using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class SearchPage : BasePage
    {
        private By searchIcon = By.CssSelector("button.action-search");
        private By searchInput = By.CssSelector("input#search");
        private By noResultsMessage = By.CssSelector("div.message.info.empty > div");
        private By productTitle = By.CssSelector("h1.product-name");
        private By searchInputMobile => By.Id("search");
        private By searchButtonMobile => By.CssSelector("button.action-search");

        public SearchPage(IWebDriver driver) : base(driver) { }

        public void ClickSearchIcon()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIcon)).Click();
        }

        public void EnterSearchTerm(string term)
        {
            var input = wait.Until(ExpectedConditions.ElementIsVisible(searchInput));
            input.Clear();
            input.SendKeys(term);
        }

        public void PressEnterInSearch()
        {
            var input = driver.FindElement(searchInput);
            input.SendKeys(Keys.Enter);
        }

        public string GetNoResultsMessage()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(noResultsMessage)).Text.Trim();
        }

        public string GetProductTitle()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(productTitle)).Text.Trim();
        }
            
        public bool IsProductVisibleByName(string productName)
        {
            try
            {
                var product = wait.Until(driver => driver.FindElement(By.XPath($"//a[contains(text(),'{productName}')]")));
                return product.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsExpectedProductVisible(string expectedTitle)
        {
            try
            {
                var productElement = wait.Until(driver =>
                {
                    var el = driver.FindElement(By.CssSelector("span.athena-name-sec-product"));
                    return el.Displayed ? el : null;
                });

                string actualTitle = productElement.GetAttribute("title");
                return actualTitle.Equals(expectedTitle, StringComparison.OrdinalIgnoreCase);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }




    }
}

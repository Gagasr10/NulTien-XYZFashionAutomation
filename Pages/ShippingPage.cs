using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NulTien_XYZFashionAutomation.Utilities;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class ShippingPage : BasePage
    {
        private By addressField => By.Name("street[0]");
        private By cityField => By.Name("city");
        private By postalCodeField => By.Name("postcode");
        private By phoneNumberField => By.Name("telephone");
        private By nextButton => By.CssSelector("button[data-role='opc-continue']");

        private readonly By addressErrorMessage = By.XPath("//input[@name='street[0]']/following::div[contains(@class,'field-error')][1]/span");
        private readonly By cityErrorMessage = By.XPath("//input[@name='city']/following::div[contains(@class,'field-error')][1]/span");
        private readonly By postalCodeErrorMessage = By.XPath("//input[@name='postcode']/following::div[contains(@class,'field-error')][1]/span");
        private readonly By phoneErrorMessage = By.XPath("//input[@name='telephone']/following::div[contains(@class,'field-error')][1]/span");

        private readonly By postalCodeCityMismatchErrorMessage =
            By.XPath("//div[contains(@class,'field-error')]//span[contains(text(),'Poštanski broj i naziv grada se ne podudaraju.')]");

        public ShippingPage(IWebDriver driver) : base(driver) { }

        public void EnterAddress(string address)
        {
            LoggerManager.Info("Entering address.");
            var field = wait.Until(ExpectedConditions.ElementIsVisible(addressField));
            field.Clear();
            field.SendKeys(address);
        }

        public void EnterCity(string city)
        {
            LoggerManager.Info("Entering city.");
            var field = wait.Until(ExpectedConditions.ElementIsVisible(cityField));
            field.Clear();
            field.SendKeys(city);
        }

        public void EnterPostalCode(string postalCode)
        {
            LoggerManager.Info("Entering postal code.");
            var field = wait.Until(ExpectedConditions.ElementIsVisible(postalCodeField));
            field.Clear();
            field.SendKeys(postalCode);
        }

        public void EnterPhoneNumber(string phone)
        {
            LoggerManager.Info("Entering phone number.");
            var field = wait.Until(ExpectedConditions.ElementIsVisible(phoneNumberField));
            field.Clear();
            field.SendKeys(phone);
        }

        public void ClickNextButton()
        {
            LoggerManager.Info("Scrolling to 'Sledeće' button.");
            ScrollToElement(nextButton);
            LoggerManager.Info("Clicking 'Sledeće' button.");
            wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }

        public bool IsNextButtonEnabled()
        {
            LoggerManager.Info("Checking if 'Sledeće' button is enabled.");
            return driver.FindElement(nextButton).Enabled;
        }

        public bool IsAddressErrorMessageDisplayed()
        {
            LoggerManager.Info("Checking if address field error message is displayed.");
            try
            {
                ScrollToElement(addressErrorMessage);
                return wait.Until(ExpectedConditions.ElementIsVisible(addressErrorMessage)).Displayed;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("Exception while checking address error message: " + ex.Message);
                return false;
            }
        }

        public bool IsCityErrorMessageDisplayed()
        {
            LoggerManager.Info("Checking if city field error message is displayed.");
            try
            {
                ScrollToElement(cityErrorMessage);
                return wait.Until(ExpectedConditions.ElementIsVisible(cityErrorMessage)).Displayed;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("Exception while checking city error message: " + ex.Message);
                return false;
            }
        }

        public bool IsPhoneErrorMessageDisplayed()
        {
            LoggerManager.Info("Checking if phone field error message is displayed.");
            try
            {
                ScrollToElement(phoneErrorMessage);
                return wait.Until(ExpectedConditions.ElementIsVisible(phoneErrorMessage)).Displayed;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("Exception while checking phone error message: " + ex.Message);
                return false;
            }
        }

        public void WaitUntilShippingFormIsReady()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(addressField));
        }

        public string GetAddressErrorMessage() =>
            wait.Until(ExpectedConditions.ElementIsVisible(addressErrorMessage)).Text;

        public string GetCityErrorMessage() =>
            wait.Until(ExpectedConditions.ElementIsVisible(cityErrorMessage)).Text;

        public string GetPostalCodeErrorMessage() =>
            wait.Until(ExpectedConditions.ElementIsVisible(postalCodeErrorMessage)).Text;

        public string GetPhoneErrorMessage() =>
            wait.Until(ExpectedConditions.ElementIsVisible(phoneErrorMessage)).Text;

        public bool IsPostalCodeErrorMessageDisplayed()
        {
            LoggerManager.Info("Checking if postal code error is displayed.");
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(postalCodeErrorMessage)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsPostalCodeCityMismatchMessageDisplayed()
        {
            try
            {
                LoggerManager.Info("Checking if postal code/city mismatch error message is displayed.");
                var element = wait.Until(ExpectedConditions.ElementIsVisible(postalCodeCityMismatchErrorMessage));
                return element.Displayed;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("Mismatch error not shown: " + ex.Message);
                return false;
            }
        }

        public void WaitForErrorMessagesToAppear()
        {
            LoggerManager.Info("Waiting for any error message to appear on the shipping form.");
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//div[contains(@class,'field-error')]//span[contains(text(),'Ovo je obavezno polje.')]")));
            }
            catch (WebDriverTimeoutException ex)
            {
                LoggerManager.Error("Error messages did not appear in time: " + ex.Message);
                throw;
            }
        }
    }
}

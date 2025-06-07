using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private By emailInputLocator => By.Id("email");
        private By passwordInputLocator => By.CssSelector("input[placeholder='Lozinka']");
        private By loginButtonLocator => By.Id("send2");
        private By guestDropdownButton => By.CssSelector("button.dropdown-toggle.guest");
        private By prijavaLink => By.XPath("//a[contains(text(),'Prijava')]");

        private IWebElement EmailInput => driver.FindElement(emailInputLocator);
        private IWebElement PasswordInput => driver.FindElement(passwordInputLocator);
        private IWebElement LoginButton => driver.FindElement(loginButtonLocator);

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(string username, string password)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emailInputLocator));
            EmailInput.Clear();
            EmailInput.SendKeys(username);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", PasswordInput);
    
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
        }

        public void OpenLoginForm()
        {
            var hoverElement = driver.FindElement(guestDropdownButton);
            actions.MoveToElement(hoverElement).Perform();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(prijavaLink)).Click();
        }
    }
}

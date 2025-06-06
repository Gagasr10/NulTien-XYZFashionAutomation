using OpenQA.Selenium;

namespace NulTien_XYZFashionAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        // By lokatori – jasno odvajaš lokaciju elementa
        private By emailInputLocator => By.Id("email");
        private By passwordInputLocator => By.CssSelector("input[placeholder='Lozinka']");
        private By loginButtonLocator => By.Id("send2");

      // IWebElement getters – make the method cleaner

        private IWebElement EmailInput => driver.FindElement(emailInputLocator);
        private IWebElement PasswordInput => driver.FindElement(passwordInputLocator);
        private IWebElement LoginButton => driver.FindElement(loginButtonLocator);

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Main login method
        public void Login(string username, string password)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(username);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
        }
    }
}

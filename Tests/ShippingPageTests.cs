using NUnit.Framework;
using NulTien_XYZFashionAutomation.Pages;
using NulTien_XYZFashionAutomation.Utilities;

namespace NulTien_XYZFashionAutomation.Tests
{
     [TestFixture]
    // [Parallelizable(ParallelScope.All)]
    public class ShippingPageTests : BaseTest
    {

        public void TC14_ShippingForm_RequiredFieldsValidation()
        {
            try
            {
                var loginPage = new LoginPage(Driver);
                loginPage.OpenLoginForm();
                loginPage.Login("wagas44949@adrewire.com", "JohnEng0");

                var productPage = new ProductPage(Driver);
                LoggerManager.Info("Navigating to 'Majice' section.");
                productPage.navigateToMajice();
                productPage.clickOnArmaniMajica();
                productPage.selectSize("L");
                productPage.clickAddToCart();
                productPage.clickOnCartIcon();
                productPage.clickOnProceedToCheckout();

                var shippingPage = new ShippingPage(Driver);

                LoggerManager.Info("Waiting for shipping form to be ready.");
                shippingPage.WaitUntilShippingFormIsReady();

                shippingPage.ClickNextButton();
                shippingPage.WaitForErrorMessagesToAppear();

                LoggerManager.Info("Verifying that required field error messages are displayed.");

                Assert.That(shippingPage.IsAddressErrorMessageDisplayed(), Is.True, "Address error message not displayed.");
                Assert.That(shippingPage.IsCityErrorMessageDisplayed(), Is.True, "City error message not displayed.");
                Assert.That(shippingPage.IsPhoneErrorMessageDisplayed(), Is.True, "Phone error message not displayed.");
                // Assert.That(shippingPage.IsPostalCodeErrorMessageDisplayed(), Is.True, "Postal code + city mismatch message not displayed.");

                LoggerManager.Info("TC14_ShippingForm_RequiredFieldsValidation passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC14_ShippingForm_RequiredFieldsValidation failed: " + ex.Message);
                throw;
            }
            finally
            {
                LoggerManager.Info("Ending test: TC14_ShippingForm_RequiredFieldsValidation");
            }
        }

       


        [Test]
        public void TC15_PostalCodeCityMismatch_ShowsErrorMessage()
        {
            try
            {
                LoggerManager.Info("Starting test: TC15_PostalCodeCityMismatch_ShowsErrorMessage");

                var loginPage = new LoginPage(Driver);
                loginPage.OpenLoginForm();
                loginPage.Login("wagas44949@adrewire.com", "JohnEng0");

                var productPage = new ProductPage(Driver);
                LoggerManager.Info("Navigating to 'Majice' section.");
                productPage.navigateToMajice();
                productPage.clickOnArmaniMajica();
                productPage.selectSize("L");
                productPage.clickAddToCart();
                productPage.clickOnCartIcon();
                productPage.clickOnProceedToCheckout();

                var shippingPage = new ShippingPage(Driver);
                LoggerManager.Info("Waiting for shipping form to be ready.");
                shippingPage.WaitUntilShippingFormIsReady();

                LoggerManager.Info("Entering mismatched city and postal code.");
                shippingPage.EnterCity("Beograd");
                shippingPage.EnterPostalCode("21000"); // Novi Sad ZIP, but city is Beograd

                LoggerManager.Info("Clicking next to trigger error validation.");
                shippingPage.ClickNextButton();

                LoggerManager.Info("Verifying that mismatch error is displayed.");
                Assert.That(shippingPage.IsPostalCodeCityMismatchMessageDisplayed(), Is.True,
                    "Mismatch error message not displayed when postal code and city do not match.");

                LoggerManager.Info("TC15_PostalCodeCityMismatch_ShowsErrorMessage passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC15_PostalCodeCityMismatch_ShowsErrorMessage failed: " + ex.Message);
                throw;
            }
            finally
            {
                LoggerManager.Info("Ending test: TC15_PostalCodeCityMismatch_ShowsErrorMessage");
            }
        }

        [Test]
        public void TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment()
        {
            try
            {
                LoggerManager.Info("Starting test: TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment");

                var loginPage = new LoginPage(Driver);
                loginPage.OpenLoginForm();
                loginPage.Login("wagas44949@adrewire.com", "JohnEng0");

                var productPage = new ProductPage(Driver);
                LoggerManager.Info("Navigating to 'Majice' section.");
                productPage.navigateToMajice();
                productPage.clickOnArmaniMajica();
                productPage.selectSize("L");
                productPage.clickAddToCart();
                productPage.clickOnCartIcon();
                productPage.clickOnProceedToCheckout();

                var shippingPage = new ShippingPage(Driver);
                LoggerManager.Info("Waiting for shipping form to load.");
                shippingPage.WaitUntilShippingFormIsReady();

                LoggerManager.Info("Entering invalid street for valid city/postal code.");
                shippingPage.EnterAddress("Bulevar Milutina Milankovica 7"); // does not exist in Ruma
                shippingPage.EnterCity("Ruma");
                shippingPage.EnterPostalCode("22400");
                shippingPage.EnterPhoneNumber("+38163500700");

                LoggerManager.Info("Clicking 'Sledeće' button to proceed.");
                shippingPage.ClickNextButton();

                Thread.Sleep(2000);
                string currentUrl = Driver.Url;

                LoggerManager.Info("Verifying that user is not redirected to payment page.");
                Assert.That(currentUrl.Contains("checkout/#payment"), Is.False,
                    "User was incorrectly redirected to the payment page despite invalid address.");

                LoggerManager.Info("TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment failed: " + ex.Message);
                throw;
            }
            finally
            {
                LoggerManager.Info("Ending test: TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment");
            }
        }





    }
}

using NUnit.Framework;
using NulTien_XYZFashionAutomation.Pages;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using NulTien_XYZFashionAutomation.Utilities;
using SeleniumExtras.WaitHelpers;



namespace NulTien_XYZFashionAutomation.Tests
{

    public class ProductPageTests : BaseTest
    {
        private ProductPage productPage = null!;


        [SetUp]
        public new void SetUp()
        {
            productPage = new ProductPage(Driver);
        }

        // [Test]
        // public void TC01_VerifyProductPageLoad()
        // {

        //     productPage.navigateToMajice();
        //     LoggerManager.Info("Navigated to 'Majice' section");

        //     productPage.clickOnArmaniMajica();
        //     LoggerManager.Info("Clicked on Armani majica");

        //     string expectedProductName = "Armani Exchange - Crvena muška majica";
        //     string actualProductName = productPage.getProductName();
        //     LoggerManager.Info($"Fetched product name: '{actualProductName}'");

        //     Assert.That(actualProductName, Is.EqualTo(expectedProductName), "Displayed product name does not match expected.");

        // }

        // [Test]
        // public void TC02_ProductLoadTimeUnder3Seconds()
        // {
        //     try
        //     {
        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage!.navigateToMajice();

        //         LoggerManager.Info("Starting stopwatch before clicking on Armani product.");
        //         var stopwatch = Stopwatch.StartNew();

        //         productPage.clickOnArmaniMajica();

        //         stopwatch.Stop();
        //         double loadTime = stopwatch.Elapsed.TotalSeconds;

        //         LoggerManager.Info($"Product page loaded in {loadTime:F2} seconds.");

        //         Assert.That(loadTime, Is.LessThanOrEqualTo(3),
        //             $"Product page took too long to load: {loadTime:F2} seconds.");

        //         LoggerManager.Info("TC02_ProductLoadTimeUnder3Seconds passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC02_ProductLoadTimeUnder3Seconds failed: " + ex.Message);
        //         throw;
        //     }
        // }




        //    [Test]
        //     public void TC03_CorrectPriceIsDisplayed()
        //     {
        //         try
        //         {
        //             LoggerManager.Info("Navigating to 'Majice' section.");
        //             productPage.navigateToMajice();

        //             LoggerManager.Info("Clicking on 'Armani Majica'.");
        //             productPage.clickOnArmaniMajica();

        //             LoggerManager.Info("Retrieving actual product price.");
        //             string actualPrice = productPage.getProductPrice();
        //             string expectedPrice = "5.390,00 RSD";

        //             LoggerManager.Info($"Actual price: {actualPrice}, Expected price: {expectedPrice}");

        //             Assert.That(actualPrice, Is.EqualTo(expectedPrice), "The displayed product price is incorrect.");

        //             LoggerManager.Info("TC03_CorrectPriceIsDisplayed passed.");
        //         }
        //         catch (Exception ex)
        //         {
        //             LoggerManager.Error("TC03_CorrectPriceIsDisplayed failed: " + ex.Message);
        //             throw;
        //         }
        //     }


        // [Test]
        // public void TC04_VerifyDiscountDisplayedCorrectly()
        // {
        //     try
        //     {
        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         var productPage = new ProductPage(Driver);
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Versace Majica'.");
        //         productPage.clickOnVersaceMajica();

        //         LoggerManager.Info("Retrieving old and discounted prices.");
        //         string oldPriceText = productPage.getOldPrice();
        //         string newPriceText = productPage.getDiscountedPrice();

        //         LoggerManager.Debug("Old price text: " + oldPriceText);
        //         LoggerManager.Debug("New price text: " + newPriceText);

        //         decimal oldPrice = decimal.Parse(oldPriceText.Replace(".", "").Replace(",", ".").Replace(" RSD", ""));
        //         decimal newPrice = decimal.Parse(newPriceText.Replace(".", "").Replace(",", ".").Replace(" RSD", ""));

        //         decimal discountPercent = Math.Round((1 - (newPrice / oldPrice)) * 100);
        //         LoggerManager.Info($"Calculated discount: {discountPercent}%");

        //         Assert.That((int)discountPercent, Is.EqualTo(15), "Discount percentage is not correctly calculated.");
        //         LoggerManager.Info("TC04_VerifyDiscountDisplayedCorrectly passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC04_VerifyDiscountDisplayedCorrectly failed: " + ex.Message);
        //         throw;
        //     }
        // }


        // [Test]
        // public void TC05_CannotAddProductWithoutSelectingSize()
        // {
        //     try
        //     {
        //         var productPage = new ProductPage(Driver);

        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Armani Majica'.");
        //         productPage.clickOnArmaniMajica();

        //         LoggerManager.Info("Attempting to add product to cart without selecting size.");
        //         productPage.clickAddToCart();

        //         bool isInCart = productPage.IsMiniCartVisible();
        //         LoggerManager.Info("Mini cart visibility after attempt: " + isInCart);

        //         Assert.That(isInCart, Is.False, "Product was added to the cart without selecting a size.");

        //         LoggerManager.Info("TC05_CannotAddProductWithoutSelectingSize passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC05_CannotAddProductWithoutSelectingSize failed: " + ex.Message);
        //         throw;
        //     }
        // }

        // [Test]
        // public void TC06_AddProductWithSize_Success()
        // {
        //     try
        //     {
        //         var productPage = new ProductPage(Driver);

        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Armani Majica'.");
        //         productPage.clickOnArmaniMajica();

        //         LoggerManager.Info("Selecting size 'L'.");
        //         productPage.selectSize("L");

        //         LoggerManager.Info("Clicking on 'Add to Cart'.");
        //         productPage.clickAddToCart();

        //         LoggerManager.Info("Clicking on cart icon.");
        //         productPage.clickOnCartIcon();

        //         LoggerManager.Info("Verifying mini cart visibility.");
        //         Assert.That(productPage.IsMiniCartVisible(), Is.True, "Mini cart did not appear after adding product.");

        //         LoggerManager.Info("Verifying product name in mini cart.");
        //         string productName = productPage.getMiniCartProductName();
        //         LoggerManager.Info($"Product name in mini cart: {productName}");
        //         Assert.That(productName, Does.Contain("Armani"), "Product name in mini cart is incorrect.");

        //         LoggerManager.Info("TC06_AddProductWithSize_Success passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC06_AddProductWithSize_Success failed: " + ex.Message);
        //         throw;
        //     }
        // }


        // [Test]
        // public void TC07_AddProduct_CheckPersistenceAfterRefresh()
        // {
        //     try
        //     {
        //         var productPage = new ProductPage(Driver);

        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Armani Majica'.");
        //         productPage.clickOnArmaniMajica();

        //         LoggerManager.Info("Selecting size 'L'.");
        //         productPage.selectSize("L");

        //         LoggerManager.Info("Clicking on 'Add to Cart'.");
        //         productPage.clickAddToCart();

        //         LoggerManager.Info("Refreshing the page to simulate user return.");
        //         Driver.Navigate().Refresh();

        //         //  Čekamo da se korpa ponovo pojavi nakon refresh-a
        //         LoggerManager.Info("Waiting for cart icon to be visible after refresh.");
        //         WebDriverWait refreshWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        //         refreshWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
        //             By.CssSelector("a.action.showcart")));

        //         LoggerManager.Info("Clicking on cart icon after refresh.");
        //         productPage.clickOnCartIcon();

        //         LoggerManager.Info("Verifying mini cart visibility after refresh.");
        //         Assert.That(productPage.IsMiniCartVisible(), Is.True, "Mini cart is not visible after refresh.");

        //         LoggerManager.Info("Verifying product name in mini cart after refresh.");
        //         string productName = productPage.getMiniCartProductName();
        //         LoggerManager.Info("Product name found: " + productName);
        //         Assert.That(productName, Does.Contain("Armani"), "Product was not preserved in the cart after refresh.");

        //         LoggerManager.Info("TC07_AddProduct_CheckPersistenceAfterRefresh passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC07_AddProduct_CheckPersistenceAfterRefresh failed: " + ex.Message);
        //         throw;
        //     }
        // }



        // [Test]
        // public void TC08_RemoveProductFromCart()
        // {
        //     try
        //     {
        //         var productPage = new ProductPage(Driver);

        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Armani Majica'.");
        //         productPage.clickOnArmaniMajica();

        //         LoggerManager.Info("Selecting size 'L'.");
        //         productPage.selectSize("L");

        //         LoggerManager.Info("Clicking on 'Add to Cart'.");
        //         productPage.clickAddToCart();

        //         LoggerManager.Info("Clicking on cart icon.");
        //         productPage.clickOnCartIcon();

        //         LoggerManager.Info("Verifying mini cart visibility.");
        //         Assert.That(productPage.IsMiniCartVisible(), Is.True);

        //         LoggerManager.Info("Removing product from mini cart.");
        //         productPage.removeProductFromMiniCart();

        //         LoggerManager.Info("Refreshing page to ensure cart overlay is cleared.");
        //         Driver.Navigate().Refresh();

        //         productPage.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a.action.showcart")));

        //         LoggerManager.Info("Clicking on cart icon to verify cart status.");
        //         productPage.clickOnCartIcon();

        //         LoggerManager.Info("Waiting for empty cart message to be visible.");
        //         productPage.Wait.Until(driver => driver.FindElement(By.CssSelector("strong.subtitle.empty")).Displayed);

        //         string emptyMessage = productPage.GetEmptyCartMessage();
        //         LoggerManager.Info($"Empty cart message: '{emptyMessage}'");

        //         Assert.That(emptyMessage, Is.EqualTo("Nemate proizvoda u vašoj korpi za kupovinu."));

        //         LoggerManager.Info("TC08_RemoveProductFromCart passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC08_RemoveProductFromCart failed: " + ex.Message);
        //         throw;
        //     }
        // }

        // [Test]
        // public void TC09_UpdateQuantityInCart()
        // {
        //     try
        //     {
        //         var productPage = new ProductPage(Driver);

        //         LoggerManager.Info("Navigating to 'Majice' section.");
        //         productPage.navigateToMajice();

        //         LoggerManager.Info("Clicking on 'Armani Majica'.");
        //         productPage.clickOnArmaniMajica();

        //         LoggerManager.Info("Selecting size 'L'.");
        //         productPage.selectSize("L");

        //         LoggerManager.Info("Clicking on 'Add to Cart'.");
        //         productPage.clickAddToCart();

        //         LoggerManager.Info("Clicking on cart icon.");
        //         productPage.clickOnCartIcon();

        //         LoggerManager.Info("Changing product quantity to 2.");
        //         productPage.changeQuantityInMiniCart("2");

        //         LoggerManager.Info("Clicking update button.");
        //         productPage.clickUpdateCartButton();

        //         LoggerManager.Info("Waiting for total price to update.");
        //         productPage.Wait.Until(driver => productPage.getTotalPriceFromMiniCart() == "10.780,00 RSD");

        //         string updatedTotal = productPage.getTotalPriceFromMiniCart();
        //         LoggerManager.Info($"Total price after update: {updatedTotal}");

        //         Assert.That(updatedTotal, Is.EqualTo("10.780,00 RSD"));

        //         LoggerManager.Info("TC09_UpdateQuantityInCart passed.");
        //     }
        //     catch (Exception ex)
        //     {
        //         LoggerManager.Error("TC09_UpdateQuantityInCart failed: " + ex.Message);
        //         throw;
        //     }
        // }

       [Test]
        public void TC13_FilterByColor_Teget()
        {
            try
            {
                LoggerManager.Info("Starting test: TC13_FilterByColor_Teget");

                var productPage = new ProductPage(Driver);

                LoggerManager.Info("Navigating to 'Majice' section.");
                productPage.navigateToMajice();

                LoggerManager.Info("Clicking on filter 'Boja'.");
                productPage.ClickFilterColor();

                LoggerManager.Info("Selecting 'Teget' color.");
                productPage.SelectTegetColor();

                LoggerManager.Info("Waiting for product images to be visible after filter is applied.");
                productPage.WaitForFilteredProducts();

                LoggerManager.Info("Validating all products displayed match selected color: Teget.");
                var altTexts = productPage.GetAllProductAlts();

                foreach (var alt in altTexts)
                {
                    LoggerManager.Info($"Checking alt text: {alt}");
                    Assert.That(alt.ToLower(), Does.Contain("teget").Or.Contain("plava"),
                        $"Product alt text does not indicate 'Teget' color: {alt}");
                }

                LoggerManager.Info("TC13_FilterByColor_Teget passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC13_FilterByColor_Teget failed: " + ex.Message);
                throw;
            }
            finally
            {
                LoggerManager.Info("Ending test: TC13_FilterByColor_Teget");
            }
        }



    }


}





















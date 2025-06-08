using NUnit.Framework;
using NulTien_XYZFashionAutomation.Pages;
using System;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using NulTien_XYZFashionAutomation.Utilities;



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


        [Test]
        public void TC04_VerifyDiscountDisplayedCorrectly()
        {
            try
            {
                LoggerManager.Info("Navigating to 'Majice' section.");
                var productPage = new ProductPage(Driver);
                productPage.navigateToMajice();

                LoggerManager.Info("Clicking on 'Versace Majica'.");
                productPage.clickOnVersaceMajica();

                LoggerManager.Info("Retrieving old and discounted prices.");
                string oldPriceText = productPage.getOldPrice();
                string newPriceText = productPage.getDiscountedPrice();

                LoggerManager.Debug("Old price text: " + oldPriceText);
                LoggerManager.Debug("New price text: " + newPriceText);

                decimal oldPrice = decimal.Parse(oldPriceText.Replace(".", "").Replace(",", ".").Replace(" RSD", ""));
                decimal newPrice = decimal.Parse(newPriceText.Replace(".", "").Replace(",", ".").Replace(" RSD", ""));

                decimal discountPercent = Math.Round((1 - (newPrice / oldPrice)) * 100);
                LoggerManager.Info($"Calculated discount: {discountPercent}%");

                Assert.That((int)discountPercent, Is.EqualTo(15), "Discount percentage is not correctly calculated.");
                LoggerManager.Info("TC04_VerifyDiscountDisplayedCorrectly passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC04_VerifyDiscountDisplayedCorrectly failed: " + ex.Message);
                throw;
            }
        }





    }


}





















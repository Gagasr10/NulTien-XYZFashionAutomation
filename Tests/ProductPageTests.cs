using NUnit.Framework;
using NulTien_XYZFashionAutomation.Pages;
using System;
using OpenQA.Selenium;
using System.Diagnostics;

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
        //     productPage.clickOnArmaniMajica();

        //     string expectedProductName = "Armani Exchange - Crvena muška majica";
        //     string actualProductName = productPage.getProductName();

        //     Assert.That(actualProductName, Is.EqualTo(expectedProductName), "Displayed product name does not match expected.");

        // }

        //  [Test]
        // public void TC02_ProductLoadTimeUnder3Seconds()
        // {
        //     productPage!.navigateToMajice();
        //     var stopwatch = Stopwatch.StartNew();
        //     productPage.clickOnArmaniMajica();
        //     stopwatch.Stop();
        //     double loadTime = stopwatch.Elapsed.TotalSeconds;

        //     Assert.That(loadTime, Is.LessThanOrEqualTo(3),
        //         $"Product page took too long to load: {loadTime:F2} seconds.");
        // }



        [Test]
        public void TC03_CorrectPriceIsDisplayed()
        {
            productPage.navigateToMajice();
            productPage.clickOnArmaniMajica();

            string actualPrice = productPage.getProductPrice();
            string expectedPrice = "5.390,00 RSD";

           Assert.That(actualPrice, Is.EqualTo(expectedPrice), "The displayed product price is incorrect.");

        }






    }


}





















using NUnit.Framework;
using NulTien_XYZFashionAutomation.Pages;
using NulTien_XYZFashionAutomation.Utilities;

namespace NulTien_XYZFashionAutomation.Tests
{
    [TestFixture]
    public class SearchPageTests : BaseTest
    {
           [Test]
            public void TC10_SearchWithInvalidCharacters()
            {
                try
                {
                    var searchPage = new SearchPage(Driver);

                    LoggerManager.Info("Clicking on the search icon.");
                    searchPage.ClickSearchIcon();

                    LoggerManager.Info("Entering invalid search term: '#$##^%&&%'.");
                    searchPage.EnterSearchTerm("#$##^%&&%");

                    LoggerManager.Info("Submitting the search with Enter key.");
                    searchPage.PressEnterInSearch();

                    LoggerManager.Info("Retrieving 'no results' message from search results.");
                    string expectedMessage = "Ne možemo pronaći proizvode koji odgovaraju Vašem izboru.";
                    string actualMessage = searchPage.GetNoResultsMessage();

                    LoggerManager.Info($"Asserting 'no results' message. Expected: '{expectedMessage}', Actual: '{actualMessage}'");
                    Assert.That(actualMessage, Is.EqualTo(expectedMessage), "No results message did not match.");

                    LoggerManager.Info("TC10_SearchWithInvalidCharacters passed.");
                }
                catch (Exception ex)
                {
                    LoggerManager.Error("TC10_SearchWithInvalidCharacters failed: " + ex.Message);
                    throw;
                }
                finally
                {
                    LoggerManager.Info("Ending test: TC10_SearchWithInvalidCharacters");
                }
            }


        [Test]
        public void TC11_SearchWithExactProductName()
        {
            try
            {
                var searchPage = new SearchPage(Driver);

                LoggerManager.Info("Clicking on the search icon.");
                searchPage.ClickSearchIcon();

                LoggerManager.Info("Entering search term: 'Armani Exchange - Crvena muška majica'");
                searchPage.EnterSearchTerm("Armani Exchange - Crvena muška majica");

                LoggerManager.Info("Submitting the search with Enter key.");
                searchPage.PressEnterInSearch();

                LoggerManager.Info("Retrieving product title from search results.");
                string actualTitle = searchPage.GetProductTitle();
                string expectedTitle = "Armani Exchange - Crvena muška majica";

                LoggerManager.Info($"Asserting product title. Expected: '{expectedTitle}', Actual: '{actualTitle}'");
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Product title is not as expected.");

                LoggerManager.Info("TC11_SearchWithExactProductName passed.");
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC11_SearchWithExactProductName failed: " + ex.Message);
                throw;
            }
        }

        [Test]
        public void TC12_SearchWithExactProductName_MobileView()
        {
            try
            {
                LoggerManager.Info("Starting test: TC12_SearchWithExactProductName_MobileView");

                Driver.Manage().Window.Size = new System.Drawing.Size(412, 915);

                var searchPage = new SearchPage(Driver);

                LoggerManager.Info("Entering exact product name in mobile search field.");
                searchPage.EnterSearchTerm("Armani Exchange - Crvena muška majica");

                LoggerManager.Info("Clicking on the search (magnifier) button.");
                searchPage.ClickSearchIcon();

                LoggerManager.Info("Waiting for search result to be visible.");
                bool productVisible = searchPage.IsExpectedProductVisible("Armani Exchange - Crvena muška majica");

                Assert.That(productVisible, Is.True, "Expected product is not visible in search results.");

                LoggerManager.Info("TC12_SearchWithExactProductName_MobileView passed.");
               
            }
            catch (Exception ex)
            {
                LoggerManager.Error("TC12_SearchWithExactProductName_MobileView failed: " + ex.Message);
                throw;
            }
            finally
            {
                LoggerManager.Info("Ending test: TC12_SearchWithExactProductName_MobileView");
            }
        }



    }
}

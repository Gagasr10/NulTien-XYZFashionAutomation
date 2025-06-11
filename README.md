# NulTien_XYZFashionAutomation

Automated UI test suite for the e-commerce site https://rs.shop.xyz.fashion, implemented in C# using Selenium WebDriver and NUnit. The framework supports parallel test execution, screenshot capture on failure, and detailed logging using NLog.

## Project Overview

This project tests the core checkout flow and product search functionality, including:

- Adding products to cart
- Filtering by color
- Filling and validating shipping details
- Search scenarios (positive and negative)
- Verifying cart persistence and modification

The solution is structured using the Page Object Model for code clarity and reusability.

## Technologies Used

- Language: C#
- Framework: NUnit
- Automation Tool: Selenium WebDriver
- Browsers: Chrome, Firefox, Edge (via DriverFactory)
- Logging: NLog (stored in Logs/logfile.txt)
- Screenshot on Failure: via NUnit ITestListener
- Configuration: appsettings.json
- IDE: Visual Studio Code
- Version Control: Git + GitHub

## Project Structure

```
NulTien_XYZFashionAutomation/
├── Pages/                 # Page Object Model classes
├── Tests/                 # Test classes organized by feature
├── Utilities/             # Helper classes (config reader, logger, driver factory, etc.)
├── Screenshots/           # Captured screenshots on test failures
├── TestResults/           # XML/JSON test result outputs
├── bin/
│   └── Logs/              # Contains log files for each test run (generated via NLog)
├── appsettings.json       # Configuration for browser, base URL, timeouts
├── NUnit.runsettings      # NUnit-specific run configuration
├── global.json            # .NET SDK version info
├── README.md              # Project overview and instructions
├── .gitignore             # Ignored files/folders for version control
```

## Configuration

### appsettings.json

```json
{
  "Browser": "Chrome",
  "BaseUrl": "https://rs.shop.xyz.fashion",
  "Timeouts": {
    "ImplicitWait": 5,
    "ExplicitWait": 10
  }
}
```

### global.json

```json
{
  "sdk": {
    "version": "8.0.410"
  }
}
```

## How to Run the Tests

Run all tests with a maximum of 3 in parallel:

```
dotnet test --settings NUnit.runsettings
```

Run all tests from a specific class:

```
dotnet test --settings NUnit.runsettings --filter "FullyQualifiedName~NulTien_XYZFashionAutomation.Tests.ProductPageTests"
```

Run a specific test method:

```
dotnet test --settings NUnit.runsettings --filter "FullyQualifiedName~NulTien_XYZFashionAutomation.Tests.ProductPageTests.TC13_FilterByColor_Teget"
```

## Exploratory Testing Insight
Before developing the automated test suite, exploratory testing was conducted on key user flows, including registration and checkout. This initial manual testing phase helped identify real-world issues that would be missed by automation alone.

Notably, the following bug was discovered:

* EX-REG-01: The system allows user registration with only a one-character first name (e.g., "A"), which should typically be disallowed as invalid input.

This issue was reported and documented early, helping improve test coverage by driving the inclusion of corresponding validation scenarios in the automated suite.

## Test Coverage

| Feature             | Covered |
|---------------------|---------|
| Login (precondition) | Yes     |
| Search functionality | Yes     |
| Filtering by color   | Yes     |
| Cart actions         | Yes     |
| Checkout form        | Yes     |
| Mobile/responsive    | Yes     |

## Test Case Descriptions
Below is a brief overview of the implemented test cases in the suite:

## Product Page
* TC01_VerifyProductPageLoad 
- Verifies that navigating to the "Majice" section and opening the "Armani Majica" product displays the correct product name.

* TC02_ProductLoadTimeUnder3Seconds  
 - Measures the time it takes for the product page to load and asserts it completes within 3 seconds.

* TC03_CorrectPriceIsDisplayed  
 - Confirms that the displayed price of "Armani Majica" matches the expected price.

* TC04_VerifyDiscountDisplayedCorrectly  
 - Validates the correctness of the discount percentage shown for "Versace Majica" based on old and new prices.

* TC05_CannotAddProductWithoutSelectingSize  
 - Ensures the product cannot be added to the cart unless a size is selected.

* TC06_AddProductWithSize_Success 
 - Tests successful addition of a product to the cart after selecting a size, and validates its presence in the mini-cart.

* TC07_AddProduct_CheckPersistenceAfterRefresh 
 - Confirms that the product remains in the cart after a browser refresh.

* TC08_RemoveProductFromCart 
 - Adds a product to the cart and removes it, verifying the cart is empty afterward.

* TC09_UpdateQuantityInCart  
 - Changes product quantity in the mini-cart and asserts the total price updates accordingly.

* TC13_FilterByColor_Teget 
 - Applies the "Teget" color filter and validates that all visible products match the selected color based on image alt text.

## Search Page
* TC10_SearchWithInvalidCharacters - 
 - Enters invalid symbols in the search bar and checks that the "no results" message is correctly shown.

* TC11_SearchWithExactProductName - 
 - Searches for a full product name and verifies that the correct item appears in the results.

* TC12_SearchWithExactProductName_MobileView - 
 - Runs the same exact search as TC11 but simulates a mobile screen resolution to validate responsive behavior.

## Shipping Page
* TC14_ShippingForm_RequiredFieldsValidation 
 - Attempts to proceed without filling required fields in the shipping form, validating that error messages are shown.

* TC15_PostalCodeCityMismatch_ShowsErrorMessage 
 - Enters mismatched city and postal code values to ensure the form displays the appropriate error.

* TC16_InvalidStreetNameInCorrectCity_ShouldNotProceedToPayment
 - Submits an address that doesn't exist for the selected city and verifies the user is not taken to the payment page.

## Test Results Summary

- Total tests executed: 16  
- Passed: 13  
- Failed: 3  
- Pass rate: 81.25%

## Bugs Reported

Three sample bugs identified during testing:

1. EX-REG-01: Registration accepts 1-character first name
2. TC13: Filtering by color "Teget" shows unrelated or incorrectly colored items
3. TC16: Checkout accepts invalid street address

Detailed bug reports can be found in the `/Bugs` directory.

## Logs and Screenshots

- Logs: `bin/Debug/net8.0/Logs/logfile.txt`
- Screenshots on failure: `Screenshots/`

- Example log (TC03_CorrectPriceIsDisplayed):

- 2025-06-11 17:36:34.3650 INFO Starting test: TC03_CorrectPriceIsDisplayed 
- 2025-06-11 17:36:52.5103 INFO Navigating to 'Majice' section. 
- 2025-06-11 17:36:56.6105 INFO Clicking on 'Armani Majica'. 
- 2025-06-11 17:37:01.8437 INFO Retrieving actual product price. 
- 2025-06-11 17:37:01.9224 INFO Actual price: 5.390,00 RSD, Expected price: 5.390,00 RSD
- 2025-06-11 17:37:01.9300 INFO TC03_CorrectPriceIsDisplayed passed.  
- 2025-06-11 17:37:01.9300 INFO Ending test: TC03_CorrectPriceIsDisplayed 

## Highlights

- Modular Page Object Model architecture
- Cross-browser and responsive test support
- LoggerManager for step-by-step traceability
- Configurable timeouts and browser settings
- Parallel execution supported via `NUnit.runsettings`

## TODO – Next Steps
1. Random Test Data Generator
TODO: Create a helper method that generates random valid user data for registration and login tests.
Currently, hardcoded users (e.g., wagas44949@...) are used, which limits parallel test execution and makes tests less flexible. This task was not completed due to time constraints.

2. Test Report (Dashboard) Generation
TODO: Implement a basic HTML report generator after test execution (e.g., Allure or ReportUnit).
This task was not completed due to installation issues encountered while integrating ExtentReports. It can remain in the backlog, but would be valuable for visibility, especially in team and CI/CD environments. Time constraints also prevented full implementation.

3. Mobile View Test Coverage
TODO: Add at least 1–2 additional tests to verify user behavior and UI interactions in mobile viewports.
Currently, only the search functionality is tested in mobile view. Other flows like filtering, navigation, and checkout are not covered. While attempting mobile testing, there were issues with element visibility due to responsive layout changes. The flow of the application also changes (e.g., navigation menus become hamburger icons, filters are hidden in drawers), which caused additional complexity. These tests were deprioritized due to time limitations.

4. Multiple Products in Cart Test
TODO: Add a test that verifies adding multiple different products to the cart and checks whether the total price is calculated correctly.
All existing cart-related tests currently validate only one product at a time. This scenario remains uncovered due to lack of time.

## Author

Dragan Stojilkovic  
QA Automation Engineer

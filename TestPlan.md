# Test Plan for Checkout Flow – rs.shop.xyz.fashion

## 1. Document Title
**Test Plan for Checkout Flow – rs.shop.xyz.fashion**

## 2. Objective
The objective is to verify the functionality of the checkout flow – starting from adding a product to the cart, proceeding through the input of user and shipping information, and stopping before the final order confirmation step.

**Note:** We will perform a login before entering the checkout flow, but login functionality itself will not be tested in this task. It will be used only as a prerequisite to reach the shipping details page.

Additionally, we will perform exploratory manual testing to get familiar with the application’s flow and behavior before designing and implementing automated tests.

## 3. Scope

** In Scope:**
- Adding a product to the cart
- Verifying cart summary and total price
- Clicking the “Checkout” button
- Filling in shipping details (first name, last name, email, address, etc.)
- Input field validation (required fields, email format, etc.)
- Cross-browser compatibility testing (Chrome, Firefox, Edge)
- Responsive testing (mobile and tablet viewports)

** Out of Scope:**
- Payment methods (Credit Card, PayPal, etc.)
- Final order confirmation
- Backend processing or email confirmations

## 4. Test Strategy

- **Type:** UI functional testing (positive and negative scenarios)
- **Method:**
  - Manual exploratory testing to understand the application flow
  - Automated testing using Selenium WebDriver in C#
  - Compatibility testing across browsers and responsive devices
- **Framework:** NUnit

## 5. Test Environment

- **URL:** https://rs.shop.xyz.fashion/
- **Browsers:** Chrome (primary), Firefox, Edge
- **Devices:** Desktop, Mobile(responsive viewpoints), Tablet (responsive viewports)
- **OS:** Windows 10
- **Test environment:** Public production site

## 6. Test Data

Dummy user credentials used for login and checkout tests:

- **First Name:** J  
- **Last Name:** Douglas  
- **Email:** wagas44949@adrewire.com
- **Password:** JohnEng0  

> Note: The application currently allows user creation with only 1 character in the first name, which will be covered in negative testing (input validation).

## 7. Tools

- **IDE:** Visual Studio Code
- **Automation Tool:** Selenium WebDriver
- **Framework:** NUnit
- **Reporting:** Console output and screenshot capture on failure (if implemented)
- **Version Control:** Git + GitHub

## 8. Roles and Responsibilities

| Name   | Role                | Responsibilities                                      |
|--------|---------------------|--------------------------------------------------------|
| Dragan | QA Automation Eng.  | Manual exploration, test case design, scripting, bug reporting |

## 9. Test Cases

Test cases are currently under development.  
Planned coverage includes:

- Adding a product to the cart
- Verifying product presence in cart
- Clicking “Checkout” button
- Filling shipping form with valid data
- Validating form errors (e.g., empty or invalid email)
- Ensuring user cannot proceed with invalid inputs
- Testing on multiple browsers and devices

## 10. Entry & Exit Criteria

**Entry Criteria:**
- Website is accessible
- Automation framework is set up
- Test scenarios are designed

**Exit Criteria:**
- All test cases have been executed
- All valid defects are reported
- The application behaves consistently across test runs and environments

## 11. Risks

- The website may change unexpectedly (no notification from dev team)
- No staging environment available; testing is performed on production
- Limited scope due to lack of backend access

## 12. Metrics

- **Total test cases:** 7  
- **Passed:** 6  
- **Failed:** 1  
- **Bugs reported:** 2

## 13. Bug Reporting Format

Bug reports will follow a structured format similar to Jira:

- **ID:** e.g., TC-001  
- **Title:** "Cart total does not match product page price"  
- **Steps to Reproduce**  
- **Expected Result**  
- **Actual Result**  
- **Screenshot or Video Evidence**
